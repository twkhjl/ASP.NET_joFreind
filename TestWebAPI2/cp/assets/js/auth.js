adminAuth();

function adminAuth()
{
    if(localStorage.getItem("loginName")==null)
    {
        window.location = "login.html";
    }

}




