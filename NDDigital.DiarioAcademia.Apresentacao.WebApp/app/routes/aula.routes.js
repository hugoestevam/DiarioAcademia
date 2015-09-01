(function () {
    'use strict';
    var KEYS = angular.injector(['common.module']).get('CONSTANT_KEYS');

    angular
        .module('routes.module')
        .config(configRoutes);

    configRoutes.$inject = [KEYS.APP_ROUTES];
    function configRoutes(routes) {
        routes.push({
            state: 'aula',
            url: '/aula',
            'abstract': true,
            redirect: '/aula/list',
            templateUrl: '/app/templates/components/inner-view.html',
            displayName: 'Aula',
            displayIcon: "fa-calendar"
        }, {
            state: 'aula.list',
            url: '/list',
            controller: 'aulaListCtrl as vm',
            templateUrl: '/app/views/aula/aula-list.html',
            displayName: 'Lista de Aulas',
            displayIcon: "fa-calendar-check-o",
            $$permissionId: "05"
        }, {
            state: 'aula.create',
            url: '/create',
            controller: 'aulaCreateCtrl as vm',
            templateUrl: '/app/views/aula/aula-create.html',
            displayName: 'Criação de Aulas',
            displayIcon: "fa-calendar-plus-o",
            $$permissionId: "06"
        }
);
    }
})();