function InsertUser() {
    debugger;
    var userName = $("#AName").val();
    var Email = $("#ALat").val();
    var Address = $("#ALong").val();
    var image = $("#image").val();
    var imagenBase64 = $("#pImageBase64").html();
   

    //var url = "@Url.Action("InsertuS", "Index")"
    $.ajax({
        url: '/Index/InsertuS',
        type: 'POST',
        data: JSON.stringify({
            FullName: userName,
            UserEmail: Email,
            Address: Address,
            ProfilePic: imagenBase64,

        }),
        dataType: 'json',
        contentType: 'application/json',
        async: false,
        success: function (data) {
            $("#addUser").hide();
            $("#addUser").addClass('hide');
        }

    });
}




function Delete(Id) {
    var ans = confirm("Are you sure you want to delete ?");
    if (ans)
    {
        $.ajax({
            url: "/Index/DeleteuS" + Id,
            type: "POST",
            contentType: "application/json",
            dataType: "json"
        });

    }

}

function encodeImagetoBase64(element) {
    var file = element.files[0];
    var reader = new FileReader();
    reader.onloadend = function () {
        $("#image").attr("src", reader.result);
        $("#pImageBase64").html(reader.result);

    }
   reader.readAsDataURL(file);
}




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





//function EditUser(_id) {
//    var v = {
        
//        userName = $("#AName").val(),
//        Email = $("#ALat").val(),
//        Address = $("#ALong").val(),
//        image = $("#image").val()

//    };
    
//    $.ajax({
//        url: '/Index/EdituS',
//        type: 'POST',
//        data: JSON.stringify(v),
//        dataType: 'json',
//        contentType: 'application/json',
        
//        success: function (data) {

//            $("#editUser").hide();
//            $("#AName").val("");
//            $("#ALat").val("");
//            $("#ALong").val("");
//            $("#image").val("");
//        }

//    });

//}