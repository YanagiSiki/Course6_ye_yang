$(document).ready(function () {
    $("#backbtn").click(function () {
        window.location.replace("../SearchEmployee");
    });


    $("#btnDelete").click(function (e) {
        var confirmbox = confirm("確定要刪除?");
        var empid = $("#Number").val();
        if (confirmbox == true) {
            $.ajax({
                type: "POST",
                url: "/Employee/DeleteEmployee",
                //data: "orderId=" + $(this).next().val(),
                data: { EmployeeID: empid },
                dataType: "json",
                success: function (response) {
                    alert("刪除成功");
                    window.location.replace("../SearchEmployee");
                }
            });
        }
        return false;
    });

    $("#MonthlyPayment").blur(function () {
        $("#YearlyPayment").val($("#MonthlyPayment").val() * 14);

    });

    //kendoButton
    $("#save").kendoButton();
    $("#btnDelete").kendoButton();
    $("#backbtn").kendoButton();
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