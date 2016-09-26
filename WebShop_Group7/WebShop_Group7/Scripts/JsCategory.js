
$(document).ready(function () {

    $("#masterwrap").append($("</div></div></div>"));
    $(".filter").click(function () {
        filter($(this).val());
    });

    fillChecked();
    

});

function filter(val) {

    var string = "?filter=";
    var id = "";

    if (getUrlParameter('id') !== null) {
        string = "&filter="
        id = "?id=" + getUrlParameter('id');
    } 

    if (getUrlParameter('filter') !== null) {
        string = "&filter=";
    }

    $(".filter").each(function (index) {

        if ($(this).is(':checked')) {
        
            string += ":" + $(this).val()
            
        
        }

            
    });

    var url = window.location.origin + window.location.pathname + id + string;
    window.location.href = url;

}

function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};

function fillChecked() {

    if (getUrlParameter('filter') !== null) {
        var filter = getUrlParameter('filter').split(":");

        for (i = 0; i < filter.length; i++) {

            $(".filter").each(function (index) {

                if ($(this).val() == filter[i]) {

                    $(this).prop('checked', true);


                }


            });


        }

    }


}