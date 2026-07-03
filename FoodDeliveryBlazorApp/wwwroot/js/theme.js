// Resolves and applies the theme before the first paint to avoid a flash of the
// light theme. Loaded as a render-blocking script in <head>, and the same helper
// is reused by the C# ThemeService (Features/Theming/Services/ThemeService.cs).
window.foodHubTheme = {
    storageKey: 'foodhub-theme',
    get: function () {
        try {
            return window.localStorage.getItem(this.storageKey);
        } catch (e) {
            return null;
        }
    },
    set: function (value) {
        try {
            window.localStorage.setItem(this.storageKey, value);
        } catch (e) {
            // ignore storage failures (private mode, disabled storage)
        }
    },
    systemPrefersDark: function () {
        return !!(window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches);
    },
    resolveInitial: function () {
        var stored = this.get();

        if (stored === 'light' || stored === 'dark') {
            return stored;
        }

        return this.systemPrefersDark() ? 'dark' : 'light';
    },
    apply: function (theme) {
        document.documentElement.setAttribute('data-theme', theme === 'dark' ? 'dark' : 'light');
    }
};

window.foodHubTheme.apply(window.foodHubTheme.resolveInitial());
