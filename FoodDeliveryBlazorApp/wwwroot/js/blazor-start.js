// blazor.webassembly.js is loaded with autostart="false", so the app is started
// explicitly here with the persisted (or default) UI culture.
(function () {
    const supported = ['en', 'uk', 'fr'];
    let culture = window.blazorCulture.get();

    if (!supported.includes(culture)) {
        culture = 'en';
    }

    Blazor.start({ applicationCulture: culture });
})();
