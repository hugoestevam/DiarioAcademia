(function () {
    'use strict';
    var KEYS = angular.injector(['common.module']).get('CONSTANT_KEYS');

    angular
        .module('routes.module')
        .config(configRoutes);

    configRoutes.$inject = [KEYS.APP_ROUTES, KEYS.USER_ROLES];

    function configRoutes(routes, roles) {
        routes.push({
            state: 'aluno',
            url: '/aluno',
            'abstract': true,
            redirect: '/aluno/list',
            templateUrl: '/app/templates/components/inner-view.html',
            displayName: "Aluno",
            displayIcon: "fa-user",
        }, {
            state: 'aluno.list',
            url: '/list',
            controller: 'alunoListCtrl as vm',
            templateUrl: '/app/views/aluno/aluno-list.html',
            allowAnnonymous: true,
            displayName: "Lista de Aluno",
            displayIcon: "fa-user",
            $$permissionId: "01"
        }, {
            state: 'aluno.details',
            url: '/details/:alunoId',
            controller: 'alunoDetailsCtrl as vm',
            templateUrl: '/app/views/aluno/aluno-details.html',
            displayName: "Detalhes do Aluno",
            $$permissionId: "02"
        }, {
            state: 'aluno.create',
            url: '/create',
            controller: 'alunoCreateCtrl as vm',
            templateUrl: '/app/views/aluno/aluno-create.html',
            displayName: "Criação de Aluno",
            displayIcon: "fa-user-plus",
            $$permissionId: "03"
        });
    }
})();