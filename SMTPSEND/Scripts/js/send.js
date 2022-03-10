var token = $("input[name=__RequestVerificationToken]").val();
$("#Send").on("click", function () {
    var send = $("#Sender").val();
    var password = $("#Password").val();
    var receive = $("#Receiver").val();
$.ajax({
        url: '/Home/SendEmail',
        type: 'POST',
        dataType: 'json',
    data: { "__RequestVerificationToken": token, "sendermail": send, "password": password, "receivermail": receive },
        success: function (data) {

            $("#piname").text("Name of PI: "+data.NAME);
            $("#designation").text("Designation: "+data.Designation);
            $("#cluster").text("Cluster/Department: "+data.Department);
            $("#institution").text("Institution: "+data.Institution);
            $("#teleno").text("Telephone Number: "+data.TELENO);
            $("#mail").text("Mailing Address: "+data.ADDRESS);
            $("#email").text("Email Address:"+data.EMAIL);
        },
        error: function (xhr) {
        }
    });

});