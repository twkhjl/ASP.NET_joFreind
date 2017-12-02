
//reset modal when open it
$("button[data-target='#modalCreateAdmin']").click(function(){
    $("#formCreateAdmin .form-group").removeClass("has-error");
    $("#formCreateAdmin .form-group span").text("");
    $("#formCreateAdmin .form-group input").val("");
})

function verifyCreateAdmin(data)
{
    err=0;
    
    $("#formCreateAdmin .form-group").removeClass("has-error");
    $("#formCreateAdmin .form-group span").text("");

    if(1==data.accountBlankErr)
    {
        $("#formCreateAdmin .form-group").eq(0).addClass("has-error");
        $("#formCreateAdmin .form-group span").eq(0).text("帳號名稱不可空白");
        err++;
    }
    if(1==data.accountFormatErr)
    {
        $("#formCreateAdmin .form-group").eq(0).addClass("has-error");
        $("#formCreateAdmin .form-group span").eq(0).text("帳號格式錯誤");
        err++;
    }
    if(1==data.accountExistErr)
    {
        $("#formCreateAdmin .form-group").eq(0).addClass("has-error");
        $("#formCreateAdmin .form-group span").eq(0).text("帳號已存在");
        err++;
    }
    if(1==data.passwordBlankErr)
    {
        $("#formCreateAdmin .form-group").eq(1).addClass("has-error");
        $("#formCreateAdmin .form-group span").eq(1).text("密碼不可空白");
        err++;
    }
  
    if(1==data.passwordNotMatchErr)
    {
        $("#formCreateAdmin .form-group").eq(2).addClass("has-error");
        $("#formCreateAdmin .form-group span").eq(2).text("密碼需相符");
        err++;
    }


    if(0==err)
    {

        return true;
    }
    return false;

    
}





