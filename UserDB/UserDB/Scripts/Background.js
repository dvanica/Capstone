// Synchronous AJAX call to get the user's university name and change the background of the 
// game board accordingly. The GetUserSchool method is a HTTPGet method found in the homecontroller.cs
// file. If the GetUserSchool Method returns null, an alert view will be present. 
var school = "undefined";
$.ajax({
    type: "GET",
    url: "/Home/GetUserSchool",
    contentType: "application/json; charset=utf-8",
    async: false,
    success: function (data) {
        if(data)
        {
            school = data;
        }
    },
    error: function (data) {
        if(!data)
        {
            window.alert("Failure getting school name");
        }   
    }
});
                
// Change background depending on school name
// Neutral background if null is returned
if (school == "ASU") {
    // ASU background
    document.getElementById('body').setAttribute("style", "background-color:#6c0018; padding-bottom: 85px;");
    document.getElementById('imgbg').setAttribute("src", "../Images/bg-asu2.png");
}
else if (school == "UofA") {
    // U of A background
    document.getElementById('body').setAttribute("style", "background-color:#003366; padding-bottom: 85px;");
    document.getElementById('imgbg').setAttribute("src", "../Images/bg-uofa2.png");
}
else {
    // undefined school
    document.getElementById('body').setAttribute("style", "background-color:#333333; padding-bottom: 85px;");
    document.getElementById('imgbg').setAttribute("style", "visibility:hidden;");
}

// After the game is complete an asynchronous AJAX call will be made to the UpdateUserScore method
// in the homecontroller.cs file. It sends an integer value to replace the current score table data found in 
// the UserProfile database. The user will then be redirected to the home page.
setInterval(function () {
    $.ajax({
        type: "GET",
        url: "/Home/UpdateUserScore",
        data: { score: totalScore },
        contentType: "application/json; charset=utf-8",
        success: function (data) {
        },
        error: function (data) {
            if(!data)
            {
                window.alert("Failure updating score");
            }   
        }
    });
    window.location.href = "http://localhost:60776/";
}, 65000);
setInterval(function ()
{
    popup('popUpDiv');
}, 61200);
</script>

<link href="~/Content/Board.css" rel="stylesheet" type="text/css" />
<h4>Find as many words as possible in ONE MINUTE!</h4>
<div style="text-align: center;">
<span id="countdown" class="timer">&nbsp;</span>
</div>

            
<script type="text/javascript">
    //Timer implementation. Updates countdown timer
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
        document.getElementById('countdown').setAttribute("style", "color:red;");
    } else {
        seconds--;
    }
}

var countdownTimer = setInterval('secondPassed()', 1000);