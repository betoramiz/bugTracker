function BugVM() {
    var self = this;
    var bugId = "";
    var rowToDelete = {};

    self.setBugId = function (id) {
        bugId = id;
    }

    self.deleteBug = function () {
        $.ajax({
            url: 'Bug/Delete',
            data: { id: bugId },
            type: 'POST',
            dataType: 'json',
            success: function (result) {
                console.log(result);
                if (result == "success") {
                    $("tr:has(td:contains(" + bugId + "))").remove();
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

ko.applyBindings(new BugVM());