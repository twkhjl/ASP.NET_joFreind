
$("#formUserLogin .form-group").removeClass("has-error");
$("#formUserLogin .form-group span").text("");

function verifyUserLogin(data)
{
    err=0;
    
    $("#formUserLogin .form-group").removeClass("has-error");
    $("#formUserLogin .form-group span").text("");

    if(data==null)
    {
        $("#formUserLogin .form-group").eq(0).addClass("has-error");
        $("#formUserLogin .form-group span").eq(0).text("*帳號或密碼錯誤");
        return false;
    }
    if("userBannedErr"==data.err)
    {
        $("#formUserLogin .form-group").eq(0).addClass("has-error");
        $("#formUserLogin .form-group span").eq(0).text("*此帳號已被禁用");
        err++;
    }
    
    if("userNotActivateErr"==data.err)
    {
        $("#formUserLogin .form-group").eq(0).addClass("has-error");
        $("#formUserLogin .form-group span").eq(0).text("*帳號未啟用");
        err++;
    }


    if(0==err)
    {

        return true;
    }
    return false;

    
}





