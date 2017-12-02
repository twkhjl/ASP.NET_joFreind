function userRegister()
{
    $("#plzw8").html("請稍候...");

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
                return;
            }
            window.location="showMsg.html";
        }
    });//end ajax

}
