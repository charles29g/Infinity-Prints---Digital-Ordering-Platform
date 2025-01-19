var app = angular.module("InfinityPrints", ['ngFileUpload']);

app.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.html5Mode(true); // Enable HTML5 mode (no hashbang)
}]);