//Timer.js controls the timer label in the board.cshtml file
var seconds = 60; // set the clock
function secondPassed() {
    var minutes = Math.round((seconds - 30) / 60);
    var remainingSeconds = seconds % 60;
    if (remainingSeconds < 10) {
        remainingSeconds = "0" + remainingSeconds;
    }
    document.getElementById('countdown').innerHTML = minutes + ":" + remainingSeconds;
    if (seconds == 0) {//if zero, set the clock to red and the instruction label to gameover
        clearInterval(countdownTimer);
        //document.getElementById('countdown').innerHTML = "TIME'S UP!";
        $(".instruction").text("GAME OVER");
        document.getElementById('countdown').setAttribute("style", "color:red;");
    } else { // otherwise take a seconf off the clock
        seconds--;
    }
}

var countdownTimer = setInterval('secondPassed()', 1000);