<#
.SYNOPSIS
    Reconciles the Blazor PWA service-worker asset integrity hashes with the files on disk.

.DESCRIPTION
    Blazor's published service worker verifies every pre-cached asset against a SHA-256
    integrity hash recorded in service-worker-assets.js. Any post-publish change to a
    listed file (e.g. injecting the base href, app name, or other per-environment values
    into index.html) invalidates that hash and makes the service worker install fail.

    This script recomputes the hash of every asset listed in the manifest, updates the
    ones that diverge, logs each divergence, and fails if a listed file is missing.

.PARAMETER WwwRoot
    Path to the published wwwroot folder. Defaults to 'publish/wwwroot'.
#>
[CmdletBinding()]
param(
    [string]$WwwRoot = 'publish/wwwroot'
)

$ErrorActionPreference = 'Stop'

$assetsFile = Join-Path $WwwRoot 'service-worker-assets.js'

if (-not (Test-Path $assetsFile)) {
    Write-Error "service-worker-assets.js not found at '$assetsFile'. Is this a published PWA output?"
    exit 1
}

function Get-IntegrityHash {
    param([string]$Path)

    $bytes = [System.IO.File]::ReadAllBytes($Path)
    $sha = [System.Security.Cryptography.SHA256]::Create()

    try {
        return 'sha256-' + [Convert]::ToBase64String($sha.ComputeHash($bytes))
    }
    finally {
        $sha.Dispose()
    }
}

# The file is JS: `self.assetsManifest = { ... };`. Strip the wrapper to get the JSON body.
$raw = [System.IO.File]::ReadAllText($assetsFile).Trim()
$start = $raw.IndexOf('{')
$json = $raw.Substring($start).TrimEnd()

if ($json.EndsWith(';')) {
    $json = $json.Substring(0, $json.Length - 1)
}

$manifest = $json | ConvertFrom-Json

$diverged = 0
$missing = 0

foreach ($asset in $manifest.assets) {
    $assetPath = Join-Path $WwwRoot $asset.url

    if (-not (Test-Path $assetPath)) {
        Write-Host "MISSING   $($asset.url)"
        $missing++
        continue
    }

    $actual = Get-IntegrityHash -Path $assetPath

    if ($actual -ne $asset.hash) {
        Write-Host "DIVERGED  $($asset.url)"
        Write-Host "            recorded: $($asset.hash)"
        Write-Host "            actual:   $actual"
        $asset.hash = $actual
        $diverged++
    }
}

if ($diverged -gt 0) {
    $body = $manifest | ConvertTo-Json -Depth 20
    [System.IO.File]::WriteAllText($assetsFile, "self.assetsManifest = $body;")
}

Write-Host ''
Write-Host "Checked $($manifest.assets.Count) assets: $diverged hash(es) updated, $missing missing."

if ($missing -gt 0) {
    Write-Error "$missing asset(s) listed in the manifest were not found on disk."
    exit 1
}

if ($diverged -eq 0) {
    Write-Host 'No divergences - service worker integrity already consistent.'
}
