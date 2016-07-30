$(document).ready(function() {
    $('#LoadCarsButton').click(function () { Cars.getCarsAsync(); });
});

Cars = {
    renderCars: function(cars) {
        var result = "<tr>";
        result += "<td>Model</td>";
        result += "<td>Color</td>";
        result += "</tr>";

        for (var i = 0; i < cars.length; i++) {
            result += "<tr>";
            result += "<td>" + cars[i].Model + "</td>";
            result += "<td>" + cars[i].Color + "</td>";
            result += "</tr>";
        }

        document.getElementById('carsTable').innerHTML = result;
    },

    getXmlHttpRequest: function() {
        var xmlhttp;
        try {
            xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (ex) {
                xmlhttp = false;
            }
        }
        if (!xmlhttp && typeof XMLHttpRequest != 'undefined') {
            xmlhttp = new XMLHttpRequest();
        }
        return xmlhttp;
    },

    getCarsSync: function() {
        var xmlHttp = this.getXmlHttpRequest();
        xmlHttp.open('GET', '/Home/Cars', false); // /Home/Cars?p=13 ...
        xmlHttp.send(null); //for get.

        if (xmlHttp.status == 200) {
            document.getElementById('carsTable').innerHTML = xmlHttp.responseText;
        }
    },


    getCarsAsync: function() {
        //var xmlHttp = this.getXmlHttpRequest();
        //xmlHttp.open('GET', '/Home/Cars', true);// /Home/Cars?p=13 ...

        //xmlHttp.onreadystatechange = function() {
        //    if (xmlHttp.readyState == 4) {
        //        if (xmlHttp.status == 200) {
        //            document.getElementById('carsTable').innerHTML = xmlHttp.responseText;
        //        }
        //    }
        //};

        //xmlHttp.send(null);


        var xmlHttp = this.getXmlHttpRequest();
        xmlHttp.open('GET', '/Home/Cars', true); // /Home/Cars?p=13 ...

        xmlHttp.onreadystatechange = function() {
            if (xmlHttp.readyState == 4) {
                if (xmlHttp.status == 200) {
                    var cars = JSON.parse(xmlHttp.responseText);
                    Cars.renderCars(cars);
                }
            }
        };

        xmlHttp.send(null);
    },


    
}