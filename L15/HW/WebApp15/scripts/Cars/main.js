$(document).ready(function () {
    Cars.getCars();

    $("#ShowAddDialogBtn").on("click", function (evnt) {
            $(function () {
                $("#AddCarDialog").dialog({
                    modal: true,
                    title: "Add Car",
                    buttons: {
                        "Add Car": function () {
                            Cars.addCar();
                            $(this).dialog("close");
                        },
                        Cancel: function () {
                            $(this).dialog("close");
                        }
                    }
                });
            });
            evnt.preventDefault();
    });

});

Cars = {
    getCars: function () {
        $.ajax({
            type: 'GET',
            url: '/api/cars',
            asynch: true,
            success: function (output, status, xhr) {
                Cars.renderCars(output);
                $('.deleteBtn').click(Cars.deleteCar);
            },
            error: function () {
                console.log('error');
            }
        });
    },

    addCar: function () {
        var model = $('#Model').val();
        var price = $('#Price').val();
        //validation

        $.ajax({
            type: 'POST',
            url: "/api/cars",
            asynch: true,
            data: { Model: model, Price: price },
            success: function () {
                Cars.getCars();
            },
            error: function () {
                console.log('error');
            }
        });
    },

    renderCars: function (cars) {
        $('#cars').empty();
        $('#carsTmpl').tmpl(cars).appendTo('#cars');
    },

    deleteCar: function () {
        var id = $(this).attr("id");

        $.ajax({
            type: "DELETE",
            url: "/api/cars/" + id,
            asynch: true,
            success: function () {
                // update on ui
                Cars.getCars();
            },
            error: function () {
                console.log('error');
            }
        });
    }
}