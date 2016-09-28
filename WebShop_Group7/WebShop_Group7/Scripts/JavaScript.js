
$(document).ready(function () {
    
    if (sessionStorage.getItem('cart') == null) {

        var obj = "";
        sessionStorage.setItem('cart', obj)
    }
    
    
    });

function AddToCart(product) {

    var attribut = "";

    $(".filter").each(function (index) {
        attribut += $(this).val() + ",";
    });

    var quantity = $("#quantity").val();

    var obj = sessionStorage.getItem('cart');

    if (obj.indexOf(obj + '-id=' + product + ':atr=' + attribut + ':q=') >= 0) {

        var res = obj.split('-');
        var sub;
        var quantity = 0
        res.each(function (index) {

            if ($(this).indexOf(obj + '-id=' + product + ':atr=' + attribut + ':q=') >= 0) {
                sub = obj.split(':');
            }
        });




        obj.replace("Microsoft", "W3Schools");
    }

    var obj = obj + '-id=' + product + ':atr=' + attribut + ':q=' + quantity;


    sessionStorage.setItem('cart', obj)
    console.log(sessionStorage.getItem('cart'));

}

