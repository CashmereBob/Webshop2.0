
$(document).ready(function () {
    
    if (localStorage.getItem('Cart') != null) {
        $("#Cart").val(localStorage.getItem('Cart'));
    }

    $("#Cart").change(function () {
        localStorage.setItem('Cart', $("#Cart").val());
    });
    
    });




