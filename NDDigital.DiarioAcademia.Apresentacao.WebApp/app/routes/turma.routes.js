(function () {
    'use strict';
    var KEYS = angular.injector(['common.module']).get('CONSTANT_KEYS');

    angular
        .module('routes.module')
        .config(configRoutes);

    configRoutes.$inject = [KEYS.APP_ROUTES];
    function configRoutes(routes) {
        routes.push({
            state: 'turma',
            url: '/turma',
            'abstract': true,
            redirect: '/turma/list',
            templateUrl: '/app/templates/components/inner-view.html'
        }, {
            state: 'turma.list',
            url: '/list',
            controller: 'turmaListCtrl as vm',
            templateUrl: '/app/views/turma/turma-list.html'
        }, {
            state: 'turma.details',
            url: '/details/:turmaId',
            controller: 'turmaDetailsCtrl as vm',
            templateUrl: '/app/views/turma/turma-details.html'
        }, {
            state: 'turma.create',
            url: '/create',
            controller: 'turmaCreateCtrl as vm',
            templateUrl: '/app/views/turma/turma-create.html'
        }
);
    }
})();