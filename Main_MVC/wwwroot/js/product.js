
$(document).ready(function (){
    loadDataTable();
})

function loadDataTable(){
    dataTable = $('#tblData').DataTable({
        "ajax": {url : '/admin/product/getall'},
        "columns": [
            {data: 'title',"width":"25%"},
            {data: 'author',"width":"20%"},
            {data: 'isbn',"width":"10%"},
            {data: 'price',"width":"10%"},
            {data: 'category.name',"width":"15%"},
            {
                data: 'id',
                "render": function (data){
                    return `<div>
                            <a href="/admin/product/edit?id=${data}" class="btn btn-primary">
                                <i class="bi bi-pencil-square"></i>Edit
                            </a>
                            <a href="/admin/product/delete?id=${data}" class="btn btn-primary bg-danger mx-3">
                                <i class="bi bi-trash-fill"></i>Delete
                            </a>
                        </div>`

                },
                "width":"20%"
            }
        ]
    });
}