function StatusVM() {
    var self = this;
    var statusId = "";
    var rowToDelete = {};

    self.setStatusId = function (id) {
        //rowToDelete = target.currentTarget.parentNode;
        //console.log(target.currentTarget.parentNode);
        //console.log(rowToDelete);
        statusId = id;
    }

    self.deleteStatus = function () {
        $.ajax({
            url: 'Status/Delete',
            data: { id: statusId },
            type: 'POST',
            dataType: 'json',
            success: function (result) {
                console.log(result);
                if (result == "success") {
                    $("tr:has(td:contains(" + statusId + "))").remove();
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

ko.applyBindings(new StatusVM());