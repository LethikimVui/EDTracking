$(document).ready(function () {
    $('body').off('click', '#btn-search').on('click', '#btn-search', Load);
    $('body').off('click', '#btn-reset').on('click', '#btn-reset', Reset);

    $('body').off('click', '#btn-edit').on('click', '#btn-edit', Edit);
    $('body').off('click', '#btn-save').on('click', '#btn-save', Save);
    $('body').off('click', '#btn-submit').on('click', '#btn-submit', Submit);
    $('body').off('click', '#btn-acknowedge-confirm').on('click', '#btn-acknowedge-confirm', Acknowledge);
    $('body').off('click', '#btn-complete').on('click', '#btn-complete', Complete);
    $('body').off('click', '#btn-acknowledge').on('click', '#btn-acknowledge', Confirm);

    $('body').off('click', '#btn-export').on('click', '#btn-export', DownloadAsExcel);

    var user = document.getElementById('userinfo').getAttribute('data-user');
    var name = document.getElementById('userinfo').getAttribute('data-display-name');
    var email = document.getElementById('userinfo').getAttribute('data-email');

    $('body').off('click', '#btn-test').on('click', '#btn-test', test);
    function test() {
        bootbox.alert($("#txt-status-search").val().toString());
        //bootbox.alert($('#txt-status-search option:selected').text().toString());
    }

    function Load() {
        $("#tbl-content").html("");
        if ($('#txt-wc-search').val()) {
            LoadData();
        }
        else {
            bootbox.alert('Please select customer!')
        }
    }

    function Reset() {
        window.location.reload();
    }

    function Confirm() {
        var Id = parseInt($(this).data('id'));
        var pn = document.getElementById('btn-acknowledge').getAttribute('data-pn');
        var wwyy = document.getElementById('btn-acknowledge').getAttribute('data-wwyy');
        var custname = document.getElementById('btn-acknowledge').getAttribute('data-custname');
        $('#confirm').val(Id);
        $('#confirm').attr('data-pn', pn.toString());
        $('#confirm').attr('data-wwyy', wwyy.toString());
        $('#confirm').attr('data-custname', custname.toString());

        debugger

    }
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
            datecode:
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
            ws:
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
            datecode:
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
            ws:
            {
                required: "You need to select this field",
            },
        }
    });

    function Submit() {
        if ($('#frm-save').valid()) {

            var fileName = "";
            var getDate = new Date();
            var date = getDate.getFullYear().toString() + (getDate.getMonth() + 1) + getDate.getDate() + getDate.getHours() + getDate.getMinutes() + getDate.getSeconds() + getDate.getMilliseconds();
            var selectedFile = document.getElementById('upload').files;
            if (selectedFile.length) {
                for (let i = 0; i < selectedFile.length; i++) {
                    fileName += selectedFile[i].name.split('.')[0] + '_' + date + '.' + selectedFile[i].name.split('.')[1] + ';';
                    uploadFile(selectedFile[i], date);
                }
            }

            var model = new Object();

            model.Wwyy = $('#txt-ww').text();
            model.CustName = $('#txt-wc').text();
            model.Pn = $('#txt-pn').text();
            model.ActionId = parseInt($('#actionId').val());
            model.ActionCode = 2 // submit
            model.DateCode = $('#txt-datecode').val();
            model.FailureMode = $('#txt-fm').val();
            model.RootCause = $('#txt-rc').val();
            model.ContainmentAction = $('#txt-ca').val();
            model.CorrectiveandPreventiveAction = $('#txt-cpa').val();
            model.PartsCosignedOrTurnkey = $('#txt-pt').val();
            model.Fano = $('#txt-fano').val();
            model.Mfrfaresult = $('#txt-mfr').val();
            model.Fianeeded = parseInt($('#txt-fia').val());
            model.WeeklyStatus = $('#txt-ws').val();
            model.Fiano = $('#txt-fiano').val();
            model.ResponsiblePerson = $('#txt-person').val();
            model.Remark = $('#txt-rm').val() ? ': ' + $('#txt-rm').val() + '\r\n' : '\r\n';
            model.FileName = fileName ? fileName : null;
            model.UpdatedBy = user;
            model.UpdatedName = name;
            model.UpdatedEmail = email;

            debugger
            $.ajax({
                type: 'post',
                url: '/action/Action_update',
                data: JSON.stringify(model),
                dataType: 'json',
                contentType: 'application/json,; charset=utf-8',
                success: function (response) {
                    var data = response.results;
                    debugger
                    if (data.statusCode == 200) {
                        bootbox.alert("Submitted Successfully!", function () { $('#myModal').modal('hide'); LoadData(); })
                    }
                    else
                        bootbox.alert("Submitted Failed!")
                }
            })
        }
    }
    function handleFiles() {
        debugger
        if (!this.files.length) {
            fileList.innerHTML = "<p>No files selected!</p>";
        }
        else {
            fileList.innerHTML = "";
            const list = document.createElement("ul");
            fileList.appendChild(list);
            for (let i = 0; i < this.files.length; i++) {
                const li = document.createElement("li");
                li.appendChild(document.createTextNode(this.files[i].name))
                list.appendChild(li);
            }
        }
    }
    function Edit() {
        $(".error").html('');
        $(".error").removeClass("error");
        var Id = parseInt($(this).data('id'));
        var model = new Object();
        model.ActionId = parseInt(Id);
        $.ajax({
            type: 'post',
            url: '/action/Action_get',
            dataType: 'json',
            data: JSON.stringify(model),
            contentType: 'application/json,; charset=utf-8',
            success: function (response) {
                var data = response.results[0]
                debugger
                $('#txt-ww').text(data.wwyy);
                $('#txt-wc').text(data.custName);
                $('#txt-datecode').val(data.dateCode);
                $('#txt-pn').text(data.pn);
                $('#txt-fm').val(data.failureMode);
                $('#txt-rc').val(data.rootCause);
                $('#txt-ca').val(data.containmentAction);
                $('#txt-cpa').val(data.correctiveandPreventiveAction);
                $('#txt-qty').text(data.qty);
                $('#txt-pt').val(data.partsCosignedOrTurnkey);
                $('#txt-fano').val(data.fano);
                $('#txt-mfr').val(data.mfrfaresult);
                $('#txt-fia').val(data.fianeeded);
                $('#txt-fiano').val(data.fiano);
                $('#txt-person').val(data.responsiblePerson);
                $('#txt-ws').val(data.weeklyStatus);
                $('#actionId').val(Id);

            }
        })

        var selectedFile = document.getElementById('upload')
        selectedFile.value = "";
        fileList = document.getElementById("fileList");
        fileList.innerHTML = "";
        const list = document.createElement("ul");
        fileList.appendChild(list);
        selectedFile.addEventListener("change", handleFiles, false);
    }

    function Save() {

        var fileName = "";
        var getDate = new Date();
        var date = getDate.getFullYear().toString() + (getDate.getMonth() + 1) + getDate.getDate() + getDate.getHours() + getDate.getMinutes() + getDate.getSeconds() + getDate.getMilliseconds();
        var selectedFile = document.getElementById('upload').files;
        if (selectedFile.length) {
            for (let i = 0; i < selectedFile.length; i++) {
                fileName += selectedFile[i].name.split('.')[0] + '_' + date + '.' + selectedFile[i].name.split('.')[1] + ';';
                uploadFile(selectedFile[i], date);
            }
        }

        var model = new Object();      

        model.ActionId = parseInt($('#actionId').val());
        model.ActionCode = 1 // save
        model.DateCode = $('#txt-datecode').val();
        model.FailureMode = $('#txt-fm').val();
        model.RootCause = $('#txt-rc').val();
        model.ContainmentAction = $('#txt-ca').val();
        model.CorrectiveandPreventiveAction = $('#txt-cpa').val();
        model.PartsCosignedOrTurnkey = $('#txt-pt').val();
        model.Fano = $('#txt-fano').val();
        model.Mfrfaresult = $('#txt-mfr').val();
        model.Fianeeded = parseInt($('#txt-fia').val()) ? parseInt($('#txt-fia').val()) : 0;
        model.Fiano = $('#txt-fiano').val();
        model.WeeklyStatus = $('#txt-ws').val();
        model.ResponsiblePerson = $('#txt-person').val();
        model.Remark = $('#txt-rm').val() ? ': ' + $('#txt-rm').val() + '\r\n' : '\r\n'; //$('#txt-remark').val() + "\r\n";    
        model.FileName = fileName ? fileName : null;
        model.UpdatedBy = user;
        model.UpdatedName = name;
        model.UpdatedEmail = email;


        debugger
        $.ajax({
            type: 'post',
            url: '/action/Action_update',
            data: JSON.stringify(model),
            dataType: 'json',
            contentType: 'application/json,; charset=utf-8',
            success: function (response) {
                var data = response.results;
                debugger
                if (data.statusCode == 200) {
                    bootbox.alert("Save Successfully!", function () { LoadData(); })
                }
                else
                    bootbox.alert("Save Failed!")
            }
        })
    }

    function Acknowledge() {
        var actionId = parseInt($('#confirm').val());
        var model = new Object();

        model.ActionId = actionId;
        model.ActionCode = 4; //Ackowledge
        model.Remark = $('#txt-rm').val() ? ': ' + $('#txt-rm').val() + '\r\n' : '\r\n';
        model.UpdatedBy = user;
        model.UpdatedName = name;
        model.UpdatedEmail = email;
        model.CustName = document.getElementById('confirm').getAttribute('data-custname');
        model.Pn = document.getElementById('confirm').getAttribute('data-pn');
        model.WWyy = document.getElementById('confirm').getAttribute('data-wwyy');
        debugger
        $.ajax({
            type: 'post',
            url: '/Action/Acknowledge',
            data: JSON.stringify(model),
            dataType: 'json',
            contentType: 'application/json,; charset=utf-8',
            success: function (response) {
                var data = response.results;
                debugger
                if (data.statusCode == 200) {
                    bootbox.alert("Acknowledged", function () { $('#myModal').modal('hide'); LoadData(); })
                }
                else {
                    bootbox.alert(data.message)
                }
            }
        })

    }

    function Complete() {
        var actionId = parseInt($('#confirm').val());
        var model = new Object();
        model.ActionId = actionId;
        model.ActionCode = 5; //Complete
        model.Remark = $('#txt-rm').val() ? ': ' + $('#txt-rm').val() + '\r\n' : '\r\n';
        model.UpdatedBy = user;
        model.UpdatedEmail = email;

        model.CustName = document.getElementById('confirm').getAttribute('data-custname');
        model.Pn = document.getElementById('confirm').getAttribute('data-pn');
        model.WWyy = document.getElementById('confirm').getAttribute('data-wwyy');
        debugger
        $.ajax({
            type: 'post',
            url: '/Action/Acknowledge',
            data: JSON.stringify(model),
            dataType: 'json',
            contentType: 'application/json,; charset=utf-8',
            success: function (response) {
                var data = response.results;
                debugger
                if (data.statusCode == 200) {
                    bootbox.alert("Completed", function () { $('#myModal').modal('hide');  LoadData(); })
                }
                else {
                    bootbox.alert(data.message)
                }
            }
        })

    }

    function LoadData() {
        var model = new Object();

        model.Wwyy = $('#txt-ww-search').val() ? $('#txt-ww-search').val() : null;
        model.CustId = parseInt($('#txt-wc-search').val());
        model.Pn = $('#txt-pn-search').val() ? $('#txt-pn-search').val() : null;
        model.Status = $("#txt-status-search").val() ? $("#txt-status-search").val().toString() : null
        debugger
        $.ajax({
            type: 'post',
            url: '/action/Get_partial',
            data: JSON.stringify(model),
            contentType: 'application/json,; charset=utf-8',
            success: function (data) {
                $("#tbl-content").html(data);
            }
        })


    }

    const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
    const EXCEL_EXTENSION = '.xlsx';

    function DownloadAsExcel() {
        var data = [];

        if ($('#txt-wc-search').val()) {
            var model = new Object();
            model.Wwyy = $('#txt-ww-search').val() ? $('#txt-ww-search').val() : null;
            model.CustId = parseInt($('#txt-wc-search').val());
            model.Pn = $('#txt-pn-search').val() ? $('#txt-pn-search').val() : null;
            debugger
            $.ajax({
                async: false,
                type: 'post',
                url: '/Action/Action_export',
                data: JSON.stringify(model),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    data = response.result;
                    const worksheet = XLSX.utils.json_to_sheet(data);
                    const workbook = {
                        Sheets: {
                            'data': worksheet
                        },
                        SheetNames: ['data']
                    };
                    const excelBuffer = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
                    SaveAsExcel(excelBuffer, 'Q3');
                }
            });
        }
        else {
            bootbox.alert('Please select customer!')
        }
    }

    function SaveAsExcel(buffer, filename) {
        var dateTime = new Date(Date.now());
        var strDateTime = dateTime.getFullYear() + '' + (dateTime.getMonth() + 1) + dateTime.getDate() + dateTime.getHours() + dateTime.getMinutes() + dateTime.getMilliseconds();
        const data = new Blob([buffer], { type: EXCEL_TYPE });
        debugger
        saveAs(data, filename + strDateTime + EXCEL_EXTENSION);

    }

    function uploadFile(_file, _date) {
        var form_data = new FormData();
        form_data.append("files", _file);
        form_data.append("date", _date);
        debugger
        $.ajax({
            type: 'post',
            url: '/Action/UploadFile',
            data: form_data,
            contentType: false,
            dataType: 'json',
            processData: false,
            cache: false,
            success: function (data) {
                //console.log(data)
            }
        })
    }
})