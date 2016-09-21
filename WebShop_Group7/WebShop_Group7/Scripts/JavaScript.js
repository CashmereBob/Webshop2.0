
$(document).ready(function () {
    $('#Usern').val(sessionStorage.getItem('User'));
    $('#Password').val(sessionStorage.getItem('Password'));

    
    $.ajax({
        type: "POST",
        url: "List_Order.aspx/ValidUser",
        data: "{ foo: '" + foo + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: "true",
        cache: "false",
        success: function (msg) {
            alert("Yeey")               
        },
        Error: function (x, e) {
            aler("Error")
        }
    });

    });
