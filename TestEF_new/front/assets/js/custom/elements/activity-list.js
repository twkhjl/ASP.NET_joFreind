//set sidebar
getCategories();

//set items
getContents();


$("#btnList").click(function(e){
    e.preventDefault();
    sessionStorage.setItem("activityListType","dataTable");
    getContents();
})

$("#btnTh").click(function(e){
    e.preventDefault();
    sessionStorage.setItem("activityListType","th");
    getContents();
})





function getContents()
{
  if(sessionStorage.getItem("activityListType")=="dataTable")
  {
    if(sessionStorage.getItem("activityListCategoryID")!=null)
    {
      $url='../../api/activities/category/id/'+
      sessionStorage.getItem("activityListCategoryID");

      setActivityListAsDataTable($url);
    }
    else
    {
      $url='../../api/activities';
      setActivityListAsDataTable($url);
    }
  }
  else
  {
    if(sessionStorage.getItem("activityListCategoryID")!=null)
    {
      $url='../../api/activities/category/id/'+
      sessionStorage.getItem("activityListCategoryID");

      setActivityListAsTh($url);
    }
    else
    {
      $url='../../api/activities';
      setActivityListAsTh($url);
    }
  }
}


//function
function getCategories(e)
{
    $.ajax({
        type: 'GET',
        url: '../api/categories',
        dataType: 'json',
        success: function (data) {
          $(".panel-body .nav.nav-pills.nav-stacked").append("<li class='active'><a href='' data-category='all'>所有活動</a></li>");

          $.each(data,function(index,element)
          {
            $(".panel-body .nav.nav-pills.nav-stacked")
            .append("<li><a href='' data-category='"+element.CategoryID+'\'>'+element.name+"</a></li>")
          });//end each

          $(".panel-body .nav.nav-pills.nav-stacked li a").click(function(e){
            e.preventDefault();
            //set clicked item css as active
            $(".nav.nav-pills.nav-stacked li").removeClass("active");
            $(this).parent().addClass("active");

            //change content dunamically
            if(sessionStorage.getItem("activityListType")=="dataTable")
            {
              if($(this).attr('data-category')=='all')
              {
                $url='../../api/activities';
                setActivityListAsDataTable($url);
              }
              else
              {
                sessionStorage.setItem("activityListCategoryID",$(this).attr('data-category'))
                $url='../../api/activities/category/id/'+$(this).attr('data-category');
                setActivityListAsDataTable($url);
              }
            }
            else
            {

              if($(this).attr('data-category')=='all')
              {
                $url='../../api/activities';
                setActivityListAsTh($url);
              }
              else
              {
                sessionStorage.setItem("activityListCategoryID",$(this).attr('data-category'))
                $url='../../api/activities/category/id/'+$(this).attr('data-category');
                setActivityListAsTh($url);
              }
            }
          })

        }//end success
    });//end ajax
}//end func


function setActivityListAsTh($url)
{
  $.ajax({
        type: 'GET',
        url: $url,
        dataType: 'json',
        success: function (data) {
          strItems="";
          $.each(data,function(index,element){
            strItems+=getActivityItemBlock(index+1,
              "activity-detail.html",
              element.title,
              element.content,
              element.activityID
            );
          })//end each
          //set items
          $("#content .container .row .col-md-9").html("<div class='row'>"+strItems+"</div>");

          //set event
          setClickEvent();
        }//end success function
    });//end ajax

    $('<script>').attr({
      // src: "https://maps.googleapis.com/maps/api/js?key=AIzaSyBu1J3PS0EeD6UISx1W-oEUnaFVPUEbaq0&language=zh-tw&callback=myMap",
      src: GOOGLE_MAP_API_SRC,//global var is located in assets/js/config.js
      type: 'text/javascript'}).appendTo('body')
}//end func



function getActivityItemBlock(mapID,detailUrl,title,content,activityID)
{
    var activityBlock = [
     '    <div class="col-md-4">',
     '      <div class="box-image-text">',
     '          <div class="top">',
     '              <div class="image">',
     '                <div id="googleMap'+mapID+'" style="width:100%;height:300px;"></div>',
     '              </div>',
     '              <div class="bg"></div>',
     '              <div class="text">',
     '                  <p class="buttons">',
     '                      <a href="'+detailUrl+'" class="btn btn-template-transparent-primary" data-id="'+activityID+'"><i class="fa fa-link"></i>詳細內容</a>',
     '                  </p>',
     '              </div>',
     '          </div>',
     '          <div class="content">',
     '              <h4><a href="blog-post.html">'+title+'</a></h4>',
     '              <p>'+content+'</p>',
     '              <p class="read-more"><a href="#" class="btn btn-template-main">參加活動</a>',
     '          </div>',
     '      </div>',
     '    </div>'
    ].join('\n');

  return activityBlock;
}//end func



function myMap(){
    $.ajax({
        type: 'GET',
        url: '../../api/activities',
        // contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        dataType: 'json',
        success: function (data) {
          mapOptions=[];
          maps=[];
          markers=[];
          cnt=1;
           for (var i = 0; i < data.length; i++)
           {
              mapOptions[i] = {
                center: new google.maps.LatLng(data[i].longitude,data[i].latitude),
                zoom:16,
                mapTypeId: google.maps.MapTypeId.ROADMAP
              };
              maps[i] = new google.maps.Map(document.getElementById("googleMap"+cnt),mapOptions[i] );
              markers[i] = new google.maps.Marker({position:mapOptions[i].center});
              markers[i].setMap(maps[i]);
              cnt++;
            };//end for
        }//end success function
    });//end ajax
}//end myMap


