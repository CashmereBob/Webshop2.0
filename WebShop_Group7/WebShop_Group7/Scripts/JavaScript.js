
$(document).ready(function () {
    
    if (localStorage.getItem('Cart') != null && $("#Cart").val() == "") {
        $("#Cart").val(localStorage.getItem('Cart'))
    }
    else {
        localStorage.setItem('Cart', $("#Cart").val());
    }

    

    $(".quantity").each(function (index) {

        $(this).bind('keyup mouseup', function () {
            changeProduct($(this).attr('id'), $(this).val())
            console.log('change');

        });
    });

    $(".delete").each(function (index) {

        $(this).bind('keyup mouseup', function () {
            deleteProduct($(this).attr('id'))


        });
    });
    
    UpdateCart()

    $('#showDD').on('hide.bs.dropdown', function () {
        return false;
    });

});

    




function UpdateCart() {

    var productsInCart = 0;
    var sum = "";

    if ($("#Cart").val() != "") {
        var cart = JSON.parse($("#Cart").val());
        sum = (cart.sum + 1) + "kr";

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

function deleteProduct(id) {

    if ($("#Cart").val() != "") {
        var cart = JSON.parse($("#Cart").val());
       
        for (var i = 0 ; i < cart.products.length; i++) {

            if (cart.products[i].ID == id) {
                cart.products[i].quantity = 0;
            }

        }
        $("#Cart").val(JSON.stringify(cart))
        localStorage.setItem('Cart', $("#Cart").val());
    }



}

function changeProduct(id, quantity) {

    var sum = "";

    if ($("#Cart").val() != "") {
        var cart = JSON.parse($("#Cart").val());
        sum = (cart.sum + 1) + "kr";
        for (var i = 0 ; i < cart.products.length; i++) {

            if (cart.products[i].ID == id) {
                cart.products[i].quantity = quantity;
            }

        }

        $("#priceSum").html(sum);
        $("#Cart").val(JSON.stringify(cart));
        localStorage.setItem('Cart', $("#Cart").val());
        
    }
    
}

