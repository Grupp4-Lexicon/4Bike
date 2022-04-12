function editOrder(boId,bId,oId) {
    console.log(boId, oId, bId, $("input[name='" + boId + "']").val())
    $.post("/Home/UpdateOrder", { BikeOrderID: boId, BikeOrderQuantity: $("input[name='"+boId+"']").val(), BikeOrderBikeID: bId, BikeOrderOrderID: oId}, function (result) {
        document.getElementById("orders").innerHTML = result;
    });
}
function deleteOrder(boId) {
    console.log(boId)
    $.post("/Home/RemoveBikeOrder", { boId: boId}, function (result) {
        document.getElementById("orders").innerHTML = result;
    });
}
function serchProd() {
    console.log($("input[name='seartch']").val());
    $.post("/Bike/SertchBike", { sertchBike: $("input[name='seartch']").val() }, function (result) {
        document.getElementById("serRes").innerHTML = result;

    });
}
function userViews() {
    $.post("/Home/ViewOrder", function (result) {
        if (document.getElementById("orders")) {
            document.getElementById("orders").innerHTML = result;
        }
    });
}
function userSertch() {
    $.post("/Home/ViewOrder", { userName: $("input[name='userSertch']").val(), orderDate: $("input[name='oDate']").val()}, function (result) {
        document.getElementById("orders").innerHTML = result;
    });
}
function loadImg(event) {
    var image = document.getElementById('fileIMG');
    image.src = URL.createObjectURL(event.target.files[0]);
}