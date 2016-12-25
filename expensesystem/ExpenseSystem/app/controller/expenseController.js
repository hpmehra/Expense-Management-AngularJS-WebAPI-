'use strict';

(function () {
    return angular.module('ExpenseMgmtApp.expenseMgmtController')
    .controller('expenseController', ['$scope', 'expenseService','$location',
    function ($scope, expenseService,$location) {
            $scope.consumers = {};
            $scope.consumersDDL = {};
            $scope.expnse = {};
            $scope.site = {};
            $scope.selectedConsumer = [];
            $scope.ExpenseDetails = {};
            var varExpeseID = 0;
            var siteID=1;//$location.search().siteId

            $scope.ExpenseReports = function () {
                $location.url('/expenseReport');
            }

            $scope.ConsumerPage = function () {
                $location.url('/consumer');
            }

            function getConsumerAll() {
                expenseService.GetConsumerDetailAll().then(function (data) {
                    $scope.expnse = { PaidBy: data.data[0].Id, SiteId: siteID };
                    $scope.consumersDDL = $scope.consumers = data.data;                  
                });
            }
        

         

            function getExpenseDetail() {
                expenseService.getExpenseDetailBySiteID(siteID).then(function (data) {
                    $scope.ExpenseDetails = data.data;
                    $scope.gridOptions = { data: 'ExpenseDetails' };
                });
            }


            $(document).ready(function () {
                getExpenseDetail();
            });
            

            $scope.saveExpense = function () {
                expenseService.saveExpense($scope.expnse, $scope.consumers).then(function (data) {
                    if (data.data) {
                        alertify.success("Expense Saved Successfully");
                        getExpenseDetail();
                        clearForm();
                    }
                });
            }

            $scope.saveSite = function () {
                expenseService.saveSite($scope.site).then(function (data) {
                });
            }

            $scope.editExpense = function (id) {
                expenseService.getExpenseDetailById(id).then(function (data) {
                    var result = data.data;
                    $scope.consumers = result.expenseConsumer;
                    $scope.expnse = result.expense;
                });
            }

            $scope.deleteExpense = function (id) {
                expenseService.deleteExpenseDetailByExpenseId(id).then(function (data) {
                    if (data) {
                        getExpenseDetail();
                        alertify.success("Delete Successfully");
                        clearForm();
                    }
                    else
                        alertify.error("Error in Deletion");
                });
            }

            //Init..
            getConsumerAll();

            function clearForm() {
                $scope.expnse = { };
                //$('.checkbox').attr('checked', false);
                $('#txtItem').focus();
            }
        }])
})();