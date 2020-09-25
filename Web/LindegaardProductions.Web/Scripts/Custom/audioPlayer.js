

const audioPlayer = $(".audio-player");
const audioPlayerSrc = $("#audio-player__src");
const audioNumbers = $(".audioNumber");
if (audioPlayer.length > 0) {
    audioNumbers.each(function () {
        $(this).on("click", function (e) {
            let src = $(this).attr("data-music-src");
            audioPlayerSrc.attr("src", src)[0];
            audioPlayer[0].pause();
            audioPlayer[0].load();
            audioPlayer[0].play();
        });
    });
}