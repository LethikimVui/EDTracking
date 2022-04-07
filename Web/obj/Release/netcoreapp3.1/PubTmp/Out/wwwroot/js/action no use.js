$(document).ready(function () {
    $('body').off('click', '#btn-edit').on('click', '#btn-edit', Edit);
    $('body').off('click', '#btn-save').on('click', '#btn-save', Save);
    $('body').off('click', '#btn-submit').on('click', '#btn-submit', Submit);
    $('body').off('click', '#btn-acknowedge').on('click', '#btn-acknowedge', Acknowledge);
    $('body').off('click', '#btn-complete').on('click', '#btn-complete', Complete);
    $('body').off('click', '#btn').on('click', '#btn', Confirm);

    var user = document.getElementById('userinfo').getAttribute('data-user');
    function Confirm() {
        debugger
        var Id = parseInt($(this).data('id'));
        $('#actionId1').val(Id);

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
            model.Remark = $('#txt-rm').val() ? ': ' + $('#txt-rm').val() + '\r\n' : '\r\n'; //$('#txt-remark').val() + "\r\n";
            model.UpdatedBy = user;
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
                $('#txt-fia').val(data.fianeeded);
                $('#txt-fiano').val(data.fiano);
                $('#txt-person').val(data.responsiblePerson);
                $('#txt-ws').val(data.weeklyStatus);
                $('#actionId').val(Id);

                const selectedFile = document.getElementById('attachment')
                fileList = document.getElementById("fileList");
                fileList.innerHTML = "";
                const list = document.createElement("ul");
                fileList.appendChild(list);
                //var form_data = new FormData();

                selectedFile.addEventListener("change", handleFiles, false);
                function handleFiles() {
                    debugger
                   
                    for (let i = 0; i < this.files.length; i++) {
                        const li = document.createElement("li");
                        
                        li.appendChild(document.createTextNode(this.files[i].name))
                        list.appendChild(li);
                        //form_data.append("files", this.files[i]);
                    }
                }
                //function handleFiles() {
                //    debugger
                //    if (!this.files.length) {
                //        fileList.innerHTML = "<p>No files selected!</p>";
                //    } else {
                //        fileList.innerHTML = "";
                //        const list = document.createElement("ul");
                //        fileList.appendChild(list);
                //        for (let i = 0; i < this.files.length; i++) {
                //            const li = document.createElement("li");
                //            form_data.append("files", this.files[i]);
                //            li.appendChild(document.createTextNode(this.files[i].name))
                //            list.appendChild(li);
                //        }
                //    }
                //}
            }
        })
    }


    function Save() {
        var model = new Object();
        //CKEDITOR.replace("txt-fm");
        //var content = CKEDITOR.instances['txt-fm'].getData();

        const selectedFile = document.getElementById('attachment').files,
            fileList = document.getElementById("fileList");
        debugger
        var getDate = new Date();
        var date = getDate.getFullYear().toString() + (getDate.getMonth() + 1) + getDate.getDate() + getDate.getHours() + getDate.getMinutes() + getDate.getSeconds() + getDate.getMilliseconds();
        var fileName = "";
        for (var i = 0; i < selectedFile.length; i++) {
            console.log(selectedFile[i].name);
            fileName = selectedFile[i].name.split('.')[0] + '_' + date + '.' + selectedFile[i].name.split('.')[1];
            console.log(fileName);
        }

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
        model.Fianeeded = parseInt($('#txt-fia').val());
        model.Fiano = $('#txt-fiano').val();
        model.WeeklyStatus = $('#txt-ws').val();

        model.ResponsiblePerson = $('#txt-person').val();
        model.Remark = $('#txt-rm').val() ? ': ' + $('#txt-rm').val() + '\r\n' : '\r\n'; //$('#txt-remark').val() + "\r\n";      
        model.UpdatedBy = user;
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
                    bootbox.alert("Save Successfully!", function () { window.location.reload(); })
                }
                else
                    bootbox.alert("Save Failed!")
            }
        })
    }

    function Acknowledge() {
        var actionId = parseInt($('#actionId1').val());
        var model = new Object();

        model.ActionId = actionId;
        model.ActionCode = 4; //Ackowledge
        model.Remark = $('#txt-rm').val() ? ': ' + $('#txt-rm').val() + '\r\n' : '\r\n';
        model.UpdatedBy = user;
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
                    bootbox.alert("Acknowledged", function () { window.location.reload(); })
                }
                else {
                    bootbox.alert(data.message)
                }
            }
        })

    }

    function Complete() {
        var actionId = parseInt($('#actionId1').val());
        var model = new Object();

        model.ActionId = actionId;
        model.ActionCode = 5; //Complete
        model.Remark = $('#txt-rm').val() ? ': ' + $('#txt-rm').val() + '\r\n' : '\r\n';
        model.UpdatedBy = user;
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
                    bootbox.alert("Completed", function () { window.location.reload(); })
                }
                else {
                    bootbox.alert(data.message)
                }
            }
        })

    }
})