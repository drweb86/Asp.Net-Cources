var defaultPageBackground = "white";

function previewColor(color) {
    $(".body-content")[0].style.background = color;
}

function setColor(color) {
    defaultPageBackground = color;
    previewColor(defaultPageBackground);
}

function onSetYellowColor() {
    setColor("yellow");
}
function onSetBlueColor() {
    setColor("blue");
}
function onSetGreenColor() {
    setColor("green");
}

function onPreviewYellowColor() {
    previewColor("yellow");
}
function onPreviewBlueColor() {
    previewColor("blue");
}
function onPreviewGreenColor() {
    previewColor("green");
}


function onSetDefaultColor() {
    setColor(defaultPageBackground);
}

$("#SetYellowDiv").click(onSetYellowColor);
$("#SetYellowDiv").mouseenter(onPreviewYellowColor);
$("#SetYellowDiv").mouseleave(onSetDefaultColor);

$("#SetBlueDiv").click(onSetBlueColor);
$("#SetBlueDiv").mouseenter(onPreviewBlueColor);
$("#SetBlueDiv").mouseleave(onSetDefaultColor);

$("#SetGreenDiv").click(onSetGreenColor);
$("#SetGreenDiv").mouseenter(onPreviewGreenColor);
$("#SetGreenDiv").mouseleave(onSetDefaultColor);
