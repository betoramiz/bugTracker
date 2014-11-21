function ProjectVM() {
    var self = this;
    var projectId = "";
    var rowToDelete = {};

    self.setProjectId = function (id) {
        projectId = id;
    }

    self.deleteProject = function () {
        $.ajax({
            url: 'Project/Delete',
            data: { id: projectId },
            type: 'POST',
            dataType: 'json',
            success: function (result) {
                console.log(result);
                if (result == "success") {
                    $("tr:has(td:contains(" + projectId + "))").remove();
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

ko.applyBindings(new ProjectVM());