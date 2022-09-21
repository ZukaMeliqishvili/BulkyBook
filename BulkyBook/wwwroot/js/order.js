var dataTable;


$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        loadDataTable("inprocess");
    }
    else {
        if (url.includes("complete")) {
            loadDataTable("complete");
        }
        else {
            if (url.includes("pending")) {
                loadDataTable("pending");
            }
            else {
                loadDataTable("all");
            }
        }
    }
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        "ajax":{
            "url": "/Admin/Order/GetAll?status="+status

        },
        "columns": [
            { "data": "id", "Width": "5%" },
            { "data": "name", "Width": "20" },
            { "data": "phoneNumber", "Width": "15%" },
            { "data": "applicationUser.email", "Width": "20%" },
            { "data": "orderStatus", "Width": "15" },
            { "data": "orderTotal", "Width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Order/Details?orderId=${data}"
                        class="btn btn-primary mx-2">
                        <i class="bi bi-pencil-square"></i></a>
                    </div>
                        `
                },
                "width":"15%",
            }


        ]
    });
}
