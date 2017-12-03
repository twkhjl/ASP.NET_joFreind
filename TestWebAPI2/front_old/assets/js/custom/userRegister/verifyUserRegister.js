
//reset modal when open it
$("button[data-target='#modalCreateAdmin']").click(function(){
    $("#formUserRegister .form-group").removeClass("has-error");
    $("#formUserRegister .form-group span").text("");
    $("#formUserRegister .form-group input").val("");
})

function verifyUserRegister(data)
{
    err=0;
    
    $("#formUserRegister .form-group").removeClass("has-error");
    $("#formUserRegister .form-group span").text("");

    if(1==data.emailBlankErr)
    {
        $("#formUserRegister .form-group").eq(0).addClass("has-error");
        $("#formUserRegister .form-group span").eq(0).text("email名稱不可空白");
        err++;
    }
    if(1==data.emailFormatErr)
    {
        $("#formUserRegister .form-group").eq(0).addClass("has-error");
        $("#formUserRegister .form-group span").eq(0).text("email格式錯誤");
        err++;
    }
    if(1==data.emailExistErr)
    {
        $("#formUserRegister .form-group").eq(0).addClass("has-error");
        $("#formUserRegister .form-group span").eq(0).text("email已存在");
        err++;
    }
    if(1==data.passwordBlankErr)
    {
        $("#formUserRegister .form-group").eq(1).addClass("has-error");
        $("#formUserRegister .form-group span").eq(1).text("密碼不可空白");
        err++;
    }
  
    if(1==data.passwordNotMatchErr)
    {
        $("#formUserRegister .form-group").eq(2).addClass("has-error");
        $("#formUserRegister .form-group span").eq(2).text("密碼需相符");
        err++;
    }


    if(0==err)
    {

        return true;
    }
    return false;

    
}





