function removeFromShopingCart( RId) {
    $.post("Home/RemoveFromShopingKart", { bID: RId }, function (result) {

    }


    );
}
function serchProd() {
    console.log($("input[name='seartch']").val());
    $.post("Bike/SertchBike", { sertchBike: $("input[name='seartch']").val() }, function (result) {
        document.getElementById("serRes").innerHTML = result;

    });
}