function UserVM() {
    var self = this;
    var userId = "";
    var rowToDelete = {};

    self.setUserId = function (id) {
        userId = id;
    }

    self.deleteUser = function () {
        $.ajax({
            url: 'User/Delete',
            data: { id: userId },
            type: 'POST',
            dataType: 'json',
            success: function (result) {
                console.log(result);
                if (result == "success") {
                    $("tr:has(td:contains(" + userId + "))").remove();
                    $("#deleteModal").modal('hide');
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status);
                console.log(thrownError);
            }
        });
    }
}

ko.applyBindings(new UserVM());