var categoryNotification = {
    init: function () {
        this.addRow();
        this.hiddenNewRow();
        this.addCategoryNotificaction();
        this.clickEdit();
        this.clickCloseUpdate();
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
            $("#txt-color").val("");
            $("#txt-icon").val("");
        })
    },
    addCategoryNotificaction: function () {
        $(".btn-add-category-notification").off("click").on("click", function () {

            var description = $("#txt-description").val();
            var color = $("#txt-color").val();
            var icon = $("#txt-icon").val();
            var check = true;

            if (!description) {
                $("#txt-description").addClass("input-border-validate");
                check = false;
            } else {
                $("#txt-description").removeClass("input-border-validate");
                check = true;
            }
            if (!color) {
                $("#txt-color").addClass("input-border-validate");
                check = false;
            } else {
                $("#txt-color").removeClass("input-border-validate");
                check = true;
            }
            if (!icon) {
                $("#txt-icon").addClass("input-border-validate");
                check = false;
            } else {
                $("#txt-icon").removeClass("input-border-validate");
                check = true;
            }
            if (check) {
                $("#new-row").addClass("hidden");
                $("#txt-description").val("");
                $("#txt-color").val("");
                $("#txt-icon").val("");

                $.ajax({
                    url: "/Admin/CategoryNotification/Add",
                    data: { description: description, color: color, icon: icon },
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
            var description = parent.find(".lbl-description").text();
            var color = parent.find(".lbl-color").text();
            var icon = parent.find(".lbl-icon").data("icon");

            parent.prev().find(".txt-description").val(description);
            parent.prev().find(".txt-color").val(color);
            parent.prev().find(".txt-icon").val(icon);

            parent.addClass("hidden");
            parent.prev().removeClass("hidden");
        })
    },
    clickCloseUpdate: function () {
        $(".btn-close-update").off("click").on("click", function () {
            $(this).parents("tr").addClass("hidden");
            $(this).parents("tr").next().removeClass("hidden");
        })
    },
    clickUpdate: function () {
        $(".btn-update").off("click").on("click", function () {
            var parent = $(this).parents("tr");

            var description = parent.find(".txt-description").val();
            var color = parent.find(".txt-color").val();
            var icon = parent.find(".txt-icon").val();
            var id = $(this).data("id");
            var check = true;

            if (!description) {
                $("#txt-description").addClass("input-border-validate");
                check = false;
            } else {
                $("#txt-description").removeClass("input-border-validate");
                check = true;
            }
            if (!color) {
                $("#txt-color").addClass("input-border-validate");
                check = false;
            } else {
                $("#txt-color").removeClass("input-border-validate");
                check = true;
            }
            if (!icon) {
                $("#txt-icon").addClass("input-border-validate");
                check = false;
            } else {
                $("#txt-icon").removeClass("input-border-validate");
                check = true;
            }
            if (check) {
                $("#new-row").addClass("hidden");
                $("#txt-description").val("");
                $("#txt-color").val("");
                $("#txt-icon").val("");

                $.ajax({
                    url: "/Admin/CategoryNotification/Update",
                    data: { id: id, description: description, color: color, icon: icon },
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
                url: "/Admin/CategoryNotification/Delete",
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

categoryNotification.init();