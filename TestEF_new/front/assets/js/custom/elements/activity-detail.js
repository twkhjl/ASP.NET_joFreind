var $activityItemID = sessionStorage.getItem(ACTIVITY_ITEM_ID);

function myMap() {
  $.ajax({
        type: 'GET',
        url: '../../api/activity/id/'+$activityItemID ,
        // contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        dataType: 'json',
        success: function (data) {
          func1(data);
          var mapOptions = {
            center: new google.maps.LatLng(data[0].longitude,data[0].latitude),
            zoom:16,
            mapTypeId: google.maps.MapTypeId.ROADMAP
          };

          var map = new google.maps.Map(document.getElementById("googleMap"),mapOptions);
          var marker = new google.maps.Marker({position:mapOptions.center});
          marker.setMap(map);
        }//end success function
    });//end ajax
}//end func

$('<script>').attr({
  src: GOOGLE_MAP_API_SRC,//global var is located in assets/js/config.js
  type: 'text/javascript'}).appendTo('body');



function func1(data)
{
  console.log(data);
  $(".heading h2").eq(0).html(data[0].title);
  $(".heading").next().eq(0).html(data[0].content);
  $(".heading").next().eq(1).html(data[0].remarks);
  $(".col-sm-4 p").eq(0).html(data[0].userNickName);
  $(".col-sm-4 p").eq(1).html(data[0].cost);
  var $beginAt = getDateFormat(data[0].beginAt);
  var $endAt = getDateFormat(data[0].endAt);
  $(".col-sm-4 p").eq(2).text($beginAt);
  $(".col-sm-4 p").eq(3).text($endAt);
  $(".col-sm-4 p").eq(4).html(data[0].address);
  $(".col-sm-4 p").eq(5).html(data[0].phone);
}


//-----------------------------

// function myMap() {
//
//   var mapOptions = {
//     center: new google.maps.LatLng(51.508742,-0.120850),
//     zoom:16,
//     mapTypeId: google.maps.MapTypeId.ROADMAP
//   };
//
//   var map = new google.maps.Map(document.getElementById("googleMap"),mapOptions);
//   var marker = new google.maps.Marker({position:mapOptions.center});
//   marker.setMap(map);
// }
//
// $('<script>').attr({
//   src: GOOGLE_MAP_API_SRC,//global var is located in assets/js/config.js
//   type: 'text/javascript'}).appendTo('body');
