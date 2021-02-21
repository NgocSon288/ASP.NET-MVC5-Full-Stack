var advertisement = {
    init: function () {
        this.selectRow();
    },
    selectRow: function () {
        $(".tr-cursor").off("click").on("click", function () {
            var src = $(this).data("src");

            $("#main-img").attr("src", src);

            alert(src);
        })
    }
}

advertisement.init();