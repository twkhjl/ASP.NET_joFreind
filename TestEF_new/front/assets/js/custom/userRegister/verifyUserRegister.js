
//reset modal when open it
$("button[data-target='#modalCreateAdmin']").click(function(){
    $("#formUserRegister .form-group").removeClass("has-error");
    $("#formUserRegister .form-group span").text("");
    $("#formUserRegister .form-group input").val("");
})

function verifyUserRegister(data)
{
    if (data.userID !=null)
    {
        return true;
    }

    err=0;

    $("#formUserRegister .form-group").removeClass("has-error");
    $("#formUserRegister .form-group span").text("");

    if(data.indexOf("emailBlankErr") > -1)
    {
        $("#formUserRegister .form-group").eq(0).addClass("has-error");
        $("#formUserRegister .form-group span").eq(0).text("email名稱不可空白");
        err++;
    }
    if (data.indexOf("emailFormatErr") > -1)
    {
        $("#formUserRegister .form-group").eq(0).addClass("has-error");
        $("#formUserRegister .form-group span").eq(0).text("email格式錯誤");
        err++;
    }
    if (data.indexOf("emailExistErr") > -1)
    {
        $("#formUserRegister .form-group").eq(0).addClass("has-error");
        $("#formUserRegister .form-group span").eq(0).text("email已存在");
        err++;
    }
    if (data.indexOf("passwordBlankErr") > -1)
    {
        $("#formUserRegister .form-group").eq(1).addClass("has-error");
        $("#formUserRegister .form-group span").eq(1).text("密碼不可空白");
        err++;
    }

    if (data.indexOf("passwordNotMatchErr") > -1)
    {
        $("#formUserRegister .form-group").eq(2).addClass("has-error");
        $("#formUserRegister .form-group span").eq(2).text("密碼需相符");
        err++;
    }
    if (data.indexOf("nicknameBlankErr") > -1) {
        $("#formUserRegister .form-group").eq(3).addClass("has-error");
        $("#formUserRegister .form-group span").eq(3).text("暱稱不可空白");
        err++;
    }
    if (data.indexOf("nicknameExistErr") > -1) {
        $("#formUserRegister .form-group").eq(3).addClass("has-error");
        $("#formUserRegister .form-group span").eq(3).text("暱稱已被使用");
        err++;
    }


    if(0==err)
    {

        return true;
    }
    return false;


}
