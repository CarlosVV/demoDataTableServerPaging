$(document).ready(function () {
    $('#mytable').DataTable({
        processing: true,
        serverSide: true,
        ajax: {
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/WebMethod.aspx/Data",
            data: function (d) {
                return JSON.stringify({ parameters: d });
            }
        }
    });
});