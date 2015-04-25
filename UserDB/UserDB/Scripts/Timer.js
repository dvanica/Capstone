var seconds = 60;
function secondPassed() {
    var minutes = Math.round((seconds - 30) / 60);
    var remainingSeconds = seconds % 60;
    if (remainingSeconds < 10) {
        remainingSeconds = "0" + remainingSeconds;
    }
    document.getElementById('countdown').innerHTML = minutes + ":" + remainingSeconds;
    if (seconds == 0) {
        clearInterval(countdownTimer);
        //document.getElementById('countdown').innerHTML = "TIME'S UP!";
        $(".instruction").text("GAME OVER");
        document.getElementById('countdown').setAttribute("style", "color:red;");
    } else {
        seconds--;
    }
}

var countdownTimer = setInterval('secondPassed()', 1000);