//Get all Orders in descending order
$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: '/Order/GetAllOrders',
        datatype: JSON,
        success: function (data) {
            $.each(data, function (i, row) {
                var newDate = new Date(row['orderDate']).toDateString();
                $("#ordersTable").append("<tr><td id='customerId'>" + row['customerId'] + "</td><td id='orderId'>" + row['orderId'] + "</td><td id='orderDate'>" + newDate + "</td><td class='text-center' id='orderTotal'>" + row['orderTotal'] + "</td><td><input class='btn btn-primary' type='button' id='viewOrder' value='More Details'/></td></tr>");
            })

        },
        error: function (data) { }
    });

    
});

//Get Orders according to the selected customer
$("#SelectedCustomerId").change(function () {
    $('#ordersTable tbody tr').remove();
    $.ajax({
        type: 'GET',
        url: '/Order/GetOrdersByCustomer?customerId=' + $(this).val(),
        datatype: JSON,
        success: function (data) {
            $.each(data, function (i, row) {
                var newDate = new Date(row['orderDate']).toDateString();
                $("#ordersTable").append("<tr><td id='customerId'>" + 
                    row['customerId'] + "</td><td id='orderId'>" +
                    row['orderId'] + "</td><td id='orderDate'>" +
                    newDate + "</td><td class='text-center' id='orderTotal'>" +
                    row['orderTotal'] +
                    "</td><td><input class='btn btn-primary' type='button' id='viewOrder' value='More Details'/></td></tr>");

            })

        },
        error: function (data) { }
    });
});

//On click view the Order details
$(document).on('click', '#viewOrder', function () {
    var $row = $(this).closest("tr");    // Find the row
    var $id = $row.find("#orderId").text(); // Find the text

    var url = "/Order/ViewDetails?orderId=" + $id;
    window.location.href = url;

});