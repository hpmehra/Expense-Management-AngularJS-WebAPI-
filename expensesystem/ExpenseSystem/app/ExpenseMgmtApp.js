'use strict';
(function () {
    var expenseMgmtApp = angular.module('ExpenseMgmtApp',
        [
            'ngRoute',
            'ngCookies',
            'ngAnimate',
            'ngTouch',
            'ui.grid',
            'ExpenseMgmtApp.routingConfig',
            'ExpenseMgmtApp.expenseMgmtController',
            'ExpenseMgmtApp.expenseMgmtServices'            
        ])
    return expenseMgmtApp;
})();

