/*
 * This file handles managing the swipe events for implementing touch controls.
 * Had issues with iOS, so it's deprecated.
 */

var game = document.getElementById("game");
if (game != null) { //used so the browser doesn't freak out if not at a game page

    var hammer = new Hammer(game); //using hammer library to detect touch events
    hammer.get('swipe').set({ direction: Hammer.DIRECTION_ALL }); //for some reason swipe up and down was off by default

    hammer.on('swipeup swipedown swipeleft swiperight', function (event) {
        if (event.type === 'swipeup') {
            simulateKey(38); //up arrow key
        } else if (event.type === 'swipedown') {
            simulateKey(40); //down arrow key
        } else if (event.type === 'swipeleft') {
            simulateKey(37); //left arrow key
        } else if (event.type === 'swiperight') {
            simulateKey(39); //right arrow key
        }
    });

    function simulateKey(keyCode) {
        var event = new KeyboardEvent("keydown", { keyCode });

        document.dispatchEvent(event);
    }
}