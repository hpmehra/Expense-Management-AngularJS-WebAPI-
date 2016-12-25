'use strict';

(function () {
    return angular.module('ExpenseMgmtApp.expenseMgmtController')
    .controller('expenseReportController', ['$scope','expenseService', '$location',
    function ($scope, expenseService, $location) {
       
        $scope.ExpensePage = function () {
          
            $location.url('/expense');
        }

        $scope.gridOptions = {
            enableColumnMenus: false,
            enableSorting: true,
            columnDefs: [
        {
            name: 'Consumer Name', field: 'Consumers', width: "40%"
        }, {
            name: 'Amount Per Head', field: 'AmountPerHead', width: "20%"
        }, {
            name: 'Paid Amount', field: 'PaidAmount', width: "20%"
        }, {
            name: 'Balance', field: 'Balance', width: "20%"
        }],
            data: 'myData'
        };

        function getExpenseReportData() {
            expenseService.getExpenseReportDetail().then(function (data) {
                $scope.myData = data.data;
            });
        }

        //init
        getExpenseReportData();
    }])
})();

