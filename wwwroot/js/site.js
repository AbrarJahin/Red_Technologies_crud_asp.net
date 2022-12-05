//Site Specific Works
$(document).ready(function () {

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


});