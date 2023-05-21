
$(document).ready(function () {
    

});

function AddData() {
    debugger

    var Gender;
    var IsActive;

    if ($('#chkstatus').is(':checked') ){
        IsActive = "Active";
    }
    else
    {
        IsActive = "InActive";
    }
   
    if ($('#txtgender1').is(':checked'))
    {
        Gender="Male"
    }
    else if ($('#txtgender2').is(':checked')) {
        Gender = "Female"
    }
    else if ($('#txtgender3').is(':checked')) {
        Gender = "Trangender"
    }


    var objData = {
        Id: 0,
        Name: $('#txtname').val(),
        Age: $('#txtage').val(),
        Gender: Gender,
        Qualification: $('#txtqualification option:selected').text(),
        Email: $('#txtemail').val(),
        Password: $('#txtpwd').val(),
        ConfirmPassword: $('#txtcnfpwd').val(),
        IsActive : IsActive
    };

    debugger
        $.ajax({
            type: "POST",
            url: '/Employee/AddEmployeeData',
            data: objData,
            async: false,
            success: function (objData) {
                alert("Record Inserted Successfully !");
            }

        });

    
}