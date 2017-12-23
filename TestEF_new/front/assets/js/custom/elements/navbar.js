var $ulStart='<ul class="nav navbar-nav navbar-right">';
var $ulEnd='</ul>';

var $liCommon=
[
    '                           <li class="dropdown">',
    '                               <a href="index.html">首頁 </a>',
    '                           </li>',
    '                           <li class="dropdown">',
    '                               <a href="about.html">關於 </a>',
    '                           </li>',
    '                           <li class="dropdown">',
    '                               <a href="news.html">最新消息</a>',
    '                           </li>',
    '                           <li class="dropdown">',
    '                               <a href="contact.html">聯絡我們</a>',
    '                           </li>',
  ].join('\n');

  var $liMemberSection = [
    '                           <li class="dropdown">',
    '                               <a href="activity-list.html">活動列表</a>',
    '                           </li>',
    '                           <li class="dropdown">',
    '                               <a href="javascript: void(0)" class="dropdown-toggle" data-toggle="dropdown">會員專區 ',
    '                               <b class="caret"></b></a>',
    '                               <ul class="dropdown-menu">',
    '                                   <li><a href="#">收件匣</a></li>',
    '                                   <li><a href="#">好友列表</a></li>',
    '                                   <li><a href="#">個人設定</a></li>',
    '                                   <li id="liUserLogOut"><a href="#">登出</a></li>',
    '                               </ul>',
    '                           </li>'
  ].join('\n');

  var $liAuthSection=[
    '                           <li class="dropdown">',
    '                               <a href="#" data-toggle="modal" data-target="#login_modal"><i class="fa fa-sign-in"></i> ',
    '                               <span>登入</span></a>',
    '                           </li>',
    '                           <li class="dropdown"">',
    '                               <a href="user-register.html"><i class="fa fa-user"></i> <span>註冊</span></a>',
    '                           </li>'
  ].join('\n');


  var $userLoginModal=
  ['<div class="modal fade" id="login_modal" tabindex="-1" role="dialog" aria-labelledby="Login" aria-hidden="true">',
'    <div class="modal-dialog modal-sm">',
'        <div class="modal-content">',
'            <div class="modal-header">',
'                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>',
'                <h4 class="modal-title" id="Login">用戶登入<span id="plzw8"></span></h4>',
'            </div>',
'            <div class="modal-body">',
'              <form id="formUserLogin">',
'                  <div class="form-group">',
'                      <label for="email">請輸入Email:</label>',
'                      <input type="text" class="form-control" name="email">',
'                      <span></span>',
'                  </div>',
'                  <div class="form-group">',
'                      <label for="password">請輸入密碼:</label>',
'                      <input type="password" class="form-control" name="password">',
'                      <span class="text-danger"></span>',
'                  </div>',
'                    <div class="checkbox">',
'                        <label><input type="checkbox" name="rememberMe"> 記住我</label>',
'                    </div>',
'                  <div class="text-center">',
'                      <button type="submit" id="btnLogin" class="btn btn-template-main">',
'                      <i class="fa fa-sign-in"></i> 登入</button>',
'                  </div>',
'              </form>',
'                <a href="user-register.html"><strong>尚未註冊?</strong></a><br>',
'                <a href="forgotPassword_email.html" ><strong>忘記密碼?</strong></a><br>',
'            </div>',
'        </div>',
'    </div>',
'</div>'].join('\n');



setNavBar();






//---------------------function-----------------------------
function setNavBar()
{
  $("#navigation").empty();
  if(sessionStorage.getItem("userNickname")!=null ||
  localStorage.getItem("userNickname")!=null)
  {

    $("#navigation").html($ulStart+$liCommon+$liMemberSection+$ulEnd+$userLoginModal);

    setUserNickname();
  }
  else
  {
    $("#navigation").html($ulStart+$liCommon+$liAuthSection+$ulEnd+$userLoginModal);

  }
  setNavItemActive();

  $("#liUserLogOut").click(function()
  {
    localStorage.removeItem("userNickname");
    sessionStorage.removeItem("userNickname");
    window.location="index.html";
  })
}

function setUserNickname()
{
  if(sessionStorage.getItem("userNickname")!=null)
  {
    $("li a[class='dropdown-toggle']").html(sessionStorage.getItem("userNickname"));
  }

  else if(localStorage.getItem("userNickname")!=null)
  {
    $("li a[class='dropdown-toggle']").html(localStorage.getItem("userNickname"));
  }

}

function setNavItemActive()
{
  var currentPage= document.location.pathname.match(/[^\/]+$/)[0];
  if(currentPage=="index.html")
  {
    $("li").has("a[href='index.html']").addClass("active");
  }
  if(currentPage=="news.html")
  {
    $("li").has("a[href='news.html']").addClass("active");
  }
  if(currentPage=="about.html")
  {
    $("li").has("a[href='about.html']").addClass("active");
  }
  if(currentPage=="contact.html")
  {
    $("li").has("a[href='contact.html']").addClass("active");
  }
  if(currentPage=="activity-list.html")
  {
    $("li").has("a[href='activity-list.html']").addClass("active");
  }
  if(currentPage=="user-register.html")
  {
    $("li").has("a[href='user-register.html']").addClass("active");
  }
}



//------------user login-----------------------------------------------------



//reset w8ing msg
$("#plzw8").html("");

$("#formUserLogin .form-group").removeClass("has-error");
$("#formUserLogin .form-group span").text("");


$("#btnLogin").click(function (e) {
    e.preventDefault();

    userLogin();

})//end click


function userLogin(e)
{
	$("#plzw8").append("&nbsp;&nbsp;<img src='assets/imgs/gif/ajax-loader.gif' style='width:25px;'>");
    var $email = $('#formUserLogin input[name=email]').val();
    var $password = $('#formUserLogin input[name=password]').val();
    var $rememberMe = $("#formUserLogin input[name=rememberMe]").is(":checked");

    $.ajax({
        type: 'POST',
        url: '../api/users/login',
        data: { email: $email,password:$password},
        // contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        dataType: 'json',
        success: function (data) {
					$("#plzw8").html("");
            if(!verifyUserLogin(data))
            {
               return;
            }
            else
            {
               if($rememberMe==true)
               {
                    localStorage.setItem("userNickname",data.nickname);
                    var userNickname = localStorage.getItem("userNickname");
               }
               else
               {
                    sessionStorage.setItem("userNickname",data.nickname);
                    var userNickname = sessionStorage.getItem("userNickname");
               }

               	$('#login_modal').modal('hide');
                setNavBar();
                location.reload();
            }
        }
    });//end ajax
}



function verifyUserLogin(data)
{
  if(data.nickname!=null)
  {
    return true;
  }
    err=0;

    $("#formUserLogin .form-group").removeClass("has-error");
    $("#formUserLogin .form-group span").text("");

    if(data.indexOf("emailNotExistErr")!=-1 ||
    data.indexOf("passwordBlankErr")!=-1 ||
		data.indexOf("passwordInCorrectErr")!=-1)
    {
				$("#formUserLogin .form-group").eq(0).addClass("has-error");
        $("#formUserLogin .form-group span").eq(0).addClass("text-danger");
        $("#formUserLogin .form-group span").eq(0).text("*帳號或密碼錯誤");
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
