$(document).ready(function () {

    document.getElementById('txt-wc-search').addEventListener('change', fncOnchangeCustomer, false)
    function fncOnchangeCustomer() {
        var custId = document.getElementById('txt-wc-search').value;
        $('#txt-ww-search').empty();
        $('#txt-ww-search').append($('<option>', {
            value: "",
            text: "--Please Select--"
        }));
        $.ajax({
            type: 'post',
            url: '/common/WorkWeek_get',
            dataType: 'json',
            data: { custId: custId },
            success: function (response) {
                var data = response.result;
                debugger
                $.each(data, function (index, value) {
                    $('#txt-ww-search').append($('<option>', {
                        value: value.wWyy,
                        text: value.wWyy
                    }));
                });
            }
        })


        $('#txt-pn-search').empty();
        $('#txt-pn-search').append($('<option>', {
            value: "",
            text: "--Please Select--"
        }));
        $.ajax({
            type: 'post',
            url: '/common/PartNumber_get',
            dataType: 'json',
            data: { custId: custId },
            success: function (response) {
                var data = response.result;
                debugger
                $.each(data, function (index, value) {
                    $('#txt-pn-search').append($('<option>', {
                        value: value.pn,
                        text: value.pn
                    }));
                });
            }
        })

    }



})