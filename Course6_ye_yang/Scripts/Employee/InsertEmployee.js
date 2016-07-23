$(document).ready(function () {
    $("#backbtn").click(function () {
        window.location.replace("SearchEmployee");
    });

    $("#MonthlyPayment").blur(function () {
        $("#YearlyPayment").val($("#MonthlyPayment").val() * 14);

    });

    //kendoButton
    $("#backbtn").kendoButton();
    $("#save").kendoButton();
    //kendoDropDownList
    $("#Title").kendoDropDownList({
        dataTextField: "Text",
        dataValueField: "Value",
        dataSource: jQuery.parseJSON($("#DropdownType").val()),
        optionLabel: " "
    });
    $("#Country").kendoDropDownList({
        dataTextField: "Text",
        dataValueField: "Value",
        dataSource: jQuery.parseJSON($("#DropdownCountry").val()),
        optionLabel: " "
    });
    $("#City").kendoDropDownList({
        dataTextField: "Text",
        dataValueField: "Value",
        dataSource: jQuery.parseJSON($("#DropdownCity").val()),
        optionLabel: " "
    });
    $("#Gender").kendoDropDownList({
        dataTextField: "Text",
        dataValueField: "Value",
        dataSource: jQuery.parseJSON($("#DropdownGender").val()),
        optionLabel: " "
    });
    $("#ManagerID").kendoDropDownList({
        dataTextField: "Text",
        dataValueField: "Value",
        dataSource: jQuery.parseJSON($("#DropdownManagerID").val()),
        optionLabel: " "
    });
    //kendoNumericTextBox
    $("#MonthlyPayment").kendoNumericTextBox({ format: "c0", min: 0, decimals: 0 });
    $("#YearlyPayment").kendoNumericTextBox({ format: "c0", min: 0, decimals: 0 });
    //kendoDatePicker
    $("#HireDate").kendoDatePicker({ format: "yyyy/MM/dd", min: "1753/01/01" });
    $("#BirthDate").kendoDatePicker({ format: "yyyy/MM/dd", min: "1753/01/01" });
    $("#BirthDate").kendoValidator({
        rules: {
            date: function (input) {
                return kendo.parseDate(input.val(), "yyyy/MM/dd") < new Date($.now());;
            }
        },
        messages: {
            date: "生日不可大於今天"
        }
    });
})