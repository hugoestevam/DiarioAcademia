(function () {

    'use strict';

    angular.module('routes.module')
        .config(configRoutes);

    configRoutes.$inject = ['$stateProvider', '$urlRouterProvider', 'routeConfigProvider'];
    function configRoutes($stateProvider, $urlRouterProvider, routeConfigProvider) {
        var routes = routeConfigProvider.$get();

        $urlRouterProvider.otherwise('/home');

        //register all states
        for (var i = 0; i < routes.length; i++) {
            var route = routes[i];
            $stateProvider
                .state(route.state, {
                    url: route.url,
                    templateUrl: route.templateUrl,
                    controller: route.controller,
                    abstract: route.abstract,
                    data: {
                        displayName: route.displayName,
                        allowAnnonymous: route.allowAnnonymous,
                        $$permissionId: 'a'
                    },
                    ncyBreadcrumb: {
                        label: route.displayName,
                        icon: route.displayIcon,
                    },
                });
            if (route.abstract)
                $urlRouterProvider.when(route.url, route.redirect);
        }
    }


    function verififyPermission(routes, startIndex, route) {
        var error$$permissionIdUndefined = " can't have the attribute $$permissionId to be undefined",
            error$$permissionIdAlreadyExists = " can't have the attribute $$permissionId because already exists";
        if (route.abstract)
            return;
        for (var i = startIndex + 1; i < routes.length; i++) {
            var other = routes[i];
            if (other.abstract)
                continue;
            if (!other.$$permissionId)
                throwRouteError(routes[i].state, error$$permissionIdUndefined);
            if (other.$$permissionId == route.$$permissionId)
                throwRouteError(routes[i].state, error$$permissionIdAlreadyExists);
        }
        return "0x" + route.$$permissionId;
    }

    function throwRouteError(route, msg) {
        throw new Error("The route " + route + msg);
    }

})();