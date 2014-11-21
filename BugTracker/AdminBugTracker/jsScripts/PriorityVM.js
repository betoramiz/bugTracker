function PriorityVM() {
    var self = this;
    var priorityId = "";
    var rowToDelete = {};

    self.setPriorityId = function (id) {
        priorityId = id;
    }

    self.deletePriority = function () {
        $.ajax({
            url: 'Priority/Delete',
            data: { id: priorityId },
            type: 'POST',
            dataType: 'json',
            success: function (result) {
                console.log(result);
                if (result == "success") {
                    $("tr:has(td:contains(" + priorityId + "))").remove();
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

ko.applyBindings(new PriorityVM());