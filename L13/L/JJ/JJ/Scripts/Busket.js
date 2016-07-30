$(document).ready(function() {
    $("#add").click(function() {
        Busket.add();
    });

    $("#remove").click(function () {
        Busket.remove();
    });
});



Busket = {
    count: 0,

    add: function () {
        Busket.count++;

        var countLabel = document.getElementById("count");
        countLabel.innerText = Busket.count;
    },

    remove: function() {
        Busket.count--;

        $("$count")[0].innerText = Busket.count;
        //var countLabel = document.getElementById("count");
        //countLabel.innerText = Busket.count;
    }

}