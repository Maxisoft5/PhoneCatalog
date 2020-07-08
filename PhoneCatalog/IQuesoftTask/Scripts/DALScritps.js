<script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
<script src="https://cdn.datatables.net/1.10.15/js/dataTables.bootstrap.min.js"></script>
var Popup, dataTable;
$.extend($.fn.dataTable.defaults, {
    searching: false,
    paging: false,
    info: false
});
$(document).ready(function () {
    dataTable = $("#productTable").DataTable({
        "ajax": {
            "url": "/Home/GetProducts",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Name" },
            { "data": "ManufacturerName" },
            { "data": "DateManufacture" },
            { "data": "Price" },
            { "data": "BranchId" },
            {
                "data": "Id", "render": function (data) {
                    return "<a class='btn btn-danger btn-sm' style='margin-left:5px' onclick=Delete(" + data + ")><i class='fa fa-trash'></i> Delete</a>";
                },
                "orderable": false,
                "searchable": false,
                "width": "150px"
            }
        ],
        "language": {

            "emptyTable": "No data found, Please click on <b>Add New</b> Button"
        }
    });
});

function PopupForm(url) {
    var formDiv = $('<div />');
    $.get(url)
        .done(function (response) {
            formDiv.html(response);

            Popup = formDiv.dialog({
                autoOpen: true,
                resizable: false,
                title: 'Fill Product Details',
                height: 500,
                width: 500,
                close: function () {
                    Popup.dialog('destroy').remove();
                }
            });
        });
}

function SubmitForm(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        $.ajax({
            type: "POST",
            url: form.action,
            data: $(form).serialize(),
            success: function (data) {
                if (data.success) {
                    Popup.dialog('close');
                    dataTable.ajax.reload();

                    $.notify(data.message, {
                        globalPosition: "top center",
                        className: "success"
                    })

                }
            }
        });
    }
    return false;
}
function Delete(id) {
    if (confirm('Are You Sure to Delete this Product Record ?')) {
        $.ajax({
            type: "POST",
            url: '@Url.Action("Delete","Home")/' + id,
            success: function (data) {
                if (data.success) {
                    dataTable.ajax.reload();
                    $.notify(data.message, {
                        globalPosition: "top center",
                        className: "success"
                    })
                }
            }
        });
    }
}
