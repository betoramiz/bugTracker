var bugApp = angular.module('BugApp', ['ngRoute'])
.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
    when('/', {
        templateUrl: '../SPA/bugListing.html',
        controller: 'bugController'
    });
}]);