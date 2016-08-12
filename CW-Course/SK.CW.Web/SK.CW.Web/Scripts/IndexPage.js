﻿$(document).ready(function () {
    $(".showDetails").click(function() {
        UsersManagement.ShowDetails($(this).attr("details-uid"));
    });
});


UsersManagement = {
    ShowDetails: function(detailsUid) {
        $.ajax({
            type: "GET",
            url: "/API/UserDetails/" + detailsUid,
            asynch: true,
            beforeSend: function () {
                $("#SelectedUserDetailsView").show();
                $("#SelectedUserInformation").html("Загрузка...");
            },
            success: function (output, status, xhr) {
                $("#SelectedUserInformation").html(
                    "Возраст: " + output.Age + "<br />" +
                    "Адрес: " + output.Address);
            },
            error: function () {
                $("#SelectedUserInformation").html("Не удается загрузить данные");
            }
        });
    }
}