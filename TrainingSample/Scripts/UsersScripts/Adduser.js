function InsertUser() {
    debugger;
    var userName = $("#AName1").val();
    var Email = $("#ALat1").val();
    var Address = $("#ALong1").val();
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
        async:true,
        success: function (data) {
            $('#addUser').modal('hide');
           // $("#addUser").hide();
            //$("#addUser").addClass('hide');
           
        }


    });
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






function Delete(Id) {
    debugger;
    var result = confirm('Are you sure you wish to delete this record?');
    if (result) {
        $.ajax({
            url: '/Index/DeleteuS?id=' + Id,
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            async: false,
            success: function (data) {
                window.reload();
                //$("#addUser").hide();
                //$("#addUser").addClass('hide');
            }

        });
    }



    //function encodeImagetoBase64(element) {
    //    var file = element.files[0];
    //    var reader = new FileReader();
    //    reader.onloadend = function () {
    //        $("#image").attr("src", reader.result);
    //        $("#pImageBase64").html(reader.result);

    //    }
    //    reader.readAsDataURL(file);
    //}


}