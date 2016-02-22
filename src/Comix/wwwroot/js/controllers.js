"use strict";

/* Controllers */

var comicsApp = angular.module("comicsApp", []);

comicsApp.controller("ComicsListCtrl", ["$scope", "$http", function ($scope, $http) {
    $http.get("ComicsList").success(function (data) {
        $scope.comicses = data;
    });

    $http.get("ComicsKindList").success(function (data) {
        $scope.comicsKinds = data;
    });

    $scope.orderProp = "age";
}]);
