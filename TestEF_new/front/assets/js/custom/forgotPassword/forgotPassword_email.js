//reset w8ing msg
$("#plzw8").html("");

$("form .form-group").removeClass("has-error");
$("form .form-group span").text("");


$("#btnSubmit").click(function (e) {
    e.preventDefault();

    forgotPassword_email();

})//end click


function forgotPassword_email(e)
{
	$("#plzw8").append("&nbsp;&nbsp;<img src='assets/imgs/gif/ajax-loader.gif' style='width:25px;'>");
    var $email = $('form input[name=email]').val();
    $.ajax({
        type: 'POST',
        url: '../api/users/forgotPassword/email',
        data: { email: $email},
        // contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        dataType: 'json',
        success: function (data) {
					$("#plzw8").html("");
            if(!verifyUserEmail(data))
            {
               return;
            }
            else
            {
                sessionStorage.setItem("msgToken","resetPasswordLinkSent");
                sessionStorage.setItem("userNickname",data.nickname);
                sessionStorage.setItem("userEmail",data.email);
                window.location="showMsg.html";
            }

        }
    });//end ajax
}



function verifyUserEmail(data)
{
  if (data.userID !=null)
  {
      return true;
  }

    err=0;

    $("form .form-group").removeClass("has-error");
    $("form .form-group span").text("");

    if(data.indexOf("emailNotExistErr")!=-1)
    {
				$("form .form-group").eq(0).addClass("has-error");
        $("form .form-group span").eq(0).addClass("text-danger");
        $("form .form-group span").eq(0).text("*帳號不存在");
        err++;
        return false;
    }
    if(data.indexOf("userBannedErr")!=-1)
    {
        $("#formUserLogin .form-group").eq(0).addClass("has-error");
				$("#formUserLogin .form-group span").eq(0).addClass("text-danger");
        $("#formUserLogin .form-group span").eq(0).text("*此帳號已被禁用");
        err++;
    }
    if(data.indexOf("userNotActivateErr")!=-1)
    {
        $("#formUserLogin .form-group").eq(0).addClass("has-error");
				$("#formUserLogin .form-group span").eq(0).addClass("text-danger");
        $("#formUserLogin .form-group span").eq(0).text("*帳號未啟用");
        err++;
    }

    if(0==err)
    {

        return true;
    }
    return false;

}//end verifyUserLogin
