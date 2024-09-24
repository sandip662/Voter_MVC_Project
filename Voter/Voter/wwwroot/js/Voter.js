$('#closeVoter').click(function () {
    window.location.reload();
});
$(document).ready(function () {
    $('#tblvoter').DataTable();
});

function TagDelete(VOTER_KEY) {

    Swal.fire({
        title: 'Do you want to Delete?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {


            // Make a POST request to delete the record
            $.ajax({
                url: "/Voter/DeleteVote",
                method: 'POST',
                data: {
                    id: VOTER_KEY
                },
                success: function (data) {
                    if (data.msg === "success") {
                        Swal.fire("Done", "Record Deleted Successfully!", "success");
                    }
                    else {
                        Swal.fire("Oops!!!", "Please Contact Admin", "error");
                    }
                    // Reload the page after deletion
                    window.location.reload();
                },
                error: function () {
                    Swal.fire("Oops!!!", "An error occurred while deleting the record.", "error");
                }
            });
        } else if (result.isDenied) {
            Swal.fire('Welcome', '', 'info');
        }
    });
}



function EditVote(id) {

    debugger;
    
 
    $.getJSON("/Voter/EditVote/" + id,
  
        function (d) {
            // Set values for text fields
            console.log(d);
            debugger;
            $("#VOTER_KEY").val(id);
            $("#NAME").val(d.name); 
            $("#AGE").val(d.age);
            // Set value for Gender radio buttons
            // Uncheck all radiobuttons
            $("input[name='GENDER_ID']").prop("checked", false);
            $("input[name='GENDER_ID'][value='" + d.gendeR_ID + "']").prop("checked", true);
            $("#STATE_ID").val(d.statE_ID);
            $("#VOTERCARD_NO").val(d.votercarD_NO);



            $("#VoterModal").modal('show');
            document.getElementById("staticBackdropLabel").innerHTML = "Voter Update Form:: [Edit]";
        });
}
