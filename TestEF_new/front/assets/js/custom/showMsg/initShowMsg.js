
if(sessionStorage.getItem("msgToken")==null)
{
  $("body").empty();
}


if(sessionStorage.getItem("msgToken")=="userCreated")
{
    var createdUserNickName = sessionStorage.getItem("createdUserNickName");
    var createdUserEmail = sessionStorage.getItem("createdUserEmail");

    $("#msgBox").append("<h3>"+createdUserNickName+",感謝您的註冊</h3>");
    $("#msgBox").append("<div>已將驗證碼寄至您的信箱:"+createdUserEmail+"</div>");
    $("#msgBox").append("<div>請至信箱收信以啟用您的帳號");
}

if(sessionStorage.getItem("msgToken")=="userActivated")
{
    if(sessionStorage.getItem("userEmail")==null)
    {
        $("#msgBox").append("<h3>很抱歉,系統出現異常</h3>");
        $("#msgBox").append("<div>請留言與我們聯絡,感謝您...&nbsp;&nbsp;<img src='assets/imgs/gif/ajax-loader.gif' style='width:25px;'></div>");
        redirectURL(3000,"contact.html");
    }

    var userEmail = sessionStorage.getItem("userEmail");
    var userNickname = sessionStorage.getItem("userNickname");
    $("#msgBox").append("<h3>"+userNickname+"您好,您的帳號已啟用,歡迎加入會員</h3>");
    $("#msgBox").append("<h3>您的帳號是:"+userEmail+"</h3>");
    $("#msgBox").append("<div>請稍候,即將導向首頁...&nbsp;&nbsp;<img src='assets/imgs/gif/ajax-loader.gif' style='width:25px;'></div>");

    localStorage.setItem("userNickname",userNickname);
    redirectURL(3000,"index.html");
}

if(sessionStorage.getItem("msgToken")=="userBanned")
{
    var userEmail = sessionStorage.getItem("userEmail");
    $("#msgBox").append("<h3>很抱歉,帳號'"+userEmail+"'已被禁用</h3>");
    $("#msgBox").append("<div>如有任何問題請留言與我們聯絡,感謝您...&nbsp;&nbsp;<img src='assets/imgs/gif/ajax-loader.gif' style='width:25px;'></div>");
    redirectURL(3000,"contact.html");
}

if(sessionStorage.getItem("msgToken")=="userAlreadyActivated")
{
    var userEmail = sessionStorage.getItem("userEmail");
    var userNickname = sessionStorage.getItem("userNickname");
    $("#msgBox").append("<h3>帳號'"+userEmail+"'已通過驗證,不需重複啟用</h3>");
    $("#msgBox").append("<div>請稍候,即將導向首頁...&nbsp;&nbsp;<img src='assets/imgs/gif/ajax-loader.gif' style='width:25px;'></div>");

    localStorage.setItem("userNickname",userNickname);
    redirectURL(3000,"index.html");
}

if(sessionStorage.getItem("msgToken")=="resetPasswordLinkSent")
{
    var userEmail = sessionStorage.getItem("userEmail");
    var userNickname = sessionStorage.getItem("userNickname");
    $("#msgBox").append("<h3>"+userNickname+"您好,</h3>");
    $("#msgBox").append("<div>已將重設密碼連結寄至您的信箱:"+userEmail+"</div>");
    $("#msgBox").append("<div>請至信箱收信以重設密碼");

}

if(sessionStorage.getItem("msgToken")=="redirectToResetPasswordPage")
{
    var userID = sessionStorage.getItem("userID");
    var userEmail = sessionStorage.getItem("userEmail");
    var userNickname = sessionStorage.getItem("userNickname");
    window.location="resetPassword.html";
}

if(sessionStorage.getItem("msgToken")=="passwordResetOK")
{
    if(sessionStorage.getItem("userEmail")==null)
    {
        $("#msgBox").append("<h3>很抱歉,系統出現異常</h3>");
        $("#msgBox").append("<div>請留言與我們聯絡,感謝您...&nbsp;&nbsp;<img src='assets/imgs/gif/ajax-loader.gif' style='width:25px;'></div>");
        redirectURL(3000,"contact.html");
    }

    var userEmail = sessionStorage.getItem("userEmail");
    var userNickname = sessionStorage.getItem("userNickname");
    $("#msgBox").append("<h3>"+userNickname+"您好,您的密碼已重設</h3>");
    $("#msgBox").append("<div>請稍候,即將導向首頁...&nbsp;&nbsp;<img src='assets/imgs/gif/ajax-loader.gif' style='width:25px;'></div>");

    localStorage.setItem("userNickname",userNickname);
    redirectURL(3000,"index.html");
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }

  async function redirectURL(int,url) {
    await sleep(int);
      window.location=url;
  }
