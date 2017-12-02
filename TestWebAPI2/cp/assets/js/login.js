//reset label text
$("#lblErr").text("").removeClass("text-danger");;

$("#btnLogin").click(function (e) {
    //e.preventDefault();

    var $account = $('input[name=account]').val();
    var $password = $('input[name=password]').val();

    $.ajax({
        type: 'POST',
        url: '../api/adminLogin',
        data: { account: $account,password:$password},
        dataType: 'json',
        success: function (data) {
            console.log(data);
            if(data.err!=null)
            {
                $("#lblErr").text("*帳號或密碼錯誤").addClass("text-danger");
                return;
            }
            window.location = "index.html";
            localStorage.setItem("loginName", $account);
            
        }
    });

})