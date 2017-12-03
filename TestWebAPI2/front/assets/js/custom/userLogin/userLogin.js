function userLogin(e)
{
    
    $("#plzw8").append("&nbsp;&nbsp;<img src='assets/imgs/gif/ajax-loader.gif' style='width:25px;'>");
    var $email = $('#formUserLogin input[name=email]').val();
    var $password = $('#formUserLogin input[name=password]').val();
    $.ajax({
        type: 'POST',
        url: '../api/userLogin',
        data: { email: $email,password:$password},
        // contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            if(!verifyUserLogin(data))
            {
                $("#plzw8").html("");
                return;
            }
            else
            {
                localStorage.setItem("userEmail",$email);
                window.location="index.html";
            }
        }
    });//end ajax

}

