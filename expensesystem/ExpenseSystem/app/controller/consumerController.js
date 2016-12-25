'use strict';

(function () {
    return angular.module('ExpenseMgmtApp.expenseMgmtController')
    .controller('consumerController', ['$scope', 'consumerService', '$location',
    function ($scope, consumerService, $location) {
        $scope.consumers = {};
        var siteID = 1;//$location.search().siteId
        $scope.consumer = { SiteId: siteID };
       
        $scope.saveConsumer = function () {
            consumerService.saveConsumer($scope.consumer).then(function (response) {
                if (response.data.Id > 0) {
                    alertify.success("Consumer Saved Successfully");
                    getConsumerBySiteId();
                }
                else {
                    alertify.error("Error in Saving Consumer");
                }
            });
        }


        $scope.ExpensePage = function () {
            $location.url('/expense');
        }

        function getConsumerBySiteId() {
            consumerService.getConsumerBySiteID(siteID).then(function (result) {
                $scope.consumers = result.data;
            });
        }

        getConsumerBySiteId();
    }])
})();