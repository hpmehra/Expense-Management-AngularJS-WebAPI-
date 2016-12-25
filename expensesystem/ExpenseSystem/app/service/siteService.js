'use strict';
(function () {
    angular.module('ExpenseMgmtApp.expenseMgmtServices')

    .factory("siteService", ['$http', 'API_END_POINT', function ($http, API_END_POINT) {
        var serviceBase = API_END_POINT + 'expense/';
        var seobj = {};

        seobj.checkLoginDetail = function (obj) {
            return $http.post(serviceBase + 'checkLoginDetail', obj);
        }
        seobj.saveSite = function (obj) {
            return $http.post(serviceBase + 'saveSite', obj);
        }

        return seobj;
    }
    ])
})();