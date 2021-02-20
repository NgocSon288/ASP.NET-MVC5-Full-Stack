var importBillDetail = {
    init: function () {
        this.updatePrice();
        this.updatePriceAjax();
        this.updatePromotionAjax();
    },
    updatePrice: function () {
        $("body").on("click", ".btn-update-price", function () {
            $(this).parents("td").find(".span-price").addClass('hidden');
            $(this).parents("td").find(".div-price").removeClass('hidden');
        })
        $("body").on("click", ".btn-update-promotion", function () {
            $(this).parents("td").find(".span-promotion").addClass('hidden');
            $(this).parents("td").find(".div-promotion").removeClass('hidden');
        })
    },
    updatePriceAjax: function () {
        $(".btn-update-price-ajax").off("click").on("click", function () {
            var id = $(this).data("id");
            var price = $(this).prev().val();
            var promotion = $(this).parents("tr").find(".span-promotion").data("promotion");
            var spanPrice = $(this).parents("tr").find(".span-price");

            if (isNaN(price) || price < 0) {
                $(this).prev().addClass("input-border-validate");
            } else {
                $(this).prev().removeClass("input-border-validate");

                console.log(id, price, promotion);

                $.ajax({
                    url: "/Admin/Product/UpdatePrice",
                    data: { id: id, price: price, promotion: promotion },
                    type: "POST",
                    success: function (response) {
                        if (response == "0") {
                            alert("Lỗi");
                        } else {
                            spanPrice.data("price", response.split("|")[0]);
                            spanPrice.text(response.split("|")[0] + " đ");
                        }
                    }
                })

                $(this).parent().addClass("hidden");
                $(this).parent().prev().removeClass("hidden");
            }
        })
    },
    updatePromotionAjax: function () {
        $(".btn-update-promotion-ajax").off("click").on("click", function () {
            var id = $(this).data("id");
            var promotion = $(this).prev().val();
            var price = $(this).parents("tr").find(".span-price").data("price");
            var spanPromotion = $(this).parents("tr").find(".span-promotion");

            if (isNaN(promotion) || price < 0) {
                $(this).prev().addClass("input-border-validate");
            } else {
                $(this).prev().removeClass("input-border-validate");

                console.log(id, price, promotion);

                $.ajax({
                    url: "/Admin/Product/UpdatePrice",
                    data: { id: id, price: price, promotion: promotion },
                    type: "POST",
                    success: function (response) {
                        if (response == "0") {
                            alert("Lỗi");
                        } else {
                            spanPromotion.data("promotion", response.split("|")[1]);
                            spanPromotion.text(response.split("|")[1] + " đ");
                        }
                    }
                })

                $(this).parent().addClass("hidden");
                $(this).parent().prev().removeClass("hidden");
            }
        })
    }
}

importBillDetail.init();