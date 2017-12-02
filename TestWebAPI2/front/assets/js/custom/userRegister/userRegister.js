function userRegister()
{
    
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
console.log(data);
                return;
            }
console.log(data);
        }
    });//end ajax

}
