
(function () {
    'use strict';
    var KEYS = angular.injector(['app.common']).get('CONSTANT_KEYS');

    angular
        .module('app.layout')
        .config(configRoutes);

    configRoutes.$inject = [KEYS.APP_ROUTES, 'RouteHelpersProvider'];

    function configRoutes(routes, helper) {
        routes.push({
            name: "app",
            url: '/app',
            abstract: true,
            redirect: "app.home",
            templateUrl: helper.basepath('app.html'),
            resolve: helper.resolveFor('modernizr', 'icons')
        }, {
            name: 'app.home',
            url: '/home',
            title: 'Home',
            templateUrl: helper.basepath('home.html')
        });
    }
})();