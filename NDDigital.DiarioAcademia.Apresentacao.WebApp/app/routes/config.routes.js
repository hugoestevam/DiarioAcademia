(function () {
    'use strict';

    angular.module('routes.module')
        .config(configRoutes);

    configRoutes.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider', 'routeConfigProvider'];
    function configRoutes($stateProvider, $urlRouterProvider, $locationProvider, routeConfigProvider) {
        var routes = routeConfigProvider.$get();

        $urlRouterProvider.otherwise(function ($injector, $location) {
            var $state = $injector.get("$state");
            $state.go("home");
        });

        //register all states
        for (var i = 0; i < routes.length; i++) {
            var route = routes[i];
            $stateProvider
                .state(route.name, {
                    url: route.url,
                    templateUrl: route.templateUrl,
                    controller: route.controller,
                    abstract: route.abstract,
                    data: {
                        displayName: route.displayName,
                        allowAnnonymous: route.allowAnnonymous,
                        $$permissionId: verifyPermission(routes, i, route)
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

    function verifyPermission(routes, startIndex, route) {
        var exclude = ['home', 'homeapp'];
        var errorpermissionIdUndefined = " can't have the attribute $$permissionId to be undefined",
            errorpermissionIdAlreadyExists = " can't have the attribute $$permissionId because already exists";
        if (route.abstract)
            return;
        for (var i = startIndex + 1; i < routes.length; i++) {
            var other = routes[i];
            if (other.abstract || exclude.contains(other.name))
                continue;
            if (!other.$$permissionId)
                throwRouteError(routes[i].name, errorpermissionIdUndefined);
            if (other.$$permissionId == route.$$permissionId)
                throwRouteError(routes[i].name, errorpermissionIdAlreadyExists);
        }
        return route.$$permissionId;
    }

    function throwRouteError(route, msg) {
        throw new Error("The route " + route + msg);
    }
})();