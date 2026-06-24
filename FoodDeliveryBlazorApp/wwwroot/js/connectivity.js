window.connectivity = {
    _handler: null,

    getStatus: function () {
        return navigator.onLine;
    },

    initialize: function (dotNetRef) {
        window.connectivity._handler = function () {
            dotNetRef.invokeMethodAsync('OnConnectivityChanged', navigator.onLine);
        };

        window.addEventListener('online', window.connectivity._handler);
        window.addEventListener('offline', window.connectivity._handler);
    },

    dispose: function () {
        if (window.connectivity._handler) {
            window.removeEventListener('online', window.connectivity._handler);
            window.removeEventListener('offline', window.connectivity._handler);
            window.connectivity._handler = null;
        }
    }
};
