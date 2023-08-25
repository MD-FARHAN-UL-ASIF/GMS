<?php
$title = "Employee";
//include('layout_header.php');
?>

<link rel="stylesheet" href="../assets/bundles/datatables/datatables.min.css">
<link rel="stylesheet" href="../assets/bundles/datatables/DataTables-1.10.16/css/dataTables.bootstrap4.min.css">

<section class="section" id="employee">
    <div class="section-body">
        <?php if(isset($_GET['from'])){ ?>
            <div class="alert alert-success">
                <div class="alert-title">Employee <?php if($_GET['from']=='delete'){ ?> deleted<?php } ?>
                    <?php if($_GET['from']=='edit'){ ?> Updated <?php } ?>
                    <?php if($_GET['from']=='add'){ ?> Added <?php } ?>
                    Successfully</div>
            </div>
        <?php } ?>
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">
                        <h4>All Employees</h4>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="table table-striped" id="table">
                                <thead>
                                    <tr>
                                        <th class="text-center">
                                            #
                                        </th>
                                        <th>Name</th>
                                        <th>Username</th>
                                        <th>Phone Number</th>
                                        <th>Email</th>
                                        <th>NID</th>
                                        <th>Date of Birth</th>
                                        <th>Gender</th>
                                        <th>Address</th>
                                        <th>Status</th>
                                        <th>Image</th>
                                        <th>User Type</th>
                                        <th>Department</th>
                                        <th>Salary</th>
                                        <!-- Add more columns as needed -->
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<!-- JS Libraries -->
<script src="../assets/bundles/datatables/datatables.min.js"></script>
<script src="../assets/bundles/datatables/DataTables-1.10.16/js/dataTables.bootstrap4.min.js"></script>
<script src="../assets/bundles/jquery-ui/jquery-ui.min.js"></script>
<!-- Page Specific JS File -->
<script src="../assets/js/page/datatables.js"></script>

<script>
$(document).ready(function() {
    $.ajax({
        url: "https://localhost:44318/api/employee/all",
        type: 'GET',
        dataType: 'json',
        success: function(res) {
            res.forEach(create_table_row);
        }
    });
    // ... Other permission handling if needed
});

// Other functions for handling interactions and data

function create_table_row(item, index) {
    var row =
        '<tr>' +
        '<td>' + (index + 1) + '</td>' +
        '<td>' + item.Name + '</td>' +
        '<td>' + item.UserName + '</td>' +
        '<td>' + item.PhoneNumber + '</td>' +
        '<td>' + item.Email + '</td>' +
        '<td>' + item.NID + '</td>' +
        '<td>' + moment(item.DOB).format('YYYY-MM-YY') + '</td>' +
        '<td>' + item.Gender + '</td>' +
        '<td>' + item.Address + '</td>' +
        '<td>' + item.Status + '</td>' +
        '<td>' + item.Image + '</td>' +
        '<td>' + item.UserType + '</td>' +
        '<td>' + item.Department + '</td>' +
        '<td>' + item.Salary + '</td>' +
        // Add more table cells based on your Employee model
        '<td class="text-center">' +
        '<a href="employee-view.php?id=' + item.Id + '" class="btn btn-success" style="margin:2px;">View</a><br>' +
        '<a href="employee-edit.php?id=' + item.Id + '" class="btn btn-primary" style="margin:2px;">Edit</a><br>' +
        '<a href="#" onclick="delete_employee(' + item.Id + ');" class="btn btn-danger" style="margin:2px;">Delete</a><br>' +
        '</td>' +
        '</tr>';
    $('#table > tbody:last-child').append(row);
}

function delete_employee(id) {
    $.ajax({
        url: api_root + "/api/employee/delete/" + id,
        type: 'DELETE',
        dataType: 'json',
        success: function(res) {
            window.location.href = "employee.php?from=delete";
        }
    });
}
</script>

<?php
//include('layout_footer.php');
?>
