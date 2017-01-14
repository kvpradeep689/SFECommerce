ItemsApp.factory('ItemsService', ['$http', function ($http) {

    var ItemsService = {};
    ItemsService.getItems = function () {
        return $http.get('/Items/GetItems');
    };
    return ItemsService;

}]);