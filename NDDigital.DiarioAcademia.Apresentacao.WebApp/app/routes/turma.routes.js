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
            templateUrl: '/app/templates/components/inner-view.html'
        }, {
            state: 'turma.list',
            url: '/list',
            controller: 'turmaListController as vm',
            templateUrl: '/app/views/turma/turma-list.html',
            data: {
                displayName: "turma's List"
            }
        }, {
            state: 'turma.create',
            url: '/create',
            controller: 'turmaCreateController as vm',
            templateUrl: '/app/views/turma/turma-create.html',
            data: {
                displayName: "turma's Create"
            }
        }
        );

    }

})();