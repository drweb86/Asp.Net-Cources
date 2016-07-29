var defaultPageBackground = "white";

function previewColor(color) {
    $(".body-content")[0].style.background = color;
}

function setColor(color) {
    defaultPageBackground = color;
    previewColor(defaultPageBackground);
}

function onSetColor(e) {
    var sender = (e && e.target) || (window.event && window.event.srcElement);
    setColor(sender.style.background);
}

function onPreviewColor(e) {
    var sender = (e && e.target) || (window.event && window.event.srcElement);
    previewColor(sender.style.background);
}

function onSetDefaultColor() {
    setColor(defaultPageBackground);
}

$(".ChangeColor").click(onSetColor);
$(".ChangeColor").mouseenter(onPreviewColor);
$(".ChangeColor").mouseleave(onSetDefaultColor);

