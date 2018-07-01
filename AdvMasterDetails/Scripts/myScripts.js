//#region load Category
var Categories = [];
//fetch categories from database
function LoadCategory(element) {
    if (Categories.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: "/home/getProductCategories",
            success: function (data) {
                Categories = data;
                //render category
                renderCategory(element)
            }
        });
    } else {
        //render category to the element
        renderCategory(element)
    }
}

function renderCategory(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select..'));
    $.each(Categories, function (i, val) {
        $ele.append($('<option/>').val(val.CategoryID).text(val.CategoryName));
    });
}
//#endregion

//#region load product
//fetch productes
function LoadProduct(categoryDD) {
    $.ajax({
        type: "GET",
        url: "/home/getProducts",
        data: { categoryID: $(categoryDD).val() },
        success: function (data) {
            //rendar products to appropriate dropdown
            renderProduct($(categoryDD).parents(".mycontainer").find("select.product"), data);
        },
        error: function (error) {
            alert("Error Response");
            console.log(error);
        }
    });
}

function renderProduct(element, data) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select..'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.ProductID).text(val.ProductName));
    });
}
//#endregion

$(document).ready(function () {
    //#region Add button click event
    $("#add").click(function () {
        //validation and add order items
        var isAllValid = true;
        if ($('#productCategory').val() == "0" || $('#productCategory').val() == "") {
            isAllValid = false;
            $('#productCategory').siblings("span.error").css("visibility", "visible");
        } else {
            $('#productCategory').siblings("span.error").css("visibility", "hidden");
        }

        if ($('#product').val() == "0" || $('#product').val() == "") {
            isAllValid = false;
            $('#product').siblings("span.error").css("visibility", "visible");
        } else {
            $('#product').siblings("span.error").css("visibility", "hidden");
        }

        if (!($('#quantity').val().trim() != "" && (parseInt($("#quantity").val()) || 0)) ) {
            isAllValid = false;
            $('#quantity').siblings("span.error").css("visibility", "visible");
        } else {
            $('#quantity').siblings("span.error").css("visibility", "hidden");
        }

        if (!($('#rate').val().trim() != "" && !isNaN($("#rate").val().trim())) ) {
            isAllValid = false;
            $('#rate').siblings("span.error").css("visibility", "visible");
        } else {
            $('#rate').siblings("span.error").css("visibility", "hidden");
        }

        if (isAllValid) {
            var $newRow = $("#mainrow").clone().removeAttr("id");
            $(".pc", $newRow).val($("#productCategory").val());
            $(".product", $newRow).val($("#product").val());

            //Replace add button with remove button
            $("#add", $newRow).addClass("remove").val("Remove").removeClass("btn-success").addClass("btn-danger");

            $("#productCategory,#product,#quantity,#rate,#add", $newRow).removeAttr("id");
            $("span.error", $newRow).remove();

            //append clone row
            $("#orderdetailsItems").append($newRow);

            //clear select data
            $("#productCategory,#product").val("0");
            $("#quantity,#rate").val('');
            $("#orderItemError").empty();
        }
    });
    //#endregion

    //#region remove button click event
    $("#orderdetailsItems").on('click', '.remove', function () {
        $(this).parents("tr").remove();
    });
    //#endregion

    //#region submit button click event
    $("#submit").click(function () {
        var isAllValid = true;
        
        //validate order items
        $("#orderItemError").text("");
        var list = [];
        var errorItemCount = 0;
        $("#orderdetailsItems tr").each(function (index, ele) {
            if ($("select.product", this).val() == "0" ||
                (parseInt($(".quantity", this).val()) || 0) == 0 ||
                $(".rate", this).val() == "0" ||
                isNaN($(".rate", this).val())
                ) {
                errorItemCount++;
                $(this).addcl("error");
            } else {
                var orderItem = {
                    ProductID: $("select.product", this).val(),
                    Quantity: parseInt($(".quantity", this).val()),
                    Rate: parseFloat($(".rate", this).val())
                }
                list.push(orderItem);
            }
        });

        if (errorItemCount > 0) {
            $("#orderItemError").text(errorItemCount + " invalid entry in order item list.");
            isAllValid = false;
        }

        if (list.length==0) {
            $("#orderItemError").text("At least 1 order item required.");
            isAllValid = false;
        }

        if ($("#orderNo").val().trim() == "" ){
            $("#orderNo").siblings("span.error").css("visibility", "visible");
            isAllValid = false;
        } else {
            $("#orderNo").siblings("span.error").css("visibility", "hidden");
        }

        if ($("#orderDate").val().trim() == "") {
            $("#orderDate").siblings("span.error").css("visibility", "visible");
            isAllValid = false;
        } else {
            $("#orderDate").siblings("span.error").css("visibility", "hidden");
        }

        if (isAllValid) {
            var data = {
                OrderNo: $("#orderNo").val().trim(),
                OrderDateString: $("#orderDate").val().trim(),
                Description: $("#description").val().trim(),
                OrderDetails:list
            }
            $(this).val("Please wait...");

            $.ajax({
                type: "POST",
                url: "/home/save",
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (data) {
                    if (data.status) {
                        alert("Successfully saved");
                        //here we will clear the form
                        list = [];
                        $("#orderNo,#orderDate,#description").val("");
                        $("#orderdetailsItems").empty();
                    } else {
                        alert("Error");
                    }
                    $("#submit").text("Save");
                },
                error: function (error) {
                    alert("Error Response");
                    console.log(error);
                }
            });
        }
    });
    //#endregion

});


LoadCategory($("#productCategory"));