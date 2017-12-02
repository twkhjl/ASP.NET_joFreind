$("#btnAdd").click(function (e) {
    //e.preventDefault();

    var $account = $('input[name=account]').val();
    var $password = $('input[name=password]').val();
    var $confirmPwd = $('input[name=confirmPwd]').val();

    $.ajax({
        type: 'POST',
        url: '../api/admins',
        data: { account: $account,password:$password,confirmPwd:$confirmPwd},
        // contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            console.log(data);
        }
    });
})