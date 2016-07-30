$(document).ready(function () {
    $('#LoadCarsButton').click(function () { Cars.getCars(false); });
});

Cars = {
    getCars: function(async) {
        $.ajax({
            async: async,
            url: "/Home/Cars",
            success: function (output, status, xmlHttpRequest) {
                $("#carsTemplate").tmpl(output).appendTo("#carsTable");//TODO:
            },
            error: function() {
                alert("Error");
            }
        });
    }
}