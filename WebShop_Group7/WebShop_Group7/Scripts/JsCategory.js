
$(document).ready(function () {

    $("#masterwrap").append($("</div></div></div>"));
    $("#filterButton").click(function () {
        filter();
    });
    

});

function filter() {

    var string = "?filter="

    if (getUrlParameter('id') > 0) {
        string = "&filter="
    }


    $(".filter").each(function (index) {

        if ($(this).is(':checked')) {
        
            string += ":" + $(this).val()
            
        
        }

            
    });
    window.location.href = window.location.href + string;

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