$(document).ready(function() {
    $("#addButton").click(function() {
        Cars.addCar();
    });

    Cars.getCars();
});

Cars = {
    getCars: function() {
        $.ajax({
            type: "GET",
            url: "/api/cars",
            async: true,
            success: function(output, statis, xhr) {
                Cars.renderCars(output);

                $(".deleteButton").click(function () {
                    Cars.deleteCar();
                });
            },
            error: function() {
                console.log('error');
            }
        });
    },

    addCar: function() {
        var model = $("#Model").val();
        var price = $("#Price").val();

        $.ajax({
            type: "POST",
            url: "/api/cars",
            async: true,
            data: { Model: model, Price: price },
            success: function(output, statis, xhr) {
                Cars.getCars();
            },
            error: function() {
                console.log('error');
            }
        });
    },

    deleteCar: function () {
        var id = $(this).attr("id");

        $.ajax({
            type: "DELETE",
            url: "/api/cars/" + id,
            async: true,
            success: function (output, statis, xhr) {
                Cars.getCars();
            },
            error: function () {
                console.log('error');
            }
        });
    },

    renderCars: function(cars) {
        $('#cars').empty();
        $("#CarsTmpl").tmpl(cars).appendTo('#cars');
    }
}