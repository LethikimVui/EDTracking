$(document).ready(function () {
    $('body').off('click', '#btn-approve').on('click', '#btn-approve', Approve);
    $('body').off('click', '#btn-reject').on('click', '#btn-reject', Reject);
    //$('body').off('click', '#btn-submit').on('click', '#btn-submit', Submit);

  
    function Reject() {
        var pendingId = parseInt($(this).data('id'));
        var model = new Object();

        model.PendingId = pendingId;
        model.ActionCode = 4;
        model.Remark = $(`#txt-rm-${pendingId}`).val();
        model.UpdatedBy = '1099969';
        debugger
        $.ajax({
            type: 'post',
            url: '/pending/action',
            data: JSON.stringify(model),
            dataType: 'json',
            contentType: 'application/json,; charset=utf-8',
            success: function (response) {
                var data = response.results;
                debugger
                if (data.statusCode == 200) {
                    bootbox.alert("Rejected", function () { window.location.reload(); })
                }
                else {
                    bootbox.alert(data.message)
                }
            }
        })

    }
  

    function Approve() {
        var pendingId = parseInt($(this).data('id'));
        var model = new Object();      
        model.PendingId = pendingId;
        model.ActionCode = 3;  
        model.Remark = $(`#txt-rm-${pendingId}`).val();
        model.UpdatedBy = '1099969';
        debugger
        $.ajax({
            type: 'post',
            url: '/pending/action',
            data: JSON.stringify(model),
            dataType: 'json',
            contentType: 'application/json,; charset=utf-8',
            success: function (response) {
                var data = response.results;
                debugger
                if (data.statusCode == 200) {
                    bootbox.alert("Approved", function () { window.location.reload(); })
                }
                else {
                    bootbox.alert(data.message)
                }
            }
        })

    }

})