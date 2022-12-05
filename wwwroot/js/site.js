//Site Specific Works
$(document).ready(function () {
    UpdateCartCountInUi();

    /////////////////////////////////Load All Cart Element From Cookey WIth Updated Price From Server - Start
    if ($('#cart_items_list').length > 0) {
        var cart = GetCart();
        var idList = [];
        var countList = [];
        var formSelector = "#cart_items_list_wrapper";
        for (var i in cart) {
            idList.push(cart[i][0]);
            countList.push(cart[i][1]);
            AddRowForItem(formSelector, cart[i][0], cart[i][1], i);
        }
        console.log(idList);
        console.log(countList);
        $('form#cart_items_list').submit(function (e) {
            e.preventDefault(); // Stop the form submitting
            $.ajax({
                type: "POST",
                url: $(this).attr('action'),
                data: $(this).serialize(), // serializes the form's elements.
                success: function (data) {
                    ClearCart();
                    alert("Order Placed Successfully !");
                    window.location.replace($('meta[name=redirect-url]').attr('content'));
                    //location.reload();
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert("Data Update Failed !");
                    console.log(xhr.status);
                    console.log(thrownError);
                }
            });
            //e.currentTarget.submit();// Now submit it
        });
        //e.preventDefault(); // avoid to execute the actual submit of the form.
        //$.ajax({
        //    type: "POST",
        //    url: $('#cart_items_list').attr('action'),
        //    data: $(this).serialize(), // serializes the form's elements.
        //    success: function (data) {
        //        console.log("Data Updated Successfully !");
        //        //location.reload();
        //    },
        //    error: function (xhr, ajaxOptions, thrownError) {
        //        alert("Data Update Failed !");
        //        console.log(xhr.status);
        //        console.log(thrownError);
        //    }
        //});
	}
    /////////////////////////////////Load All Cart Element From Cookey WIth Updated Price From Server - End

    /////////////////////////////////Datatable for Showing Products
    if ($('#all-products-datatable').length > 0) {
        //Datatable with ID exists
        $('#all-products-datatable').DataTable({
            bLengthChange: true,
            lengthMenu: [[5, 10, 50, 100, -1], [5, 10, 50, 100, "All"]],
            bFilter: true,
            bSort: true,
            bPaginate: true,
            "processing": true,
            "serverSide": true,
            "filter": true,
            "ajax": {
                "url": $('meta[name=datatable-url]').attr('content'),
                "type": "POST",
                "datatype": "json"
            },
            //"columnDefs": [{
            //    "targets": [4],
            //    "visible": true,
            //    "searchable": false,
            //    "orderable": false
            //}],
            "columns": [
                { "data": "name", "name": "Name", "autoWidth": true },
                { "data": "unitPrice", "name": "Unit Price", "autoWidth": true },
                {
                    "data": "id",
                    "name": "Id",
                    "render": function (data, row) {
                        var viewUrl = $('meta[name=view-url]').attr('content').slice(0, -1) + data;
                        var editUrl = $('meta[name=edit-url]').attr('content').slice(0, -1) + data;
                        var deleteUrl = $('meta[name=delete-url]').attr('content').slice(0, -1) + data;
                        var html = '<div class="btn-group" role="group" aria-label="Action"> <a href = "' + viewUrl + '" class="btn btn-primary" >View</a> <a href="' + editUrl + '" class="btn btn-warning">Edit</a> <a href="' + deleteUrl + '" class="btn btn-danger">Delete</a></div >';
                        //return "<a href='#' class='btn btn-danger' onclick=DeleteCustomer('" + data + "'); >Delete</a>";
                        return html;
                    },
                    "searchable": false,
                    "orderable": false
                }
            ]
        });
    }
    /////////////////////////////////////////

    /////////////////////////////////Datatable for Ordering Products
    if ($('#order-products-datatable').length > 0) {
        //Datatable with ID exists
        $('#order-products-datatable').DataTable({
            bLengthChange: true,
            lengthMenu: [[5, 10, 50, 100, -1], [5, 10, 50, 100, "All"]],
            bFilter: true,
            bSort: true,
            bPaginate: true,
            "processing": true,
            "serverSide": true,
            "filter": true,
            "ajax": {
                "url": $('meta[name=datatable-url]').attr('content'),
                "type": "POST",
                "datatype": "json"
            },
            "columns": [
                { "data": "name", "name": "Name", "autoWidth": true },
                { "data": "unitPrice", "name": "Unit Price", "autoWidth": true },
                {
                    "data": "id",
                    "name": "Id",
                    "render": function (data, row) {
                        var viewUrl = $('meta[name=view-url]').attr('content').slice(0, -1) + data;
                        var editUrl = $('meta[name=edit-url]').attr('content').slice(0, -1) + data;
                        var deleteUrl = $('meta[name=delete-url]').attr('content').slice(0, -1) + data;
                        var html = '<div class="btn-group" role="group" aria-label="Action"> <a href = "#" class="btn btn-success" onclick=AddProductToCart("' + data + '");>+</a> <a href="#" class="btn btn-danger"  onclick=DeleteProductToCart("' + data + '");>-</a></div >';
                        //return "<a href='#' class='btn btn-danger' onclick=DeleteCustomer('" + data + "'); >Delete</a>";
                        return html;
                    },
                    "searchable": false,
                    "orderable": false
                }
            ]
        });
    }
    /////////////////////////////////////////
});

