$(document).ready(function () {

    $("#clearbtn").click(function () {
        $("#Form")[0].reset();
        $("#SelectTitle").val(0);
    });

    $("#newbtn").click(function () {
        window.location.replace("InsertEmployee");
    });

    //kendoButton
    $("#searchbtn").kendoButton();
    $("#clearbtn").kendoButton();
    $("#newbtn").kendoButton();
    //kendoDropDownList
    $("#Title").kendoDropDownList({
        dataTextField: "Text",
        dataValueField: "Value",
        dataSource: jQuery.parseJSON($("#TypeBag").val()),
        optionLabel: " "
    });
    //kendoNumericTextBox
    $("#EmployeeId").kendoNumericTextBox({ format: "{0:0}", min: 0, decimals: 0 });
    //kendoDatePicker
    $("#StartHireDate").kendoDatePicker({ format: "yyyy/MM/dd", min: "1753/01/01" });
    $("#EndHireDate").kendoDatePicker({ format: "yyyy/MM/dd", min: "1753/01/01" });
    //kendoValidator
    $("#StartHireDate").kendoValidator({
        rules: {
            date: DateFromat
        },
        messages: {            
            date: "Start & End有誤"
        }      
    });
    $("#EndHireDate").kendoValidator({
        rules: {
            date: DateFromat
        },
        messages: {
            date: "Start & End有誤"
        }
    });

    function DateFromat (input) {
        if ($("#EndHireDate").val() === "" || $("#StartHireDate").val() === "") {
            return true;
        }
        else if($("#EndHireDate").val() >= $("#StartHireDate").val()){
            return true;
        }
    }
    //kendoGrid
    $("#grid").kendoGrid({
        dataSource: {
            data: jQuery.parseJSON($("#ResultsBag").val()),//資料來源為products變數
            schema: {
                model: {
                    fields: {//這是欄位名稱
                        EmployeeId: { type: "string" },
                        EmployeeName: { type: "string" },
                        CodeType: { type: "string" },
                        HireDate: { type: "string" },
                        Gender: { type: "string" },
                        Age: { type: "string" }
                    }
                }
            },
            pageSize: 10
        },
        height: 550,
        scrollable: true,
        sortable: true,
        filterable: false,
        pageable: {
            input: true,
            numeric: false
        },
        columns: [//這也是欄位名稱，但我不知道和上面的差別，所以都改吧orz
            { field: "EmployeeId", title: "EmployeeId", width: "5%" },
            { field: "EmployeeName", title: "EmployeeName", width: "15%" },
            { field: "CodeType", title: "CodeType", width: "20%" },
            { field: "HireDate", title: "HireDate", width: "15%" },
            { field: "Gender", title: "Gender", width: "15%" },
            { field: "Age", title: "Age", width: "10%" },
            { command: { text: "修改", click: GotoUpdatePage }, title: "", width: "10%" },
            { command: { text: "刪除", click: PostToDeletePage }, title: "", width: "10%" }
        ]
    });
    function GotoUpdatePage(e) {
        var tr = $(e.currentTarget).closest("tr");
        var item = $("#grid").data("kendoGrid").dataItem(tr).EmployeeId;
        window.location.replace("UpdateEmployee/" + item);
    }
    function PostToDeletePage(e) {
        var confirmbox = confirm("確定要刪除?");
        if (confirmbox == true) {
            var tr = $(e.currentTarget).closest("tr");            
            var item = $("#grid").data("kendoGrid").dataItem(tr).EmployeeId;
            $.ajax({
                type: "POST",
                url: "/Employee/DeleteEmployee",
                data: "EmployeeID=" + item,
                dataType: "json",
                success: function (response) {                   
                    $("#grid").data("kendoGrid").dataSource.remove($("#grid").data("kendoGrid").dataItem(tr));
                    alert("刪除成功");
                }
            });
        }
        return false;
    }

})