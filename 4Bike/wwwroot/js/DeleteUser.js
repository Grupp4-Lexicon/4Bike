$(".DeleteButton").on("click", function () {
    //if ($(this).parent().find(".hasOrderFlag").html() == "True") {
    const id = $(this).attr("data-userId");
    if ($(this).attr("data-hasOrderFlag") == "True") {
        if (confirm('This user has some orders. Do you want to delete user with the orders?')) {
            DoDelete(id);
        }
    } else {
        DoDelete(id);
    }
});

function DoDelete(id) {
    window.location.replace("/Role/DeleteUser/"+id);
}