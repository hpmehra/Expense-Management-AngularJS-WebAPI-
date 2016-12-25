'use strict';
(function () {
    return angular.module("ExpenseMgmtApp.routingConfig", [])
        .config([
            '$routeProvider',
            function ($routeProvider) {

                $routeProvider
                    .when('/expense',
                    {
                        templateUrl: 'partial/expense.html',
                        controller: 'expenseController'
                    })
                    .when('/site',
                    {
                        templateUrl: 'partial/site.html',
                        controller: 'siteController'
                    })
                    .when('/consumer',
                    {
                        templateUrl: 'partial/consumer.html',
                        controller: 'consumerController'
                    })
                    .when('/expenseReport',
                    {
                        templateUrl: 'partial/expenseReport.html',
                        controller: 'expenseReportController'
                    })
                    .otherwise(
                    {
                        redirectTo: '/expense'
                    });
            }
        ]);
})();



