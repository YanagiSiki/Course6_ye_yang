$(document).ready(function () {
    $(".newbtn").click(function (e) {
        var confirmbox = confirm("確定要刪除?");
        if (confirmbox == true) {
            var tr = $(this).closest('tr')
            $.ajax({
                type: "POST",
                url: "/Employee/DeleteEmployee",
                data: "EmployeeID=" + $(this).next().val(),
                dataType: "json",
                success: function (response) {
                    $(tr).remove();
                    alert("刪除成功");
                }
            });
        }
        return false;
    });

    $("#clearbtn").click(function () {
        $("#Form")[0].reset();
        $("#SelectTitle").val(0);
    });

    $("#newbtn").click(function () {
        window.location.replace("InsertEmployee");
    });

    //Kendo
    $("#searchbtn").kendoButton();
    $("#clearbtn").kendoButton();
    $("#newbtn").kendoButton();

    $("#grid").kendoGrid({
        dataSource: {
            data: jQuery.parseJSON($("#tmpBag").val()),//資料來源為products變數
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
            { field: "EmployeeId", title: "EmployeeId", width: "15%" },
            { field: "EmployeeName", title: "EmployeeName", width: "10%" },
            { field: "CodeType", title: "CodeType", width: "10%" },
            { field: "HireDate", title: "HireDate", width: "10%" },
            { field: "Gender", title: "Gender", width: "10%" },
            { field: "Age", title: "Age", width: "10%" },
            { command:{ text: "修改", click: GotoUpdatePage}, title: "", width: "10%" }
        ]
    });
    function GotoUpdatePage(e) {
        var tr = $(e.currentTarget).closest("tr");
        var item = $("#grid").data("kendoGrid").dataItem(tr).EmployeeId;
        window.location.replace("../UpdateEmployee/" + item);
    }

})