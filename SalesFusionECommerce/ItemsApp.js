var ItemsApp = angular.module('ItemsApp', [])

ItemsApp.controller('ItemsController', function ($scope, ItemsService) {
    $scope.message = "Test Mesage";
    function getItems() {
        console.log("Loading Items: ");
        ItemsService.getItems()
            .then(function (items) {
                $scope.Items = items.data;
                console.log("Loaded Items: ");
                console.log($scope.Items.data);
            }, function (error) {
                $scope.status = 'Unable to load data: ' + error.message;
                console.log($scope.status);
            });
    }
    getItems();
});

ItemsApp.factory('ItemsService', ['$http', function ($http) {

    var ItemsService = {};
    ItemsService.getItems = function () {
        return $http.get('/Items/GetItems');
    };
    return ItemsService;

}]);