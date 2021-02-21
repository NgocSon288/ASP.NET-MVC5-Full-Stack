var paymentMethod = {
    init: function () {
        this.addRow();
        this.hiddenNewRow();
        this.addNewPaymentMethod();
        this.clickEdit();
        this.clickUpdate();
        this.clickDelete();
    },
    addRow: function () {
        $(".btn-add-row").off("click").on("click", function () {
            $("#new-row").removeClass("hidden");
        })
    },
    hiddenNewRow: function () {
        $(".btn-delete-new-row").off("click").on("click", function () {
            $(this).parents("tr").addClass("hidden");
            $("#txt-description").val("");  
        })
    },
    addNewPaymentMethod: function () {
        $(".btn-add-payment-method").off("click").on("click", function () {

            var description = $("#txt-description").val();

            if (!description) {
                $("#txt-description").addClass("input-border-validate");
            } else {
                $("#txt-description").removeClass("input-border-validate");
                $("#new-row").addClass("hidden");
                $("#txt-description").val("");

                $.ajax({
                    url: "/Admin/PaymentMethod/Add",
                    data: { description: description },
                    type: "POST",
                    success: function (response) {
                        if (response == "0") {
                            alert("Lỗi");
                        } else {
                            window.location.reload();
                        }
                    }
                })
            }
        })
    },
    clickEdit: function () {
        $(".btn-edit").off("click").on("click", function () {
            var parent = $(this).parents("tr");

            parent.find("input").removeClass("hidden");
            parent.find("label").addClass("hidden");
            $(this).addClass("hidden");
        })
    },
    clickUpdate: function () {
        $(".btn-update").off("click").on("click", function () {
            var parent = $(this).parents("tr");
            var description = parent.find("input").val();
            var id = $(this).data("id");

            if (!description) {
                $("#txt-description").addClass("input-border-validate");
            } else { 
                $.ajax({
                    url: "/Admin/PaymentMethod/Update",
                    data: { id: id, description: description },
                    type: "POST",
                    success: function (response) {
                        if (response == "0") {
                            alert("Lỗi");
                        } else {
                            window.location.reload();
                        }
                    }
                })
            }
        })
    },
    clickDelete: function () {
        $(".btn-delete").off("click").on("click", function () {
            var id = $(this).data("id");

            $.ajax({
                url: "/Admin/PaymentMethod/Delete",
                data: { id: id },
                type: "POST",
                success: function (response) {
                    if (response == "0") {
                        alert("Lỗi");
                    } else {
                        window.location.reload();
                    }
                }
            })
        })
    }
}

paymentMethod.init();