(function () {
    'use strict';
    var KEYS = angular.injector(['common.module']).get('CONSTANT_KEYS');

    angular
        .module('routes.module')
        .config(configRoutes);

    configRoutes.$inject = [KEYS.APP_ROUTES];
    function configRoutes(routes) {
        routes.push({
            state: 'chamada',
            url: '/chamada',
            templateUrl: '/app/templates/components/inner-view.html'
        }, {
            state: 'chamada.create',
            url: '/create',
            controller: 'chamadaCtrl as vm',
            templateUrl: '/app/views/chamada/chamada.html'
        }
);
    }
})();