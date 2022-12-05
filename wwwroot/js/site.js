﻿//Site Specific Works
$(document).ready(function () {
    UpdateCartCountInUi();

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