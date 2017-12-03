function userRegister(e)
{
    
    $("#plzw8").append("&nbsp;&nbsp;<img src='assets/imgs/gif/ajax-loader.gif' style='width:25px;'>");
    var $email = $('#formUserRegister input[name=email]').val();
    var $password = $('#formUserRegister input[name=password]').val();
    var $confirmPwd = $('#formUserRegister input[name=confirmPwd]').val();
    $.ajax({
        type: 'POST',
        url: '../api/users/register',
        data: { email: $email,password:$password,confirmPwd:$confirmPwd},
        // contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        dataType: 'json',
        success: function (data) {
           
            if(!verifyUserRegister(data))
            {
                $("#plzw8").html("");
                return;
            }
            else
            {
                sessionStorage.setItem("msgToken","userCreated");
                sessionStorage.setItem("createdEmail",$email);
                window.location="showMsg.html";
                
            }
        }
    });//end ajax

}

