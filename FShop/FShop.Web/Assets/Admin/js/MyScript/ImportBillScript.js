var importBill = {
    init: function () {
        this.load();
        this.addRow();
        this.deleteRow();
        this.clickPaginnation();
        this.onSubmitForm();
        this.deleteImportBill();
        this.clickDateSearch();
        this.clickReset();
    },

    addRow: function () {
        $("body").on("click", ".btn-add-row", function () {
            var html = $(".tr-append").html();
            var tr = $('<tr class="tr-appended"></tr>');

            tr.html(html);

            $("#table-body").append(tr);

            importBill.loadName();
        })
    },
    deleteRow: function () {
        $("body").on("click", ".btn-delete-row", function () {
            $(this).parents("tr").remove();

            importBill.loadName();
        })
    },
    onSubmitForm: function () {
        $("#form-submit").on("submit", function () {
            var arr = [];
            var check = true;

            // Check DisplayName
            $(".productid").each(function (index, element) {  
                if (index != 0) {
                    var opt = $(this).children(":selected").val();

                    if (arr.indexOf(opt) < 0) {
                        arr.push(opt);
                        $(this).css("border", "1px solid black");
                    } else {
                        $(this).css("border", "1px solid red");
                        check = false;
                    }
                }
            })

            // Check Count
            $(".count").each(function (index, element) {
                if (index != 0) { 
                    var val = $(this).val();
                    if (isNaN(val) || val <= 0) { 
                        $(this).css("border", "1px solid red");
                        check = false;
                    } else {
                        $(this).css("border", "1px solid black");
                    }
                }
            })

            // Check ImportPrice
            $(".importprice").each(function (index, element) {
                if (index != 0) {
                    var val = $(this).val();
                    if (isNaN(val) || val <= 0) {
                        $(this).css("border", "1px solid red");
                        check = false;
                    } else {
                        $(this).css("border", "1px solid black");
                    }
                }
            })

            return check;
        })
    },
    loadName: function () {
        $(".tr-appended").each(function (index, element) {
            var i = "[" + index + "].";

            $(element).find(".productid").attr("name", i + "ProductID");
            $(element).find(".count").attr("name", i + "Count");
            $(element).find(".importprice").attr("name", i + "ImportPrice");

        })
    },
    load: function () { 
        importBill.GetImportBillAjax();
    },
    clickPaginnation: function () {
        $("body").on("click", ".btn-pagin", function () {
            var parentRoot = $(this).parents(".parent-root");

            var page = $(this).data("page");
            var pageSize = parentRoot.data("pagesize");
            var startDate = parentRoot.data("startdate");
            var endDate = parentRoot.data("enddate");

            importBill.GetImportBillAjax(page, pageSize, startDate, endDate);
        })
    },
    GetImportBillAjax: function (page = 1, pageSize = 3, startDate = null, endDate = null) {
        $.ajax({
            url: "/Admin/ImportBill/ImportBillListPartial",
            data: { page: page, pageSize: pageSize, startDate: startDate, endDate: endDate },
            type: "GET",
            success: function (response) {
                if (response) {
                    $("#result-data").empty();
                    $("#result-data").prepend(response);
                }
            }
        })
    },
    deleteImportBill: function () {
        $("body").on("click", ".btn-delete", function () {
            var status = $(this).data("status");
            var id = $(this).data("id");
            var tr = $(this);

            $(this).data("status", !status);

            $.ajax({
                url: "/Admin/ImportBill/Delete",
                data: { id: id, status: !status },
                type: "POST",
                success: function (response) {
                    if (response == "1") { 
                        if (status) {
                            tr.parents("tr").addClass("tr-delete");
                        } else {
                            tr.parents("tr").removeClass("tr-delete");
                        }
                    }
                }
            })

        })
    },
    clickDateSearch: function () {
        $("body").on("click", ".btn-search", function () { 
            var startDate = $("#start-date-search").val();
            var endDate = $("#end-date-search").val();
            var pageSize = $(this).parents(".parent-root").data("pagesize");
             

            if (startDate && endDate) {
                importBill.GetImportBillAjax(1, pageSize, startDate, endDate);
            }
        })
    },
    clickReset: function () {
        $("body").on("click", ".btn-reset", function () {
            importBill.GetImportBillAjax();
        })
    }

}

importBill.init();