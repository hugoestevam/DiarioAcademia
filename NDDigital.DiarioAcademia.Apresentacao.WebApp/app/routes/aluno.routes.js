(function () {
    'use strict';
    var KEYS = angular.injector(['common.module']).get('CONSTANT_KEYS');

    angular
        .module('routes.module')
        .config(configRoutes);

    configRoutes.$inject = [KEYS.APP_ROUTES];

    function configRoutes(routes) {
        routes.push({
            name: 'aluno',
            url: '/aluno',
            redirect: '/aluno/list',
            templateUrl: '/app/templates/components/inner-view.html',
            displayName: "Aluno",
            displayIcon: "fa-user",
            $$permissionId: "02"
        }, {
            name: 'aluno.list',
            url: '/list',
            controller: 'alunoListCtrl as vm',
            templateUrl: '/app/views/aluno/aluno-list.html',
            allowAnnonymous: false,
            displayName: "Lista de Aluno",
            displayIcon: "fa-user",
            $$permissionId: "03"
        }, {
            name: 'aluno.details',
            url: '/details/:alunoId',
            controller: 'alunoDetailsCtrl as vm',
            templateUrl: '/app/views/aluno/aluno-details.html',
            displayName: "Detalhes do Aluno",
            $$permissionId: "04"
        }, {
            name: 'aluno.create',
            url: '/create',
            controller: 'alunoCreateCtrl as vm',
            templateUrl: '/app/views/aluno/aluno-create.html',
            displayName: "Criação de Aluno",
            displayIcon: "fa-user-plus",
            $$permissionId: "05"
        });
    }
})();