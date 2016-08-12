$(document).ready(function () {
    $(".showDetails").click(function() {
        UsersManagement.ShowDetails($(this).attr("details-uid"));
    });
    
    $(function () {
        $("#ConfirmDialogView").dialog({
            resizable: false,
            height: "auto",
            width: 400,
            modal: true,
            autoOpen:false,
            buttons: {
                "Удалить": function () {
                    UsersManagement.DeleteUser($("#ConfirmDialogView").data("user-uid"));
                    $(this).dialog("close");
                },
                "Отмена": function () {
                    $(this).dialog("close");
                }
            }
        });
    });

    $(".deleteUser").click(function () {
        $('#ConfirmDialogView')
            .data("user-uid", $(this).attr("user-uid"))
            .dialog("open");
    });

    $("tr").not(':first').hover(
          function () {
              $(this).css("background", "lightgreen");
          },
          function () {
              $(this).css("background", "");
          }
    );
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
    },

    DeleteUser: function (userUid) {
        $.ajax({
            type: "DELETE",
            url: "/API/User/" + userUid,
            asynch: true,
            success: function (output, status, xhr) {
                $("#User-" + userUid + "-Row").remove();
            },
            error: function () {
                $("#SelectedUserInformation").html("Не удается загрузить данные");
            }
        });
    }
}
