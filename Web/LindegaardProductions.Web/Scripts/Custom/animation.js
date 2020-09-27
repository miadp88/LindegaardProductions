$(document).ready(function () {

    const aniView = $('.aniview');
    if (aniView.length > 0) {
        aniView.AniView();
    }

    var x = $("#myTopnav");
    if (x.length > 0) {
        if (x.className === "topnav") {
            x.className += " responsive";
        } else {
            x.className = "topnav";
        }
    }
    AOS.init();
});