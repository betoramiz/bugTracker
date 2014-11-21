bugApp.controller('bugController',['$scope', 'bugService', function ($scope, bugService) {
    bugService.getAllBugs().then(function (result) {
        $scope.bugList = result;
        console.log(result);
    })

    $scope.date = function (datetime) {
        var datetimeUTC = datetime.split("T")[0];
        var momentDate = moment(datetimeUTC).format("DD MMM, YY");
        return momentDate;
    }
}]);