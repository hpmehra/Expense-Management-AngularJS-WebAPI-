'use strict';
(function () {
    angular.module('ExpenseMgmtApp.expenseMgmtServices')

    .factory("expenseService", ['$http', 'API_END_POINT', function ($http, API_END_POINT) {
        var serviceBase = API_END_POINT + 'expense/';
        var seobj = {};
        seobj.GetConsumerDetailAll = function () {
            return $http.get(serviceBase + 'GetConsumerDetailAll');
        }
        seobj.saveExpense = function (obj, objExpConsume) {
            var jsonObj = { expense: obj, expenseConsumers: objExpConsume };
            return $http.post(serviceBase + 'saveExpense', jsonObj);
        }
        seobj.saveSite = function (obj) {
            return $http.post(serviceBase + 'saveSite', obj);
        }
        seobj.getExpenseDetailBySiteID = function (obj) {
            return $http.post(serviceBase + 'getExpenseDetailBySiteId?siteId=' + obj)
        }
        seobj.getExpenseDetailById = function (obj) {
            return $http.post(serviceBase + 'getExpenseDetailById?id=' + obj)
        }
        seobj.deleteExpenseDetailByExpenseId = function (obj) {
            return $http.post(serviceBase + 'deleteExpenseDetailByExpenseId?expenseId=' + obj)
        }
        seobj.getExpenseReportDetail = function () {
            return $http.get(serviceBase + 'getExpenseReportDetail')
        }
        return seobj;
    }
    ])
})();
