$(document).ready(function() {
    $.getJSON("JSON/Offers.json", function(Offers, status) {
        if (status == "success") {
            var Offer_Str = ""
            $.each(Offers, function(index, Data) {
                Offer_Str = Offer_Str + (
                    "<div class='col'>" +
                    "<div class='card h-100'>" +
                    "<img src='" + Data.Offer_Img + "' class='card-img-top'>" +
                    "<div class='card-body'>" +
                    "<div class='card-title mb-2'>" + Data.Offer_Title + "</div>" +
                    "<div class='card-text text-muted mb-2'>" + Data.Offer_Discription + "</div>" +
                    "<a href='#' class='card-link text-primary'>T&Cs</a>" +
                    "</div>" +
                    "</div>" +
                    "</div>");
            });
            console.log(Offer_Str);
            $("#Offer_List").html(Offer_Str);
        }
    });
});

function clearUserData() {
    localStorage.clear();
}