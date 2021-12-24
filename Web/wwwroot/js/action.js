$(document).ready(function () {
    $('body').off('click', '#btn-edit').on('click', '#btn-edit', Edit);
    $('body').off('click', '#btn-save').on('click', '#btn-save', Save);
    $('body').off('click', '#btn-submit').on('click', '#btn-submit', Submit);
    //FillBlankCell()
    function FillBlankCell() {
        var elm = document.getElementsByClassName('cell');
        var len = elm.length;
        for (var i = 0; i < len; i++) {
            if (elm[i]) {
                elm.setAttribute("background-color", "red");
            }
        }
    }

    $('#frm-save').validate({
        rules: {
           
            fm:
            {
                required: true,
            },
            rc:
            {
                required: true,
            },
            ca:
            {
                required: true,
            },
            cpa:
            {
                required: true,
            },
            pt:
            {
                required: true,
            },
            fano:
            {
                required: true,
            },
            sqe:
            {
                required: true,
            },
            mfr:
            {
                required: true,
            },
            fia:
            {
                required: true,
            },
            fiano:
            {
                required: true,
            },
            person:
            {
                required: true,
            },
        },
        messages: {
            rc:
            {
                required: "You need to fill in Root Cause",
            },
            fm:
            {
                required: "You need to fill in Failure Mode",

            },
            fano:
            {
                required: "You need to fill in FA No.",

            },
            pt:
            {
                required: "You need to select this field",
            },
            cpa:
            {
                required: "You need to select this field",
            },           
           
            sqe:
            {
                required: "You need to select this field",
            },
            mfr:
            {
                required: "You need to select this field",
            },
            fia:
            {
                required: "You need to select this field",
            },
            fiano:
            {
                required: "You need to select this field",
            },
            person:
            {
                required: "You need to select this field",
            },
        }
    });

    function Submit() {
        if ($('#frm-save').valid()) {

            //var selectedFile = document.getElementById('upload').files;
            //debugger
            //if (selectedFile.length) {
            //    selectedFile = selectedFile[0];
            //    var getDate = new Date();
            //    var date = getDate.getFullYear().toString() + (getDate.getMonth() + 1) + getDate.getDate() + getDate.getHours() + getDate.getMinutes() + getDate.getSeconds() + getDate.getMilliseconds();
            //    var fileName = selectedFile.name.split('.')[0] + '_' + date + '.' + selectedFile.name.split('.')[1];
            //    uploadFile(selectedFile, date);
            //}

            var model = new Object();
            //CKEDITOR.replace("txt-fm");
            //var content = CKEDITOR.instances['txt-fm'].getData();

            model.Wwyy = $('#txt-ww').text();
            model.CustName = $('#txt-wc').text();
            model.Pn = $('#txt-pn').text();         
            model.ActionId = parseInt($('#actionId').val());
            model.ActionCode = 2
            model.FailureMode = $('#txt-fm').val();
            model.RootCause = $('#txt-rc').val();
            model.ContainmentAction = $('#txt-ca').val();
            model.CorrectiveandPreventiveAction = $('#txt-cpa').val();
            model.PartsCosignedOrTurnkey = $('#txt-pt').val();
            model.Fano = $('#txt-fano').val();
            model.SqelatestStatus = $('#txt-sqe').val();
            model.Mfrfaresult = $('#txt-mfr').val();
            model.Fianeeded = parseInt($('#txt-fia').val());
            //model.Fianeeded = $('#txt-fia option:selected').text();
            model.Fiano = $('#txt-fiano').val();
            model.ResponsiblePerson = $('#txt-person').val();
            model.UpdatedBy = '1099969';
            debugger
            $.ajax({
                type: 'post',
                url: '/action/insert',
                data: JSON.stringify(model),
                dataType: 'json',
                contentType: 'application/json,; charset=utf-8',
                success: function (response) {
                    var data = response.results;
                    debugger
                    if (data.statusCode == 200) {
                        bootbox.alert("Submitted Successfully!", function () { window.location.reload(); })
                    }
                    else
                        bootbox.alert("Submitted Failed!")
                }
            })
        }
    }

    function Edit() {
        $(".error").html('');
        $(".error").removeClass("error");
        var Id = parseInt($(this).data('id'));
        $.ajax({
            type: 'post',
            url: '/action/getbyid',
            dataType: 'json',
            data: { Id: Id },
            success: function (response) {
                var data = response.results[0]
                debugger
                $('#txt-ww').text(data.wwyy);
                $('#txt-wc').text(data.custName);
                $('#txt-pn').text(data.pn);
                $('#txt-fm').val(data.failureMode);
                $('#txt-rc').val(data.rootCause);
                $('#txt-ca').val(data.containmentAction);
                $('#txt-cpa').val(data.correctiveandPreventiveAction);
                $('#txt-qty').text(data.qty);
                $('#txt-pt').val(data.partsCosignedOrTurnkey);
                $('#txt-fano').val(data.fano);
                $('#txt-mfr').val(data.mfrfaresult);
                $('#txt-sqe').val(data.sqelatestStatus);
                $('#txt-fia').val(data.fianeeded);
                $('#txt-fiano').val(data.fiano);
                $('#txt-person').val(data.responsiblePerson);
                $('#txt-remark').val(data.remark);
                $('#actionId').val(Id);
            }
        })
    }


    function Save() {
        var model = new Object();
        //CKEDITOR.replace("txt-fm");
        //var content = CKEDITOR.instances['txt-fm'].getData();

        var dateCode = new Date($("#txt-date").val());
        dateCode = dateCode.getDate() ? dateCode.getFullYear() + '-' + (dateCode.getMonth() + 1) + '-' + dateCode.getDate() + ' ' + dateCode.getHours() + ':' + dateCode.getMinutes() + ':' + dateCode.getSeconds() + '.' + dateCode.getMilliseconds() : null;
        
        model.ActionId = parseInt($('#actionId').val());
        model.ActionCode = 1
        model.DateCode = dateCode;
        model.FailureMode = $('#txt-fm').val();
        model.RootCause = $('#txt-rc').val();
        model.ContainmentAction = $('#txt-ca').val();
        model.CorrectiveandPreventiveAction = $('#txt-cpa').val();
        model.PartsCosignedOrTurnkey = $('#txt-pt').val();
        model.Fano = $('#txt-fano').val();
        model.SqelatestStatus = $('#txt-sqe').val();
        model.Mfrfaresult = $('#txt-mfr').val();
        model.Fianeeded = parseInt($('#txt-fia').val());
        model.Fiano = $('#txt-fiano').val();
        model.ResponsiblePerson = $('#txt-person').val();
        model.Remark = $('#txt-remark').val();      
        model.UpdatedBy = '1099969';
        debugger
        $.ajax({
            type: 'post',
            url: '/action/insert',
            data: JSON.stringify(model),
            dataType: 'json',
            contentType: 'application/json,; charset=utf-8',
            success: function (response) {
                var data = response.results;
                debugger
                if (data.statusCode == 200) {
                    bootbox.alert("Save Successfully!", function () { window.location.reload();})                    
                }
                else
                    bootbox.alert("Save Failed!")               
            }
        })

    }

})