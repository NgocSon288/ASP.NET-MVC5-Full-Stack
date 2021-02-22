var categoryMember = {
    init: function () {
        this.addRow();
        this.hiddenNewRow();
        this.addCategoryMember();
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
            $("#txt-name").val("");
            $("#txt-description").val("");
        })
    },
    addCategoryMember: function () {
        $(".btn-add-category-member").off("click").on("click", function () {
            var name = $("#txt-name").val();
            var description = $("#txt-description").val();
            var check = true;

            if (!name) {
                $("#txt-name").addClass("input-border-validate");
                check = false;
            } else {
                $("#txt-name").removeClass("input-border-validate");
                check = true;
            }

            if (!description) {
                $("#txt-description").addClass("input-border-validate");
                check = false;
            } else {
                $("#txt-description").removeClass("input-border-validate");
                check = true;
            }

            if (check) {
                $("#new-row").addClass("hidden");
                $("#txt-name").val("");
                $("#txt-description").val("");

                $.ajax({
                    url: "/Admin/CategoryMember/Add",
                    data: { name: name, description: description },
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
            var name = parent.find(".lbl-name").text();
            var description = parent.find(".lbl-description").text();

            parent.prev().find(".txt-name").val(name);
            parent.prev().find(".txt-description").val(description);

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

            var name = parent.find(".txt-name").val();
            var description = parent.find(".txt-description").val();
            var id = $(this).data("id");
            var check = true;

            if (!name) {
                $("#txt-name").addClass("input-border-validate");
                check = false;
            } else {
                $("#txt-name").removeClass("input-border-validate");
                check = true;
            }

            if (!description) {
                $("#txt-description").addClass("input-border-validate");
                check = false;
            } else {
                $("#txt-description").removeClass("input-border-validate");
                check = true;
            }

            if (check) {
                $("#new-row").addClass("hidden");
                $("#txt-name").val("");
                $("#txt-description").val("");

                $.ajax({
                    url: "/Admin/CategoryMember/Update",
                    data: { id: id, name: name, description: description },
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
                url: "/Admin/CategoryMember/Delete",
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

categoryMember.init();