$(document).ready(function () {
    $(".PricelessLink").click(function () {
        Shops.getShopDetail(true, $(this).attr("argument"));
    });

    $(".ShowTable").click(function () {
        Shops.showTable(true, $(this).attr("argument"));
    });
    
    Shops.showTable(true, "");
});

Shops = {
    getShopDetail: function (async, priceless) {
        $.ajax({
            async: async,
            url: "/Home/Priceless?price=" + priceless,
            success: function (output, status, xmlHttpRequest) {
                $("#MostValuebleView").show();
                $("#GoodsView").hide();

                $("#MostValuebleView")[0].innerText = output.Title;

                
            },
            error: function () {
                alert("Error");
            }
        });
    },

    showTable: function (async, priceless) {
        $.ajax({
            async: async,
            url: "/Home/GetTable?price=" + priceless,
            success: function (output, status, xmlHttpRequest) {
                $("#MostValuebleView").hide();
                $("#GoodsView").show();

                $('#AllGoods').empty();
                $("#GoodsTmpl").tmpl(output).appendTo('#AllGoods');
                
                
            },
            error: function () {
                alert("Error");
            }
        });
    }
}

//Priceless