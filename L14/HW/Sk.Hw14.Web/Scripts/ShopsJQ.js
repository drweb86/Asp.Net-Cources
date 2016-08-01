$(document).ready(function () {
    $(".AboutShop").click(function(e) {
        var sender = (e && e.target) || (window.event && window.event.srcElement);
        Shops.getShopDetail(true, sender.id.substr(5));
    });
});

Shops = {
    getShopDetail: function(async, id) {
        $.ajax({
            async: async,
            url: "/Home/ShopDetail/" + id,
            success: function (output, status, xmlHttpRequest) {
                $("#SelectedShop")[0].innerText = output.Name;
                $("#SelectedShopDescription")[0].innerText = output.Description;
            },
            error: function() {
                alert("Error");
            }
        });
    }
}