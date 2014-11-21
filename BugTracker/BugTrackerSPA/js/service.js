bugApp.factory('bugService',['$http', '$q', function ($http, $q) {
    var method = {};

    method.getAllBugs = function () {
        var deferred = $q.defer();
        $http.get('http://localhost:24184/api/bug').success(function (result) {
            deferred.resolve(result);
        });
        return deferred.promise;
    }
    return method;
}]);