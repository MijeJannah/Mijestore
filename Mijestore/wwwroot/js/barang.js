﻿var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblBarang').DataTable({
        "ajax": {
            "url":"/Admin/Barang/GetAll"
        },
        "columns": [
            { "data": "id", "width": "15%" },
            { "data": "name", "width": "15%" },
            { "data": "produk.name", "width": "15%" },
            { "data": "desk", "width": "15%" },
            { "data": "harga", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                         <div class="w-75 btn-group" role="group">
                         <a href="/Admin/Barang/Create?id=${data}" class="btn btn-secondary" type="button"> <i class="bi bi-pencil-square"></i> Edit </a>
                         <a onClick=Delete('/Admin/Barang/Delete/${data}') class="btn btn-danger mx-2" ><i class="bi bi-trash"></i> Hapus </a>
                        </div>
                        `
                },
                "width": "35%"
            }
        ]
    });
}
function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}
//var datatable;
//$(document).ready(function () {
//    loadDataTable
//})