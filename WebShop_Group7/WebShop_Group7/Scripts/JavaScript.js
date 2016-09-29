
$(document).ready(function () {
    
    if (localStorage.getItem('Cart') != null && $("#Cart").val() == "") {
        $("#Cart").val(localStorage.getItem('Cart'))
    }
    else {
        localStorage.setItem('Cart', $("#Cart").val());
    }
    
    UpdateCart()
    
    });




function UpdateCart() {


    var productsInCart = 0;
    var sum = "";



    if ($("#Cart").val() != ""){
        var cart = JSON.parse($("#Cart").val());
        sum = cart.sum + "kr";

        for (var i = 0 ; i < cart.products.length; i++) {

            productsInCart += cart.products[i].quantity;

            
          

        }



    }
    
   
    if (productsInCart < 10) {
        $("#numProducts").css('padding', '5px 8px');
    } else {
        $("#numProducts").css('padding', '5px');
    }

    if (productsInCart == 0) {
        $("#numProducts").removeClass("numProducts");
        $("#cartIcon").removeClass("cartIcon");
       
    } else {
        $("#cartIcon").addClass("cartIcon");
        $("#numProducts").addClass("numProducts");
        $("#numProducts").html(productsInCart);
        $("#priceSum").html(sum);
        $("#updKnapp").removeClass("hide");
       
    }
}


