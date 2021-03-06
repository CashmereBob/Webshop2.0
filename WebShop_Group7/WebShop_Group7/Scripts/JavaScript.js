﻿
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
           
        });


    });

    $(".delete").each(function (index) {

        $(this).bind('keyup mouseup', function () {
            deleteProduct($(this).attr('id'))


        });
    });
    
    UpdateCart();

    $('#showDD').on({
        
        "click": function (e) {
            var target = $(e.target);
            if (target.hasClass("btn-p")){
                this.closable = false;
                
            } else {
                this.closable = true;
                
            }
        },
        "hide.bs.dropdown": function () { return this.closable; }
    });

    getPayCar();

});

    




function UpdateCart() {

    var productsInCart = 1 - 1;
    var sum = "";
    var vat = "";

    if ($("#Cart").val() != "") {
        var cart = JSON.parse($("#Cart").val());
        sum = (cart.sum + 1) + "kr";
        vat = ((cart.sum + 1)*0.25) + "kr";

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
        $("#total").html(sum);
        $("#tax").html(vat);

        if (isPostback) {
            // Postback specific logic here
        } else {
            __doPostBack();
        }


        

     
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

        $("#total").html(sum);

        $("#tax").html(sum);
        $("#Cart").val(JSON.stringify(cart));
        localStorage.setItem('Cart', $("#Cart").val());
        
    }
    
}

function getPayCar() {

    if ($("#Cart").val() != "") {
        var cart = JSON.parse($("#Cart").val());
        cart.carrierID = $('input[name=carrier]:checked').val();
        cart.paymentID = $('input[name=payment]:checked').val();

        console.log($('input[name=carrier]:checked').val());

        $('input[name=payment]:checked').change(function () {
            cart.paymentID = $('input[name=payment]:checked').val();
            
        });
        $('input[name=carrier]:checked').change(function () {
            cart.carrierID = $('input[name=carrier]:checked').val();
            
        });
 
        $("#Cart").val(JSON.stringify(cart))
        localStorage.setItem('Cart', $("#Cart").val());
    }
}
