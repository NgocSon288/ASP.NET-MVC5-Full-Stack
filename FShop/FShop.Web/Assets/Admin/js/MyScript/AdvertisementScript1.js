var advertisement = {
    init: function () {
        this.selectRow();
        this.clickUpdate();
        this.clickUpdateAjax();
    },
    selectRow: function () {
        $(".tr-cursor").off("click").on("click", function () {
            var src = $(this).data("src");

            $("#main-img").attr("src", src);
        })
    }
}

advertisement.init();