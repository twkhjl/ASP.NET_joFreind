
userAuth();

function userAuth()
{
  var currentPage= document.location.pathname.match(/[^\/]+$/)[0];

  //define page names allowed for guest
  var commonPagesArr=[
    "index.html",
    "about.html",
    "contact.html",
    "user-register.html",
    "news.html",
    "forgotPassword_email.html",
    "resetPassword.html",
    "test.html",
    "showMsg.html"
  ];

  //return if user are visting common pages
  //these pages are allowed to visited without logging in
  if(-1!=commonPagesArr.indexOf(currentPage))
  {
    return;
  }

  //check if user is logged in or not
  var isLoggedin =(localStorage.getItem("userNickname")!=null ||
  sessionStorage.getItem("userNickname")!=null);

  if(!isLoggedin)
  {
    window.location="index.html";
    return;
  }
  else
  {
    return ;
  }
}
