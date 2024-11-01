$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/api/datatable/get-jobPostings',
            dataSrc: 'data'
        },
        "columns": [
            { data: 'jobPostingTitle', "width": "20%" },
            { data: 'description', "width": "25%" },
            { data: 'postedDate', "width": "20%" },
            {
                data: 'postingId',
                "render": function (data) {
                    return `
                        <div class="btn-group" role="group">
                            <a href="/JobPostingPages/Edit?id=${data}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i> Edit
                            </a>
                            <a href="#" class="btn btn-danger mx-2" onClick="event.preventDefault(); Delete('${data}')">
                                <i class="bi bi-trash-fill"></i> Delete
                            </a>
                        </div>`;
                },
                "width": "13%"
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
            // Use AJAX to delete the item instead of redirecting
            $.ajax({
                url: `/JobPostingPages/Delete?id=${postingId}`,
                type: 'GET',
                success: function (data) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                },
                error: function () {
                    toastr.error("An error occurred while deleting the item.");
                }
            });
        }
    });
}
