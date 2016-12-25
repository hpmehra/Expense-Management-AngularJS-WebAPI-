'use strict';

(function () {
    return angular.module('ExpenseMgmtApp.expenseMgmtController')
    .controller('siteController', ['$scope', 'siteService', '$location',
    function ($scope, siteService,$location) {
            $scope.site = {};
            $('#divRegister').hide();
            function getConsumerAll() {
                expenseService.GetConsumerDetailAll().then(function (data) {
                    $scope.consumersDDL = $scope.consumers = data.data;
                });
            }
            
            $scope.loginSite = function () {
                siteService.checkLoginDetail($scope.site).then(function (response) {
                    if (response.data > 0) {
                        $location.url('/expense?siteId=' + response.data);
                    }
                    else {
                        alertify.alert("Site Not Exists");
                    }
                });
            }
            $scope.RegisterSite = function () {
                siteService.saveSite($scope.site).then(function (response) {
                    if (response.data > 0) {
                        $location.url('/expense?siteId=' + response.data);
                    }
                    else {
                        alertify.alert("Site Already Exists");
                    }
                });
            }

            $scope.toggleButton = function () {
                if ($('#btnRegisterLogin').val() == "Register Here") {
                    $('#divLogin').hide();
                    $('#divRegister').show();
                    $('#btnRegisterLogin').val("Already Have Account");
                }
                else {
                    $('#divLogin').show();
                    $('#divRegister').hide();
                    $('#btnRegisterLogin').val("Register Here");
                }
            } 
        }])
})();