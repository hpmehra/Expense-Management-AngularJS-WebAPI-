'use strict';
(function () {
    angular.module('ExpenseMgmtApp.expenseMgmtServices')

    .factory("consumerService", ['$http', 'API_END_POINT', function ($http, API_END_POINT) {
        var serviceBase = API_END_POINT + 'expense/';
        var seobj = {};
        seobj.saveConsumer = function (obj) {
            return $http.post(serviceBase + 'saveConsumer', obj);
        }

        seobj.getConsumerBySiteID = function (obj) {
            return $http.post(serviceBase + 'getConsumerBySiteId?siteId='+ obj);
        }
       
        return seobj;
    }
    ])
})();
