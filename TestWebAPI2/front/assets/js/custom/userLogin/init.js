if(localStorage.getItem("userEmail")!=null)
{
    window.location="index.html";
}

//reset w8ing msg
$("#plzw8").html("");

$("#btnLogin").click(function (e) {
    e.preventDefault();

    userLogin();

})//end click