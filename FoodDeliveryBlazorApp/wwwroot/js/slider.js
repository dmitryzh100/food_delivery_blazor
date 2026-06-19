window.foodhubSlider = {
    enableDrag: function (el) {
        if (!el || el._fhDrag) {
            return;
        }

        el._fhDrag = true;

        const step = function () {
            const a = el.children[0];
            const b = el.children[1];

            if (a && b) {
                return b.getBoundingClientRect().left - a.getBoundingClientRect().left;
            }

            if (a) {
                return a.getBoundingClientRect().width;
            }

            return el.clientWidth;
        };

        const clamp = function (i, max) {
            return Math.max(0, Math.min(max, i));
        };

        let down = false;
        let startX = 0;
        let startScroll = 0;
        let moved = false;
        let velocity = 0;
        let lastScroll = 0;
        let lastTime = 0;

        el.addEventListener('pointerdown', function (e) {
            if (e.pointerType !== 'mouse') {
                return;
            }

            down = true;
            moved = false;
            velocity = 0;
            startX = e.clientX;
            startScroll = el.scrollLeft;
            lastScroll = el.scrollLeft;
            lastTime = e.timeStamp;
            el.setPointerCapture(e.pointerId);
            el.classList.add('is-dragging');
        });

        el.addEventListener('pointermove', function (e) {
            if (!down) {
                return;
            }

            const dx = e.clientX - startX;

            if (Math.abs(dx) > 3) {
                moved = true;
            }

            el.scrollLeft = startScroll - dx;

            const dt = e.timeStamp - lastTime;

            if (dt > 0) {
                velocity = (el.scrollLeft - lastScroll) / dt;
                lastScroll = el.scrollLeft;
                lastTime = e.timeStamp;
            }
        });

        const end = function (e) {
            if (!down) {
                return;
            }

            down = false;

            try {
                el.releasePointerCapture(e.pointerId);
            } catch (_) {
                // pointer may already be released
            }

            el.classList.remove('is-dragging');

            const size = step();
            const count = el.children.length - 1;
            const current = el.scrollLeft / size;

            let target;

            if (velocity > 0.25) {
                target = Math.floor(current) + 1;
            } else if (velocity < -0.25) {
                target = Math.ceil(current) - 1;
            } else {
                target = Math.round(current);
            }

            el.scrollTo({ left: clamp(target, count) * size, behavior: 'smooth' });
        };

        el.addEventListener('pointerup', end);
        el.addEventListener('pointercancel', end);

        // Swallow the click that fires after a drag so a card action isn't triggered.
        el.addEventListener('click', function (e) {
            if (moved) {
                e.preventDefault();
                e.stopPropagation();
                moved = false;
            }
        }, true);

        el.addEventListener('dragstart', function (e) {
            e.preventDefault();
        });
    }
};
