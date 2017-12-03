if(localStorage.getItem("userEmail")!=null)
{
    var userEmail = localStorage.getItem("userEmail");
    $("#navLoginedUserSecton a[class='dropdown-toggle']").html("<h5>"+userEmail+"<h5>");

    $("#navUserLoginSection").hide();
    $("#navUserRegisterSection").hide();

}
else
{
    $("#navLoginedUserSecton").hide();
}


//-------------------
//user log out

$("#liUserLogOut").click(function()
{
    userLogOut();
})



function userLogOut()
{
    localStorage.removeItem("userEmail");
    window.location="index.html";
}
