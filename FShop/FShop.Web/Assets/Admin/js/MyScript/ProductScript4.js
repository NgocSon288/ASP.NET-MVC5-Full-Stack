var product = {
    init: function () {
        this.load();
        this.addContent();
        this.addImage();
        this.deleteProductImage();
        this.deleteProduct();
        this.clickPaginnation();
        this.clickSearch();
        this.clickInstallment();
        this.clickBrand();
        this.clickSupplier();
        this.clickCategory();
        this.clickReset();
        this.deleteKeyWord();
    },
    load: function () {
        product.GetProductAjax();
    },
    addContent: function () {
        $("body").on("click", ".btn-remove-content", function () {
            $(this).parents("tr").remove();
        })

        $("body").on("click", ".btn-add-content", function () {
            var html = $(".trTemp").html();

            var tr = $("<tr></tr>").html(html);

            $("#content-body").append(tr);
        })
    },
    addImage: function () {
        $("body").on("click", ".btn-add-img", function () {
            var html = $('<div class="bg-img"><input name="imageFileList" type="file" class="form-control input-file" /></div>');

            $(".wrap-img").append(html);
        })
    },
    deleteProductImage: function () {
        $(".btn-delete-pro-img").off("click").on("click", function () {
            $(this).parent().remove();

        })
    },
    deleteProduct: function () {
        $("body").on("click", ".btn-delete", function () {
            var status = $(this).data("status");
            var id = $(this).data("id");
            var tr = $(this);

            $(this).data("status", !status);

            $.ajax({
                url: "/Admin/Product/Delete",
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
    clickPaginnation: function () {
        $("body").on("click", ".btn-pagin", function () {
            var key = $(this).data("key");
            var page = $(this).data("page");
            var pageSize = $(this).data("pagesize");
            var installment = $(this).data("installment");
            var brandID = $(this).data("brandid");
            var supplierID = $(this).data("supplierid");
            var categoryID = $(this).data("categoryid");

            product.GetProductAjax(key, page, pageSize, installment, brandID, supplierID, categoryID); 
        })
    },
    clickSearch: function () {
        $("body").on("click", ".btn-search", function () {
            var key = $(".textbox-search").val();
            var pageSize = $(this).data("pagesize");
            var installment = $(this).data("installment");
            var brandID = $(this).data("brandid");
            var supplierID = $(this).data("supplierid");
            var categoryID = $(this).data("categoryid");

            product.GetProductAjax(key, 1, pageSize, installment, brandID, supplierID, categoryID); 
             
        })
    },
    clickInstallment: function () {
        $("body").on("click", ".btn-installment", function () {
            var installment = $(this).data("installment");
            var key = $(this).parents("ul").data("key");
            var pageSize = $(this).parents("ul").data("pagesize");
            var brandID = $(this).parents("ul").data("brandid");
            var supplierID = $(this).parents("ul").data("supplierid");
            var categoryID = $(this).parents("ul").data("categoryid");

            product.GetProductAjax(key, 1, pageSize, installment, brandID, supplierID, categoryID);  
        })
    },
    clickBrand: function () {
        $("body").on("click", ".btn-brand", function () {
            var brandID = $(this).data("brandid");
            var key = $(this).parents("ul").data("key");
            var pageSize = $(this).parents("ul").data("pagesize");
            var installment = $(this).parents("ul").data("installment");
            var supplierID = $(this).parents("ul").data("supplierid");
            var categoryID = $(this).parents("ul").data("categoryid");

            product.GetProductAjax(key, 1, pageSize, installment, brandID, supplierID, categoryID); 
        })
    },
    clickSupplier: function () {
        $("body").on("click", ".btn-supplier", function () {
            var supplierID = $(this).data("supplierid");
            var key = $(this).parents("ul").data("key");
            var pageSize = $(this).parents("ul").data("pagesize");
            var installment = $(this).parents("ul").data("installment");
            var brandID = $(this).parents("ul").data("brandid");
            var categoryID = $(this).parents("ul").data("categoryid");

            product.GetProductAjax(key, 1, pageSize, installment, brandID, supplierID, categoryID); 
        })
    },
    clickCategory: function () {
        $("body").on("click", ".btn-category", function () {
            var categoryID = $(this).data("categoryid");
            var key = $(this).parents("ul").data("key");
            var pageSize = $(this).parents("ul").data("pagesize");
            var installment = $(this).parents("ul").data("installment");
            var supplierID = $(this).parents("ul").data("supplierid");
            var brandID = $(this).parents("ul").data("brandid");

            product.GetProductAjax(key, 1, pageSize, installment, brandID, supplierID, categoryID); 
        })
    },
    clickReset: function () {
        $("body").on("click", ".btn-reset", function () {
            product.GetProductAjax();
        })
    },
    GetProductAjax: function (key = "", page = 1, pageSize = 3, installment = 0, brandID = 0, supplierID = 0, categoryID = 0) {
        $.ajax({
            url: "/Admin/Product/ProductListPartial",
            data: { key: key, page: page, pageSize: pageSize, installment: installment, brandID: brandID, supplierID: supplierID, categoryID: categoryID },
            type: "GET",
            success: function (response) {
                if (response) {
                    $("#result-data").empty();
                    $("#result-data").prepend(response);
                }
            }
        })
    },
    deleteKeyWord: function () {
        $("body").on("click", ".span-close", function () {
            var categoryID = $(this).data("categoryid");
            var key = $(this).data("key");
            var pageSize = $(this).data("pagesize");
            var installment = $(this).data("installment");
            var supplierID = $(this).data("supplierid");
            var brandID = $(this).data("brandid");

            $(this).parent().remove();
            product.GetProductAjax(key, 1, pageSize, installment, brandID, supplierID, categoryID); 
        })
    }
}

product.init();