
if(sessionStorage.getItem("userID")==null ||
  sessionStorage.getItem("userNickname")==null ||
sessionStorage.getItem("userEmail")==null){
  $("body").empty();
}

$(".box>div").text(sessionStorage.getItem("userNickname")+
"您好,請重設您的密碼");
//
$("form .form-group span").eq(0).text(sessionStorage.getItem("userEmail"));
$("form .form-group input").eq(2).val(sessionStorage.getItem("userID"));


$("#btnSubmit").click(function (e) {
    e.preventDefault();
    resetPassword();

})//end click


function resetPassword(e)
{
	$("#plzw8").append("&nbsp;&nbsp;<img src='assets/imgs/gif/ajax-loader.gif' style='width:25px;'>");
  var $userID = $('form input[name=userID]').val();
  var $password = $('form input[name=password]').val();
    var $confirmPwd = $('form input[name=confirmPwd]').val();

    $.ajax({
        type: 'POST',
        url: '../api/users/reset/password',
        data: {
          userID: $userID,
          password:$password,
          confirmPwd: $confirmPwd,
        },
        // contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        dataType: 'json',
        success: function (data) {
console.log(data);
					$("#plzw8").html("");
            if(!verifyResetPassword(data))
            {
               return;
            }
            else
            {
                sessionStorage.setItem("msgToken","passwordResetOK");
                sessionStorage.setItem("userNickname",data.nickname);
                sessionStorage.setItem("userEmail",data.email);
                window.location="showMsg.html";
            }

        }
    });//end ajax
}



function verifyResetPassword(data)
{
  if(data.userID!=null)
  {
    return true;
  }
    err=0;

    $("form .form-group").removeClass("has-error");
    $("form .form-group span").eq(1).text("");
    $("form .form-group span").eq(2).text("");

    if (data.indexOf("passwordBlankErr") > -1)
    {
        $("form .form-group").eq(1).addClass("has-error");
        $("form .form-group span").eq(1).text("密碼不可空白");
        err++;
    }

    if (data.indexOf("passwordNotMatchErr") > -1)
    {
        $("form .form-group").eq(2).addClass("has-error");
        $("form .form-group span").eq(2).text("密碼需相符");
        err++;
    }

    if(0==err)
    {

        return true;
    }
    return false;

}//end verifyUserLogin
