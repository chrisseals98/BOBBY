// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var game = document.getElementById("game");
if (game != null) { //used so the browser doesn't freak out if not at a game page

    const canvasSwipe = document.getElementById('game');

    let touchStartX, touchEndX;

    canvasSwipe.addEventListener('touchstart', (e) => {
        touchStartX = e.touches[0].clientX;
        touchStartY = e.touches[0].clientY;
    });

    canvasSwipe.addEventListener('touchmove', (e) => {
        e.preventDefault(); // Prevent scrolling while swiping
    });

    canvasSwipe.addEventListener('touchend', (e) => {
        touchEndX = e.changedTouches[0].clientX;
        touchEndY = e.changedTouches[0].clientY;
        handleSwipe();
    });

    function simulateKeyPress(keyCode) {
        const event = new KeyboardEvent('keydown', {
            key: '',
            keyCode: keyCode,
            which: keyCode,
        });
        document.dispatchEvent(event);
    }

    function handleSwipe() {
        const threshold = 50;

        const deltaX = touchStartX - touchEndX;
        const deltaY = touchStartY - touchEndY;

        if (Math.abs(deltaX) > Math.abs(deltaY)) {
            // Horizontal swipe
            if (deltaX > threshold) {
                // Swipe left action
                simulateKeyPress(37); // 37 is the key code for left arrow
            } else if (deltaX < -threshold) {
                // Swipe right action
                simulateKeyPress(39); // 39 is the key code for right arrow
            }
        } else {
            // Vertical swipe
            if (deltaY > threshold) {
                // Swipe up action
                simulateKeyPress(38); // 38 is the key code for up arrow
            } else if (deltaY < -threshold) {
                // Swipe down action
                simulateKeyPress(40); // 40 is the key code for down arrow
            }
        }
    }
}