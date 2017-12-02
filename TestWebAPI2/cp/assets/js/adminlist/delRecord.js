
function delRecord(caller){
    
adminAuth();

    var retVal = confirm("資料即將刪除,是否確定?");
    if( retVal == false )
    {
       return false;
    }

    $.ajax({
        type: 'POST',
        url: '../api/admins/del',
        data: {adminID:$(caller).attr("data-rowNum")},
        // contentType: 'application/x-www-form-urlencoded; charset=utf-8',
         dataType: 'text',
        success: function (data) {
            //console.log(data);
            showAdminTable();
        }
    });
}




