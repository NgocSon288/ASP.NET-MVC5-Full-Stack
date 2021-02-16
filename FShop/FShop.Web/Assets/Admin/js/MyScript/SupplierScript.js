var supplier = {
    init: function () {
        this.delete();
    },
    delete: function () {
        $(".btn-delete").off("click").on("click", function () {
            var id = $(this).data("id");
            var btn = $(this);

            console.log(id);


            var result = window.confirm("Bạn có muốn xóa?");

            if (result) {
                $.ajax({
                    url: "/Admin/Supplier/Delete",
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

supplier.init();