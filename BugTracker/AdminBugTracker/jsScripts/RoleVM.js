function RoleVM() {
    var self = this;
    var roleId = "";
    var rowToDelete = {};

    self.setRoleId = function (id) {
        //rowToDelete = target.currentTarget.parentNode;
        //console.log(target.currentTarget.parentNode);
        //console.log(rowToDelete);
        roleId = id;
    }

    self.deleteRole = function () {
        $.ajax({
            url: 'Role/Delete',
            data: { id: roleId },
            type: 'POST',
            dataType: 'json',
            success: function (result) {
                console.log(result);
                if (result == "success") {
                    $("tr:has(td:contains(" + roleId + "))").remove();
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

ko.applyBindings(new RoleVM());