function AddProductToCart(productId, changeVal = 1) {
    var cart = GetCart();
    cart = UpdateCart(cart, productId, changeVal, "Add");
};

function DeleteProductToCart(productId, changeVal = 1) {
    var cart = GetCart();
    cart = UpdateCart(cart, productId, changeVal, "Remove");
};

function GetArrayFromCookie(cartValueString) {      //Dictonary convertion adds a new layer of complexity, so saved with only array
    var output = [];
    var tempId = "";
    cartValueString.split(",").forEach(function (val, index, array) {
        //console.log(val, index, array);
        if (index % 2 == 0) {
            tempId = val;
		}
        else {
            output.push([tempId, parseInt(val)]);
        }
    });
    return output;
}

function GetCart() {
    var cart;
    try {
        cart = $.cookie("cart");
        if (cart === undefined || cart === null) {
            throw new Error('Cart Does Not Exists');
        }
        cart = GetArrayFromCookie(cart);
    }
    catch (err) {
        cart = [];
        //cart.push(["asdasd-asdasd-asd-asd-asd-asd", 2]);
        //cart.push(["asdasd-asdasd-asd-asd-asd-asx", 3]);
        //cart.push(["asdasd-asdasd-axd-asd-asd-asx", 6]);
        $.cookie("cart", cart); //Set Cart Value
    }
    //console.log(cart);
    return cart;
};

function ClearCart() {
    $.cookie("cart", []);
    UpdateCartCountInUi();
};

function UpdateCartCountInUi(cart = null) {
    var cartCount = 0;
    if (cart == null) {
        cart = GetCart();
	}
    try {
        cart.forEach((item, index) => {
            cartCount += item[1];
        });
    }
    catch (err) {
        console.log(err);
    }
    $('#cart_count').attr('value', cartCount);
};

function UpdateCart(cart, productId, changeVal, action) {
    changeVal = Math.abs(changeVal);
    var index = FindIndexOfElement(cart, productId);
    //console.log(index);
    switch (action) {
        case "Add":
            if (index > -1) {
                cart[index][1] = cart[index][1] + changeVal;
            }
            else {
                cart.push([productId, changeVal]);
			}
            break;
        case "Remove":
            if (cart[index][1] > changeVal && index > -1) {
                cart[index][1] = cart[index][1] - changeVal;
            }
            else if (index > -1) {
                if (index > -1) { // only splice array when item is found
                    cart.splice(index, 1); // 2nd parameter means remove one item only
                }
			}
            break;
        default:
            break;
    }
    //Update to Cookie
    $.cookie("cart", cart);
    // Update Cart Count
    UpdateCartCountInUi(cart);
    //console.log(cart);
    return cart;
}

function FindIndexOfElement(cart, productId) {
    var targetIndex = -1
    cart.forEach((item, index) => {
        //console.log(item[0], productId);
        //console.log(item[0] == productId);
        if (item[0] == productId) {
            targetIndex = index;    //Return last found index
        }
    });
    return targetIndex;
}

function AddRowForItem(formSelector, itemId, itemCount, index) {
    var text = '<div class="row"><div class="col-md-8 mb-6"><div class="form-outline"><input type="text" name="id[' + index + ']" class="form-control form-control-lg" value="' + itemId + '" readonly /><label class="form-label" for="ProdName">Product Id</label></div></div><div class="col-md-4 mb-3"><div class="form-outline"><input type="text" name="count[' + index +']" class="form-control form-control-lg" value="' + itemCount + '" readonly /><label class="form-label" for="Count">Count</label></div></div></div>';
    $(formSelector).append(text);
}