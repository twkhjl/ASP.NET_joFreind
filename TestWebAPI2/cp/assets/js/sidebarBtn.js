$("#spanAdminName").text(localStorage.getItem("loginName"));


$("#btnLogout").click(function(){
    localStorage.removeItem("loginName");
    window.location="login.html";
})