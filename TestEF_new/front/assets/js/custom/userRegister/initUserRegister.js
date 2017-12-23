$('#agreement_modal').modal('show');

//reset w8ing msg
$("#plzw8").html("");

$("#btnAgree").click(function (e) {
    $('#agreement_modal').modal('toggle');
    d = new Date();
    $('#formUserRegister input[name=birthDate]').val(d.getFullYear() + "-" + (d.getMonth()) + "-" + (d.getDate()));
});//end click

$("#btnRegister").click(function () {
    userRegister();
});//end click
