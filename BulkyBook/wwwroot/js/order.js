var dataTable;


$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax":{
            "url": "/Admin/Order/GetAll"

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
