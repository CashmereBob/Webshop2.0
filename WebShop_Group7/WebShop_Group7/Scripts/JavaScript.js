
$(document).ready(function () {
    
    if (localStorage.getItem('Cart') != null && $("#Cart").value() == null) {
        $("#Cart").value(localStorage.getItem('Cart'))
    } else {
        localStorage.setItem('Cart', $("#Cart").val());
    }
    
    
    });




