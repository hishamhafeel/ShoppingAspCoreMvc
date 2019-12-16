//On click view Order Item for a given Order Item ID
$(document).on('click', '#btnEditOrderItem', function () {
    var $row = $(this).closest("tr");    // Find the row
    var $id = $row.find("#OrderItemId").val(); // Find the text
    var url = "/Order/ViewOrderItem?orderItemId=" + $id;
    window.location.href = url;

});

//On click show delete confirmation modal
$(document).on('click', '#btnDeleteOrderItem', function () {
    var rowCount = $('tbody tr').length;
    if (rowCount == 1) {
        $('#errorMessage').html("<p>Order cannot be empty. There should be one or more order items in Order. </p>");
    }
    else if (rowCount > 1) {
        var $row = $(this).closest("tr");    // Find the row
        var $id = $row.find("#OrderItemId").val(); // Find the text
        // show Modal
        $('#myModal').modal('show');
        $('#orderIdOnDelete').append($id);
    }
});

//On click send POST request to delete Order Item
$(document).on('click', '#btnDeleteConfirmed', function () {
    var $id = $("#orderIdOnDelete").html(); 
    $.ajax({
        type: 'POST',
        url: '/Order/DeleteOrderItem',
        data: {
            orderItemId: $id
        },
        success: function (data) {
            $('#myModal').modal('hide');
            jQuery("#getCodeModal").modal('show');
        },
        error: function (data) { }
    });
});

//On click close the modal
$(document).on('click', '#btnCloseModal', function () {
    jQuery("#getCodeModal").modal('hide');
    var url = "/Order/Index";
    window.location.href = url;
    
});