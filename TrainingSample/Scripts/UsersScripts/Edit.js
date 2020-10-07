//function EditUser(FullName) {

//    var v = {

//        userName: $('#AName').val(),
//        Email: $('#ALat').val(),
//        Address: $('#ALong').val()

//    };
//    $.ajax({
//        url: "/Imdex/EdituS",
//        data: JSON.stringify(v),
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            loadData();
//            $('#myModal').modal('hide');

//            $('#AName').val("");
//            $('#ALat').val("");
//            $('#ALong').val("");

//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}


function EditUser(id, name, email, carLicense) {
   // debugger;
     $('input#gid.form-control').val(id);
    $('input#AName.form-control').val(name);
    $('input#ALat.form-control').val(email);
    $('input#ACar.form-control').val(carLicense);


}



function EditUsers()
{
       // debugger;
        // $('input#gid').val(id);
    //    var name = $('#AName.form-control').val(name);
    //var email = $('#ALat.form-control').val(email);
    //var carLicense = $('#ACar.form-control').val(carLicense);
    var id= $("#gid").val();
    var name = $("#AName").val();
    var email = $("#ALat").val();
    var carLicense = $("#ACar").val();



        $.ajax({
            url: '/Index/EdituS',
            type: 'POST',
            data: JSON.stringify({
                UserId:id,
                FullName: name,
                UserEmail: email,
                CarLicense: carLicense

            }),
            dataType: 'json',
            contentType: 'application/json',
            async: false,
            success: function (data) {
                $("#editUser").hide();
                $("#editUser").addClass('hide');
            }

        });
    }

   

