var app = angular.module("InfinityPrints", ['ngFileUpload']);

app.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.html5Mode(true); // Enable HTML5 mode (no hashbang)

}]);


var app = angular.module("InfinityPrints", ['ngFileUpload']);

//app.config(['$locationProvider', function ($locationProvider) {
//    // Enable HTML5 mode (no hashbang) and set hashPrefix (optional)
//    $locationProvider.html5Mode(true);
//}]);

