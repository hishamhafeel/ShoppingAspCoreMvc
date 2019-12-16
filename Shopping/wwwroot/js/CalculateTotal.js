$(document).ready(function () {
    //// if any of the qty or price inputs on the page change
    //$("#BuyQuantity, #ProductUnitPrice").change(function () {
        // find parent TR of the input being changed
        //var $row = $(this).closest('tr');

        //var a = $("#BuyQuantity").val();
        //var b = $row.find("#ProductUnitPrice").val();
        //var r = $row.find("#SubTotal").val(a * b);
    //});

    $('#tblOr tbody tr').each(function () {
            //var $row = $(this).closest('tr');
            var a = $("#BuyQuantity").val();
            var b = $("#ProductUnitPrice").val();
            var r = a * b;
            $("#SubTotal").val(r);


    });
});