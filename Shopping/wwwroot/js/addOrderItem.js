

//Auto-fill the dropdown for products
$(document).ready(function () {
    var products = [];
    var productList = $('#ProductId');

    $.ajax({
        url: '/Product/GetAllProducts',
        method: 'post',
        dataType: 'json',
        success: function (data) {
            var s = '<option value="-1">Select a Product</option>';
            products = data;
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].value + '" data-product-name="' + data[i].text + '">' + data[i].text + '</option>';
            }
            $("#ProductId").html(s);
        }
    });
});


//Populating the other fields of product in row according to the selected product
$(document).ready(function () {
    $("#ProductId").change(function () {
        $.ajax({
            type: 'GET',
            url: '/Product/GetProductById?productId=' + $(this).val(),
            datatype: JSON,
            success: function (data) {
                $('#ProductDescription').val(data.productDescription);
                $('#ProductPrice').val(data.productUnitPrice);

                $("#ProductQuantity").change(function () {
                    var qty = $(this).val();
                    var subTotal = qty * data.productUnitPrice;
                    $('#ProductSubTotal').val(subTotal);
                });
            },
            error: function (data) { }
        });
    });
});


//on click add item button populate next row with existing data
var GrandTotal = 0;
$("#AddOrderItem").click(function () {
    var productId = $('#ProductId').val();
    var productName = $('#ProductId').children(":selected").attr("data-product-name");
    //var productName = this.products.find(product => product.value == productId).value;
    var total = GrandTotal + parseInt($('#ProductSubTotal').val());
    //check if valid product is selected
    if ($('#ProductId').val() == "" || $('#ProductId').val() <= "0") {
        $('#ProductId').focus();
        $('#ProductId').css("border-color", "#ff0000");
        $('#errorMessageProduct').html("<p>Please select a product to add</p>");
        $('#errorMessageProduct').css("font-size", "12px");
    }
    //check if quantity added is valid
    else if (parseInt($('#ProductQuantity').val()) <= 0 || parseInt($('#ProductQuantity').val()) > 10 || $('#ProductQuantity').val() == "") {
        $('#ProductQuantity').focus();
        $('#ProductQuantity').css("border-color", "#ff0000");
        $('#errorMessageQty').html("<p>Please enter a valid quantity (1 - 10)</p>");
        $('#errorMessageQty').css("font-size", "12px");
    }
    //check if grand total is below 10000
    else if (total > 10000) {
        $('#errorMessageTotal').html("<p>Grand Total Must Be Less Than 10000 Rs To Make The Order </p>");
    }
    //execute if all validations are passed
    else {
        $('#orderItemsTable').append('<tr class="orderItemList text-center">' +
            '<td style="display:none;  data-table-head="Product">' + $('#ProductId').val() + '</td>' +
            '<td data-table-head="Product">' + productName + '</td>' +
            '<td data-table-head="Description">' + $('#ProductDescription').val() + '</td>' +
            '<td data-table-head="Price">' + $('#ProductPrice').val() + '</td>' +
            '<td data-table-head="Quantity">' + $('#ProductQuantity').val() + '</td>' +
            '<td data-table-head="Subtotal">' + $('#ProductSubTotal').val() + '</td>' +
            '<td class="actions" data-table-head=""><input type="button" class="btn btn-danger" id="removeItem" value="Remove Item">' +
                '<input type="hidden" id="ProductId" value="" />' +
            '<input type="hidden" id="ProductAvailableStock" value="" /></td></tr>');

        GrandTotal = GrandTotal + parseInt($('#ProductSubTotal').val());
        $('#GrandTotal').val(GrandTotal);
       
        $('#ProductQuantity').css("border-color", "#c0c0c0");
        $('#ProductId').css("border-color", "#c0c0c0");
        $('#ProductId').val('-1');
        $('#ProductDescription').val('');
        $('#ProductPrice').val('');
        $("#ProductQuantity").val('');
        $('#ProductSubTotal').val('');
        
        //$('.orderLine1 input[type="text"],input[type="number"]').val('');

        $('#errorMessageQty').html("");
        $('#errorMessageProduct').html("");
        $('#errorMessageTotal').html("");
    }
});


//On click remove item from table of order items
$(document).on('click', '#removeItem', function (e) {
    GrandTotal = GrandTotal - parseInt($(this).parents('tr').find("td:eq( 5 )").html());
    $('#GrandTotal').val(GrandTotal.toString());
    $(this).parents('tr').first().remove();
});

//On click send POST request to create order and order items
$('#SaveOrders').click(function (e) {
    var orderDate = $('#OrderDate').val();
    var customerId = $('#CustomerId').val();
    var orderTotal = $('#GrandTotal').val();
    if (orderTotal > 0) {
        var array = [];
        var headers = ["ProductId", "Quantity", "SubTotal"];
        //Populate array with product id, quantity and subtotal
        $('#orderItemsTable .orderItemList').each(function () {
            var arrayItem = {};
            var headersIndex = 0;
            $('td', $(this)).each(function (index, item) {
                if (index == 0 || index == 4 || index == 5) {
                    arrayItem[headers[headersIndex]] = $(item).html();
                    headersIndex++;
                }
            });
            array.push(arrayItem);
        });
        $.ajax({
            type: "POST",
            url: "/Order/AddOrder",
            data: {
                CustomerId: customerId,
                OrderDate: orderDate,
                OrderItems: array,
                OrderTotal: orderTotal
            },
            success: function (result) {
                if (result.success) {
                    window.location.href = '/Order/Index'
                } else {
                    for (var error in result.errors) {
                        $('#errorMessageTotal').append(result.errors[error] + '<br />');
                    }
                }
            },
        });
    } else {
        $('#errorMessageTotal').html("<p>Please Add An Item To Cart</p>");
    }
});



