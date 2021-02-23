var permisisonCategoryMember = {
    init: function () {
        this.insertOrDelete();
    },
    insertOrDelete: function () {
        $(".checkbox-input").off("click").on("click", function () {
            var checkbox = $(this);
            var check = $(this).prop("checked");
            var permissionID = $(this).data("permissionid");
            var categoryMemberID = $(this).data("categorymemberid");

            console.log(permissionID, categoryMemberID);

            $.ajax({
                url: "/Admin/PermissionCategoryMember/InsertOrDelete",
                data: { permissionID: permissionID, categoryMemberID: categoryMemberID },
                type: "POST",
                success: function (response) {
                    if (response == "0") {
                        checkbox.prop("checked", !check);
                    }
                }
            })
        })
    }
}

permisisonCategoryMember.init();