(function () {
    let dotNetRef = null;
    let registration = null;
    let updateApplied = false;

    function notifyUpdate() {
        if (dotNetRef) {
            dotNetRef.invokeMethodAsync('NotifyUpdateAvailable');
        }
    }

    window.foodhubPwa = {
        initialize: function (ref) {
            dotNetRef = ref;

            if (registration && registration.waiting && navigator.serviceWorker.controller) {
                notifyUpdate();
            }
        },

        applyUpdate: function () {
            if (registration && registration.waiting) {
                updateApplied = true;
                registration.waiting.postMessage('SKIP_WAITING');
            } else {
                window.location.reload();
            }
        }
    };

    if (!('serviceWorker' in navigator)) {
        return;
    }

    navigator.serviceWorker.addEventListener('controllerchange', function () {
        if (!updateApplied) {
            return;
        }

        updateApplied = false;
        window.location.reload();
    });

    navigator.serviceWorker.register('service-worker.js', { updateViaCache: 'none' }).then(function (reg) {
        registration = reg;

        if (reg.waiting && navigator.serviceWorker.controller) {
            notifyUpdate();
        }

        reg.addEventListener('updatefound', function () {
            const installing = reg.installing;

            if (!installing) {
                return;
            }

            installing.addEventListener('statechange', function () {
                if (installing.state === 'installed' && navigator.serviceWorker.controller) {
                    notifyUpdate();
                }
            });
        });

        setInterval(function () {
            reg.update();
        }, 60000);
    });
})();
