var permission = {
    init: function () {
        this.addRow();
        this.hiddenNewRow();
        this.addPermission();
        this.clickEdit();
        this.clickCloseUpdate();
        this.clickUpdate();
        this.clickDelete();
        this.clickSearch();
    },
    addRow: function () {
        $(".btn-add-row").off("click").on("click", function () {
            $("#new-row").removeClass("hidden");
        })
    },
    hiddenNewRow: function () {
        $(".btn-delete-new-row").off("click").on("click", function () {
            $(this).parents("tr").addClass("hidden");
            $("#txt-id").val("");
            $("#txt-name").val("");
            $("#txt-description").val("");
        })
    },
    addPermission: function () {
        $(".btn-add-permission").off("click").on("click", function () {
            var id = $("#txt-id").val();
            var name = $("#txt-name").val();
            var description = $("#txt-description").val();
            var check = true;

            if (!id) {
                $("#txt-id").addClass("input-border-validate");
                check = false;
            } else {
                $("#txt-id").removeClass("input-border-validate");
                check = true;
            }

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
                $("#txt-id").val("");
                $("#txt-name").val("");
                $("#txt-description").val("");

                $.ajax({
                    url: "/Admin/Permission/Add",
                    data: { id : id, name: name, description: description },
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
            var id = parent.find(".lbl-id").text();
            var name = parent.find(".lbl-name").text();
            var description = parent.find(".lbl-description").text();

            parent.prev().find(".txt-id").val(id);
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

            var id = parent.find(".txt-id").val();
            var name = parent.find(".txt-name").val();
            var description = parent.find(".txt-description").val();
            var check = true;

            if (!id) {
                $("#txt-id").addClass("input-border-validate");
                check = false;
            } else {
                $("#txt-id").removeClass("input-border-validate");
                check = true;
            }

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
                $("#txt-id").val("");
                $("#txt-name").val("");
                $("#txt-description").val("");

                $.ajax({
                    url: "/Admin/Permission/Update",
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
                url: "/Admin/Permission/Delete",
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
    },
    clickSearch: function () {
        $(".btn-search").off("click").on("click", function (e) { 
            var search = $("#txt-search").val().toUpperCase();

            $("tbody").find(".tr-main").each(function (index, element) {
                var text = $(element).text().toUpperCase();  

                if (text.indexOf(search) < 0) {
                    $(element).addClass("hidden");
                } else {
                    $(element).removeClass("hidden");
                }
            })
        })
    }
}

permission.init();