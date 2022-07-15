var datatable
$(document).ready(function () {
    loadDataTable();
})
[Area("Admin")]
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Course/GetAll"
        },
        "columns": [
            { "data": "name", "width": "150px" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group role="group">
                            <a href="/Admin/Course/Edit?id=${data}"
                            class="btn btn-primary mx-2"><i class="bi bi-pencil-square "></i> Edit</a>
                            <a href="/Admin/Course/Delete?id=${data}"
                            class="btn btn-primary mx-2">Delete</a>
                            </div>`
                },
                "width": "15%"
            }
        ]

    });
}
