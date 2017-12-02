function updateAdminPwd(e){
    

adminAuth();

e.preventDefault();
e.stopPropagation();

    
    var $adminID = $('#formEditAdminPwd .form-group input[name=adminID]').val();
    var $password = $('#formEditAdminPwd .form-group input[name=password]').val();
    var $confirmPwd = $('#formEditAdminPwd .form-group input[name=confirmPwd]').val();

    $.ajax({
        type: 'POST',
        url: '../api/admins/update',
        data: "abcde",
        // data: { adminID: $adminID,password:$password,confirmPwd:$confirmPwd},
        // contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            // if(!verifyCreateAdmin(data))
            // {
            //     return;
            // }
            // else
            // {
            //     //close modal
            //     $("#modalCreateAdmin").find("button").eq(0).trigger("click");
            //     showAdminTable();
            // }
            
        }
    });//end ajax
}





