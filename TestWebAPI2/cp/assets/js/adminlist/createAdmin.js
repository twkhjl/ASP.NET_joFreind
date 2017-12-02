
function createAdmin(e){


    $("#formCreateAdmin .form-group").removeClass("has-error");
	$("#formCreateAdmin .form-group span").text("");
    e.preventDefault();
    e.stopPropagation();

adminAuth();
    
    var $account = $('#formCreateAdmin .form-group input[name=account]').val();
    var $password = $('#formCreateAdmin .form-group input[name=password]').val();
    var $confirmPwd = $('#formCreateAdmin .form-group input[name=confirmPwd]').val();

    $.ajax({
        type: 'POST',
        url: '../api/admins',
        data: { account: $account,password:$password,confirmPwd:$confirmPwd},
        // contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            if(!verifyCreateAdmin(data))
            {
                return;
            }
            else
            {
                //close modal
                $("#modalCreateAdmin").find("button").eq(0).trigger("click");
                showAdminTable();
            }
            
        }
    });
}




