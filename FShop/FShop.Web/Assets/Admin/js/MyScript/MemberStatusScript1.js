var memberStatus = {
    init: function () {
        this.delete();
        this.add();
        this.update();
    },
    delete: function () {
        $(".btn-delete").off("click").on("click", function () {

            var id = $(this).data("id");

            $.ajax({
                url: "/Admin/MemberStatus/Delete",
                data: { id: id },
                success: function (response) {
                    if (response == 1) {
                        window.location.reload();
                    }
                }
            })
        })
    },
    add: function () {
        $(".btn-plus").off("click").on("click", function () {
            $("#member-status-add").removeClass("hidden");
        })

        $(".btn-add").off("click").on("click", function () {
            var description = $("#txt-description").val();
            var status = $(this).data("status");
            console.log(description);
            console.log(typeof status);
            $.ajax({
                url: "/Admin/MemberStatus/Add",
                data: { description: description, status: status },
                type: "POST",
                success: function (response) {

                    if (response == 1) {
                        window.location.reload();
                    }
                }
            })
        } )
    },
    update: function () {
        $(".btn-edit").off("click").on("click", function () {
            var parent = $(this).parents("tr");

            parent.find("input").removeClass("hidden"); 
            parent.find("label").addClass("hidden");

        })

        $(".btn-update").off("click").on("click", function () {
            var parent = $(this).parent().prev();
            var id = $(this).data("id");
            var description = parent.find("input").val();

            parent.find("input").addClass("hidden");
            parent.find("label").removeClass("hidden");
            parent.find("label").text(description);
              
            $.ajax({
                url: "/Admin/MemberStatus/Update",
                data: { id : id, description: description},
                type: "POST",
                success: function (response) {
                    console.log(response);  
                }
            }) 
        })
    }
}

memberStatus.init();