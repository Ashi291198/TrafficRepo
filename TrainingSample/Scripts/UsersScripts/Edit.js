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


//function EditUser(id, name, email, carLicense) {
//   // debugger;
//     $('input#gid.form-control').val(id);
//    $('input#AName.form-control').val(name);
//    $('input#ALat.form-control').val(email);
//    $('input#ACar.form-control').val(carLicense);


//}


function EditUser(Id){
    //debugger;
    $.ajax({
        url: '/Index/EdituS?Id=' + Id,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        async: true,
        success: function (data) {
           // debugger;
            console.log(data);
            $('#gid').val(data.UserId);

            $('#AName').val(data.FullName);
            $('#ALat').val(data.UserEmail);

            var sno = 0;
            var div = $('#CarL');
            div.empty();

            data.CarDetails.forEach(function (event) {

                div.append("<label>CarLicense" + (sno + 1) + "</label>" +
                    "<input class='form-control' id='" + event.Id + "' name='CarL' type='text' value='" + event.CarLicense + "' />");
                sno++;
            });

        }
          
    });

}





function EditUsers() {
    debugger;
    var id = $("#gid").val();
    var name = $("#AName").val();
    var email = $("#ALat").val();


    var v = new Array();
    $("input[name='CarL']").each(function () {
        v.push($(this).attr('id'));
    });

    var car1 = new Array();

   
v.forEach(function (car)
{
car1.push({

    Id: car,
    CarLicense: $("#" + car).val()

});
       // car1.push($('#' + car).val() +','+ $('#' + car).attr('id'));
       
        console.log(car1);
    });


    $.ajax({
            url: '/Index/EdituS',
            type: 'POST',
            data: JSON.stringify({
                UserId: id,
                FullName: name,
                UserEmail: email,
                CarDetails:car1


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
            






 

   

