function showUsersTable()
{

    $.ajax({
        type: 'GET',
        url: '../api/users',
        dataType: 'json',
        success: function (data) {

            tableStr = "<table id='userTable' class='table table-striped'>";
            tableStr += "<thead><tr>";
            tableStr += "<td>#</td>";
            tableStr += "<td>帳號名稱</td>";
            tableStr += "<td>狀態</td>";
            tableStr += "<td>註冊方式</td>";
            tableStr += "<td>建立日期</td>";
            tableStr += "<td>修改日期</td>";
            tableStr += "<td></td>";
            tableStr += "</tr></thead>";
            tableStr += "<tbody>";

            sn=1;

            $.each(data,function(index,value){
                var btnEditProfile = "<button type='button' onclick='editRecord(this)' class='btn btn-primary btn-flat' data-toggle='modal' data-target='#modal-edit' data-rowNum='"+data[index].adminID+"'><i class='fa fa-pencil-square-o' aria-hidden='true'></i></button>";
                var btnEditPwd = "<button type='button' onclick='editUserPwd(this)' class='btn btn-primary btn-flat' data-toggle='modal' data-target='#modalEditPwd' data-rowNum='"+data[index].adminID+"'><i class='fa fa-key' aria-hidden='true'></i></button>";
                var btnDel = "<button type='button' onclick='delRecord(this)' class='btn btn-info btn-flat' data-rowNum='"+data[index].adminID+"'><i class='fa fa-times' aria-hidden='true'></i></button>";

                tableStr += "<tr>";
                tableStr += "<td>"+sn+"</td>";
                tableStr += "<td class='email'>"+data[index].email+"</td>";
                tableStr += "<td class='status'>"+((data[index].status==0)?"未開通":"已開通")+"</td>";

                tableStr += "<td class='registerMode'>"+((data[index].registerMode==0)?"本地註冊":"外部註冊")+"</td>";
                tableStr += "<td>"+data[index].createAt+"</td>";
                tableStr += "<td>"+data[index].updateAt+"</td>";
                tableStr += "<td>"+btnEditProfile+" "+btnEditPwd+" "+btnDel+"</td>";
                tableStr += "</tr>";
                sn++;
            });

            tableStr += "</tbody></table>";

            $("#adminTableContainer").html(tableStr);


            $('#adminTable').DataTable({
                "language" : {
                    "paginate" : {"previous": "前頁", "next":"次頁"},
                    "search" : "搜尋",
                    "searchPlaceholder" : "請輸入搜尋關鍵字",
                    "lengthMenu" : "每頁 _MENU_ 筆",
                    "infoFiltered" : " ( 篩選前資料總筆數: _MAX_ 筆 )",
                    "info" : "顯示 _START_ 至 _END_ 筆 / 總筆數: _TOTAL_ 筆 "
                }
            });//end dataTable
        }
    });
}
