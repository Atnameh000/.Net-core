
$(document).ready(function (){
    loadDataTable();
})

function loadDataTable(){
    dataTable = $('#tblData').DataTable({
        "ajax": {url : '/admin/category/getall'},
        "columns": [
            {data: 'name',"width":"25%"},
            {data: 'displayOrder',"width":"25%"},
            {
                data: 'id',
                "render": function (data){
                    return `<div>
                            <a href="/admin/category/edit?id=${data}" class="btn btn-primary">
                                <i class="bi bi-pencil-square"></i>Edit
                            </a>
                            <a href="/admin/category/delete?id=${data}" class="btn btn-primary bg-danger mx-3">
                                <i class="bi bi-trash-fill"></i>Delete
                            </a>
                        </div>`

                },
                "width":"25%"
            }
        ]
    });
}