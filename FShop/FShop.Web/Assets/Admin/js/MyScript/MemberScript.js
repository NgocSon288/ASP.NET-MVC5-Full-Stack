var member = {
    init: function () {
        this.loadFirstPage();
        this.updateStatus();
        this.paginationItemClick();
        this.filterMember();
        this.memberDelete();
    },
    loadFirstPage: function () {
        $(".member-page").addClass("hidden-row");
        $(".member-page" + 1).removeClass("hidden-row");
    },
    updateStatus: function () {
        $(".status-btn").off("click").on("click", function () {
            var id = $(this).data("id");
            var status = $(this).data("status");
            var btn = $(this);

            $.ajax({
                url: "/Admin/Member/UpdateStatus",
                data: { memberID: id },
                type: "POST",
                success: function (response) {
                    console.log(response);

                    if (status == 2) {
                        btn.removeClass("text-danger").addClass("text-success");
                        btn.text("Đang hoạt động");
                        btn.data("status", 1);
                    } else {
                        btn.removeClass("text-success").addClass("text-danger");
                        btn.text("Bị khóa");
                        btn.data("status", 2);
                    }
                }
            })


        })
    },
    paginationItemClick: function () {
        $(".page-item").off("click").on("click", function () {
            var page = $(this).find(".page-link").text();

            $(".member-page").addClass("hidden-row");
            $(".member-page" + page).removeClass("hidden-row");

            $(".page-item").removeClass("active");
            $(this).addClass("active");
        })
    },
    filterMember: function () {
        $("#member-search").on("keyup", function () {
            var searchString = $(this).val().toUpperCase();

            $(".member-page").each(function () {
                var text = $(this).text().toUpperCase();

                if (text.indexOf(searchString) > 0) {
                    $(this).addClass("text-danger");
                } else {
                    $(this).removeClass("text-danger");
                }
            })
        });
    },
    memberDelete: function () {
        $(".member-delete").off("click").on("click", function () {
            var id = $(this).parent().data("id");

            $.ajax({
                url: "/Admin/Member/DeleteMember",
                data: { memberID: id },
                type: "POST",
                success: function (response) {

                    if (response == 1) {
                        window.location.reload();
                    }
                }
            })
        });
    }
}

member.init();