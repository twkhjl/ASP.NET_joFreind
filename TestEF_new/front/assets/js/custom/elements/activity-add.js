

setCategoryItem();


//set event
$("form button[type=submit]").click(function(e){
  e.preventDefault();
  console.log("submit");
})


//set css
$("textarea").css({
  "resize":"none",
  "height":"150px",
});

//function
function setCategoryItem(){
  $.ajax({
        type: 'GET',
        url: '../../api/categories' ,
        // contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        dataType: 'json',
        success: function (data) {

          strItems="";
          $.each(data,function(i,e){
            strItems+="<option value="+e.CategoryID+">"+e.name+"</option>";
          })
          $("select[name=categoryID]").html(strItems);
        }
      });//end ajax
}//end func

//----google map--------------------------
var lng=22.628683;
var lat=120.293662;

function myMap() {
  var mapOptions = {
    center: new google.maps.LatLng(lng,lat),
    zoom:16,
    mapTypeId: google.maps.MapTypeId.ROADMAP
  };

  var map = new google.maps.Map(document.getElementById("googleMap"),mapOptions);
  var marker = new google.maps.Marker({
    position:mapOptions.center,
    draggable:true,
  });
  marker.addListener('dragend', function(e) {
    // map.setZoom(16);
    // map.setCenter(marker.getPosition());
    lat = e.latLng.lat().toFixed(10);
    lng = e.latLng.lng().toFixed(10);
  });
  marker.setMap(map);
}//end func

$('<script>').attr({
  src: GOOGLE_MAP_API_SRC,//global var is located in assets/js/config.js
  type: 'text/javascript'}).appendTo('body');

//----/google map--------------------------