//-------------dataTable--------------------
function setActivityListAsDataTable($url)
{
  $.ajax({
  type: 'GET',
  url: $url,
  dataType: 'json',
  success: function (data) {
      tableStr = "<table id='myTable' class='table table-striped'>";
      tableStr += "<thead><tr>";
      tableStr += "<td>#</td>";
      tableStr += "<td>活動名稱</td>";
      tableStr += "<td>創立者</td>";
      tableStr += "<td>活動分類</td>";
      tableStr += "<td>開始時間</td>";
      tableStr += "<td>結束時間</td>";
      tableStr += "</tr></thead>";
      tableStr += "<tbody>";

      cnt=1;
      $.each(data,function(index,value){
          tableStr += "<tr>";
          tableStr += "<td>"+cnt+"</td>";
          cnt++;
          // <a href="'+detailUrl+'" class="btn btn-template-transparent-primary" data-id="'+activityID+'"><i class="fa fa-link"></i>詳細內容</a>'
          tableStr += "<td><a href='activity-detail.html' data-id="+data[index].activityID+">"+data[index].title+"</td>";
          tableStr += "<td>"+data[index].userNickName+"</td>";
          tableStr += "<td>"+data[index].categoryName+"</td>";

          //getDateFormat() is located in assets/js/custom/common/commonFunc.js
          var $beginAt = getDateFormat(data[index].beginAt);
          var $endAt = getDateFormat(data[index].endAt);
          tableStr += "<td>"+$beginAt+"</td>";
          tableStr += "<td>"+$endAt +"</td>";
          tableStr += "</tr>";
          });//end each
          tableStr += "</tbody></table>";
          $("#content .container .row .col-md-9").html(tableStr);
          $('#myTable').DataTable({
              "language" : {
                  "paginate" : {"previous": "前頁", "next":"次頁"},
                  "search" : "搜尋",
                  "searchPlaceholder" : "請輸入搜尋關鍵字",
                  "lengthMenu" : "每頁 _MENU_ 筆",
                  "infoFiltered" : " ( 篩選前資料總筆數: _MAX_ 筆 )",
                  "info" : "顯示 _START_ 至 _END_ 筆 / 總筆數: _TOTAL_ 筆 "
              }
          });//end dataTable

          //customize dataTablr
          $("input[type=search]").hide();
          $("label:contains('搜尋')").hide();

          //set event
          setClickEvent();

      }//end success
  });//end ajax
}



//----------------------

function setClickEvent()
{
  $("a[data-id]").click(function(e){
    sessionStorage.setItem(ACTIVITY_ITEM_ID,$(this).attr("data-id"));
  })
}




//--------------------------------------------------------

//ver1.1
//--------------------------------
// mapOptions=[];
// maps=[];
// markers=[];
// function myMap(){
//     for (var i = 0; i < 6; ++i) {
//       mapOptions[i] = {
//         center: new google.maps.LatLng(51.508742,-0.120850),
//         zoom:9,
//         mapTypeId: google.maps.MapTypeId.ROADMAP
//       }
//       maps[i] = new google.maps.Map(document.getElementById("googleMap"+(i+1)),mapOptions[i] );

//       markers[i] = new google.maps.Marker({position:mapOptions[i].center});
//       markers[i].setMap(maps[i]);

//   };
// }
//--------------------------------




//ver1.0
//====================================================================

// function myMap() {
  // var mapOptions1 = {
  //   center: new google.maps.LatLng(51.508742,-0.120850),
  //   zoom:9,
  //   mapTypeId: google.maps.MapTypeId.ROADMAP
  // };
  // var mapOptions2 = {
  //   center: new google.maps.LatLng(51.508742,-0.120850),
  //   zoom:9,
  //   mapTypeId: google.maps.MapTypeId.SATELLITE
  // };
  // var mapOptions3 = {
  //   center: new google.maps.LatLng(51.508742,-0.120850),
  //   zoom:9,
  //   mapTypeId: google.maps.MapTypeId.HYBRID
  // };
  // var mapOptions4 = {
  //   center: new google.maps.LatLng(51.508742,-0.120850),
  //   zoom:9,
  //   mapTypeId: google.maps.MapTypeId.TERRAIN
  // };
  // var mapOptions5 = {
  //   center: new google.maps.LatLng(51.508742,-0.120850),
  //   zoom:9,
  //   mapTypeId: google.maps.MapTypeId.TERRAIN
  // };
  // var mapOptions6 = {
  //   center: new google.maps.LatLng(51.508742,-0.120850),
  //   zoom:14,
  //   mapTypeId: google.maps.MapTypeId.ROADMAP
  // };

  // var map1 = new google.maps.Map(document.getElementById("googleMap1"),mapOptions1);
  // var map2 = new google.maps.Map(document.getElementById("googleMap2"),mapOptions2);
  // var map3 = new google.maps.Map(document.getElementById("googleMap3"),mapOptions3);
  // var map4 = new google.maps.Map(document.getElementById("googleMap4"),mapOptions4);
  // var map5 = new google.maps.Map(document.getElementById("googleMap5"),mapOptions5);
  // var map6 = new google.maps.Map(document.getElementById("googleMap6"),mapOptions6);
  //
  // var marker1 = new google.maps.Marker({position:mapOptions1.center});
  // var marker2 = new google.maps.Marker({position:mapOptions2.center});
  // var marker3 = new google.maps.Marker({position:mapOptions3.center});
  // var marker4 = new google.maps.Marker({position:mapOptions4.center});
  // var marker5 = new google.maps.Marker({position:mapOptions5.center});
  // var marker6 = new google.maps.Marker({position:mapOptions6.center});
  // marker1.setMap(map1);
  // marker2.setMap(map2);
  // marker3.setMap(map3);
  // marker4.setMap(map4);
  // marker5.setMap(map5);
  // marker6.setMap(map6);
// }
