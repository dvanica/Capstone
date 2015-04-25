﻿// Synchronous AJAX call to get the user's university name and change the background of the 
// game board accordingly. The GetUserSchool method is a HTTPGet method found in the homecontroller.cs
// file. If the GetUserSchool Method returns null, an alert view will be present. 
var school = "undefined";
$.ajax({
    type: "GET",
    url: "/Home/GetUserSchool",
    contentType: "application/json; charset=utf-8",
    async: false,
    success: function (data) {
        if (data) {
            school = data;
        }
    },
    error: function (data) {
        if (!data) {
            window.alert("Failure getting school name");
        }
    }
});
var width = screen.width;
// Change background depending on school name
// Neutral background if null is returned
if (school == "ASU") {
    // ASU background
    document.getElementById('body').setAttribute("style", "background-color:#6c0018; padding-bottom: 85px;");
    if (width > 1024)
    {
        document.getElementById('imgbg').setAttribute("src", "../Images/bg-asu2.png");
    }
}
else if (school == "UofA") {
    // U of A background
    document.getElementById('body').setAttribute("style", "background-color:#003366; padding-bottom: 85px;");
    if (width > 1024)
    {
        document.getElementById('imgbg').setAttribute("src", "../Images/bg-uofa2.png");
    }
}
else {
    // undefined school
    document.getElementById('body').setAttribute("style", "background-color:#333333; padding-bottom: 85px;");
    document.getElementById('imgbg').setAttribute("style", "visibility:hidden;");
}