$(document).ready(function () {

    $(".multiple_select").mousedown(function (e) {
        if (e.target.tagName == "OPTION") {
            return; //don't close dropdown if i select option
        }
        $(this).toggleClass('multiple_select_active'); //add dropdown if click inside <select> box
    });
    $(".multiple_select").on('blur', function (e) {
        $(this).removeClass('multiple_select_active'); //close dropdown if click outside <select>
    });

    $('.multiple_select option').mousedown(function (e) { //no ctrl to select multiple
        e.preventDefault();
        $(this).prop('selected', $(this).prop('selected') ? false : true); //set selected options on click
        $(this).parent().change(); //trigger change event
    });

    $("#txt-status-search").on('change', function () {
        var selected = $('#txt-status-search option:selected').text().trim();//here I get all options and convert to string   

        //var selectedId = $("#myFilter").val(); //here I get all options and convert to string   
        var count = $("#txt-status-search").val() ? parseInt($("#txt-status-search").val().length) : 0;       
        var document_style = document.getElementById('txt-status-search').style;
        if (count == 1)
            document_style.setProperty('--text', "'" + selected + "'");
        else if (count > 1)
            document_style.setProperty('--text', "'Multiple Selections '");
        else
            document_style.setProperty('--text', "'--Please Select--'");
    });

   
})