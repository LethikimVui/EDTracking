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

    //$("#txt-customer").on('change', function () {
    //    var selected = $('#txt-customer option:selected').text().toString();//here I get all options and convert to string   

    //    //var selectedId = $("#myFilter").val(); //here I get all options and convert to string   
    //    var count = $("#txt-customer").val() ? parseInt($("#txt-customer").val().length) : 0;
    //    var document_style = document.getElementById('txt-customer').style;
    //    if (count == 1)
    //        document_style.setProperty('--text', "'" + selected + "'");
    //    else if (count > 1)
    //        document_style.setProperty('--text', "'Multiple Selections '");
    //    else
    //        document_style.setProperty('--text', "'--Please Select--'");
    //});

    $("#txt-ww-search").on('change', function () {
        var selected = $('#txt-ww-search option:selected').text().toString();//here I get all options and convert to string   
        debugger
        //var selectedId = $("#myFilter").val(); //here I get all options and convert to string   
        var count = $("#txt-ww-search").val() ? parseInt($("#txt-ww-search").val().length) : 0;
        var document_style = document.getElementById('txt-ww-search').style;
        if (count == 1)
            document_style.setProperty('--text', "'" + selected + "'");
        else if (count > 1)
            document_style.setProperty('--text', "'Multiple Selections '");
        else
            document_style.setProperty('--text', "'--Please Select--'");
    });
    //$("#txt-category").on('change', function () {
    //    var selected = $('#txt-category option:selected').text().toString();//here I get all options and convert to string   

    //    //var selectedId = $("#myFilter").val(); //here I get all options and convert to string   
    //    var count = $("#txt-category").val() ? parseInt($("#txt-category").val().length) : 0;
    //    var document_style = document.getElementById('txt-category').style;
    //    if (count == 1)
    //        document_style.setProperty('--text', "'" + selected + "'");
    //    else if (count > 1)
    //        document_style.setProperty('--text', "'Multiple Selections '");
    //    else
    //        document_style.setProperty('--text', "'--Please Select--'");
    //});
    //$("#txt-supplier").on('change', function () {
    //    var selected = $('#txt-supplier option:selected').text().toString();//here I get all options and convert to string   

    //    //var selectedId = $("#myFilter").val(); //here I get all options and convert to string   
    //    var count = $("#txt-supplier").val() ? parseInt($("#txt-supplier").val().length) : 0;
    //    var document_style = document.getElementById('txt-supplier').style;
    //    if (count == 1)
    //        document_style.setProperty('--text', "'" + selected + "'");
    //    else if (count > 1)
    //        document_style.setProperty('--text', "'Multiple Selections '");
    //    else
    //        document_style.setProperty('--text', "'--Please Select--'");
    //});
})