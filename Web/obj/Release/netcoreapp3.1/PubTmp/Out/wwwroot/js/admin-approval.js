$(document).ready(function () {
    $('body').off('click', '#btn-add').on('click', '#btn-add', Add);
    $('body').off('click', '#btn-delete').on('click', '#btn-delete', Delete);

    var user = document.getElementById('userinfo').getAttribute('data-user');

    function Add() {
        var model = new Object();
        model.Ntlogin = $('#txt-Ntlogin').val();
        model.CustId = parseInt(document.getElementById("txt-custId").value);
        model.CreatedBy = user;
        debugger
        $.ajax({
            type: 'post',
            url: '/admin/Master_Approval_insert',
            data: JSON.stringify(model),
            contentType: "application/json; charset=utf-8",

            success: function (response) {
                if (response.statusCode.statusCode == 200) {
                    bootbox.alert(response.statusCode.message, function () {
                        location.reload(true);
                    })
                }
                else if (response.statusCode.statusCode == 400) {
                    bootbox.alert(response.statusCode.message)
                }
                else {
                    bootbox.alert("Add Error!")
                }
            }
        })
    }


    function Delete() {
        approvalId = $(this).attr('data-id');
        debugger
        ntlogin = $(this).attr('data-ntlogin');
        var model = new Object();
        model.OwnerId = parseInt(approvalId);
        model.UpdatedBy = user;
        $.ajax({
            type: 'post',
            url: '/admin/Master_Approval_delete',
            data: JSON.stringify(model),
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                var data = response.statusCode;
                if (data == 200) {
                    bootbox.alert(`${ntlogin} is deleted`, function () {
                        location.reload(true);
                    })
                }
                else {
                    bootbox.alert("Error");
                }
            }
        })
    }
})