$(document).ready(function () {

    const aniView = $('.aniview');
    if (aniView.length > 0) {
        aniView.AniView();
    }

    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }

    AOS.init();
});