$(document).ready(function () {
    loadDataTable();
})
[Area("Admin")]
function loadDataTable() {
    $("#tblData").DataTable({
        "ajax": {
            "url": "/Admin/Fees/GetAll"
        },
        "columns": [
            { "data": "course.name", "width": "150px" },
            { "data": "courseFee", "width": "150px" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group role="group">
                            <a href="/Admin/Fees/Edit?id=${data}"
                            class="btn btn-primary mx-2"><i class="bi bi-pencil-square "></i> Edit</a>
                            <a href="/Admin/Fees/Delete?id=${data}"
                            class="btn btn-primary mx-2">Delete</a>
                            </div>`
                },
                "width": "15%"   
            }
            
        ]
    });
}