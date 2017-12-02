
function editAdminPwd(caller){
    
    adminAuth();

    $adminID = $(caller).attr("data-rowNum");
    $account=$(caller).closest("tr").find(".account").text();

    $("#formEditAdminPwd .form-group").removeClass("has-error");
	$("#formEditAdminPwd .form-group div").eq(0).text($account);
    $("#formEditAdminPwd .form-group input").eq(0).val($adminID);
}






