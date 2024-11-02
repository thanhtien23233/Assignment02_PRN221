$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    dataTable = $('#tblJobPosting').DataTable({
        "ajax": {
            url: '/api/datatable/get-jobPostings',
            dataSrc: 'data'
        },
        "columns": [
            { data: 'jobPostingTitle', "width": "20%" },
            { data: 'description', "width": "55%" },
            { data: 'postedDate', "width": "15%" },
            {
                data: 'postingId',
                "render": function (data) {
                    var editButton = '';
                    var deleteButton = '';

                    if (roleId === "1" || roleId === "2") {
                        editButton = ` 
                            <a href="/JobPostingPages/Edit?id=${data}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i> Edit
                            </a>`;
                        deleteButton = `
                            <a href="#" class="btn btn-danger mx-2" onClick="event.preventDefault(); Delete('${data}')">
                                <i class="bi bi-trash-fill"></i> Delete
                            </a>`;
                    }

                    return `
                        <div class="btn-group" role="group">
                            ${editButton}
                            ${deleteButton}
                        </div>`;
                },
                "width": "10%"
            }
        ]
    });
}
function Delete(postingId) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `/api/datatable/jobPosting?id=${postingId}`,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                },
                error: function () {
                    toastr.error("An error occurred while deleting the item.");
                }
            });
        }
    });
}