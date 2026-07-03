// Reads/writes the persisted UI culture. Defined before Blazor starts so the app
// can boot with the correct satellite (localized) resources.
window.blazorCulture = {
    get: () => window.localStorage['BlazorCulture'],
    set: (value) => window.localStorage['BlazorCulture'] = value
};
