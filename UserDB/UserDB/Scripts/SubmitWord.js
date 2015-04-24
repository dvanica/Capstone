function submitWord() {
    //Pull IDS of letters to transmit as "word"
    var fullWord = letters.join("");
    var newScore = wordScore;

    $.ajax({
        type: "GET",
        url: "/Board/checkWord",
        data: { word: fullWord },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            //$('.processedWord').html(fullWord);
            finishSubmit(result, fullWord, newScore);
        },
        error: function (data) {
            //$('.processedWord').html(fullWord);
            window.alert("Failure");
        }
    });
}

function finishSubmit(result, word, score) {
    if (result) {
        // Jquery to set the last submitted word and the score
        $("#ws").text("Last Word Score: " + score);
        $("#lsw").text("Last Sumitted Word: " + word);
        for (var i = 0; i < wordIds.length; i++) {
            document.getElementById(wordIds[i]).disabled = true;
            document.getElementById(wordIds[i]).setAttribute("style", "visibility:hidden;");
            //document.getElementById(wordIds[i]).setAttribute("style", "background-color:maroon; color:gold;");
        }

    }
    else {
        score = 0;
        // Jquery to set the last submitted word and the score 
        $("#ws").text("Last Word Score: 0");
        $("#lsw").text("Last Sumitted Word: " + word);
        for (var i = 0; i < wordIds.length; i++) {
            document.getElementById(wordIds[i]).setAttribute("style", "background-color:white; color:black;");
            document.getElementById(wordIds[i]).setAttribute("data-owner", "EMPTY");
        }
    }

    letters = [];
    wordIds = [];
    totalScore += score;
    // Jquery to select total score label and modify it
    $("#ts").text("Total Score: " + totalScore);
    wordScore = 0;
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
            if (!data) {
                window.alert("Failure updating score");
            }
        }
    });
    window.location.href = "http://localhost:60776/";
}, 63000);
//setInterval(function () {
//    popup('popUpDiv');
//}, 61200);