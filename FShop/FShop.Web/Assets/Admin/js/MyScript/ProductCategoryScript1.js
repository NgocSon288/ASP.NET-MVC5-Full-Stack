var productCategory = {
    init: function () {
        this.delete();
    },
    delete: function () {
        $(".btn-delete").off("click").on("click", function () {
            var id = $(this).data("id");
            var btn = $(this);

            var result = window.confirm("Bạn có muốn xóa?");

            if (result) {
                $.ajax({
                    url: "/Admin/ProductCategory/Delete",
                    data: { id: id },
                    type: "POST",
                    success: function (response) {

                        if (response == 1) {
                            btn.parents("tr").remove();
                        } else {
                            alert("Xóa không thành công!");
                        }
                    }
                })
            }
        })
    }
}

productCategory.init();