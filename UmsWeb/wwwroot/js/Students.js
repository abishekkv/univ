var datatable
$(document).ready(function () {
    loadDataTable();
})
[Area("Admin")]
function loadDataTable() {
    $("#tblData").DataTable({
        "ajax": {
            "url": "/Admin/Student/GetAll"
        },
        "columns": [
            {"data":"user.username","width":"150px"},
            { "data": "name", "width": "150px" },
            { "data": "fatherName", "width": "150px" },
            { "data": "motherName", "width": "150px" },
            { "data": "dob", "width": "150px" },
            { "data": "address", "width": "150px" },
            { "data": "email", "width": "150px" },
            { "data": "sex", "width": "150px" },
            { "data": "semester", "width": "150px" },
            { "data": "yearOfJoining", "width": "150px" },
            { "data": "department.name", "width": "150px" },
            { "data": "course.name", "width": "150px" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group role="group">
                            <a href="/Admin/Student/Edit?id=${data}"
                            class="btn btn-primary mx-2"><i class="bi bi-pencil-square "></i> Edit</a>
                            <a href="/Admin/Student/Delete?id=${data}"
                            class="btn btn-primary mx-2">Delete</a>
                            </div>`
                },
                "width": "15%",
            }
        ]
    });
}