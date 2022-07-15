var datatable
$(document).ready(function () {
    loadDataTable();
})
[Area("Admin")]
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Teacher/GetAll"
        },
        "columns": [
            { "data": "name", "width": "150px" },
            { "data": "address", "width": "150px" },
            { "data": "email", "width": "150px" },
            { "data": "phone", "width": "150px" },
            { "data": "dob", "width": "150px" },
            { "data": "doj", "width": "150px" },
            { "data": "course.name", "width": "150px" },
            { "data": "department.name", "width": "150px" },
            
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group role="group">
                            <a href="/Admin/Teacher/Edit?id=${data}"
                            class="btn btn-primary mx-2"><i class="bi bi-pencil-square "></i> Edit</a>
                            <a href="/Admin/Teacher/Delete?id=${data}"
                            class="btn btn-primary mx-2">Delete</a>
                            </div>`
                },
                "width": "15%"
            }
        ]
    });
}