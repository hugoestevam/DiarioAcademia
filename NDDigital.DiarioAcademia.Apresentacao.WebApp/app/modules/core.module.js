(function () {
    'use strict';
    angular.module('core.module', [
        //3th party
        'ui.router'
        , 'ngAnimate'
        , 'ui.bootstrap'
        , 'LocalStorageModule'
        , 'angular-loading-bar'
        , 'ngAutomapper'
        , 'ncy-angular-breadcrumb'
        //app modules
        , 'common.module'
        , 'factories.module'
        , 'controllers.module'
        , 'directives.module'
        , 'filters.module'
        , 'routes.module'
        , 'services.module'
    ])

    .config(configInterceptors)
    .config(configBreadcrumb)
    .run(runStateChangeSuccess)
    .run(runStateChangeStart);

    configInterceptors.$inject = ['$httpProvider'];
    function configInterceptors($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
        window.scrollTo(0, 0);
    }

    runStateChangeSuccess.$inject = ["$rootScope"];
    function runStateChangeSuccess($rootScope) {
        $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
            $rootScope.previousState = fromState;
            $rootScope.title = toState.data.displayName;
            console.log({ Change: "succes: ", fromState: fromState.name, toState: toState.name });
        });
        $rootScope.$on('$stateNotFound',
               function (event, unfoundState, fromState, fromParams) {
                   console.log({ Change: "error: ", fromState: fromState.name, toState: unfoundState.to });
               });
    };

    runStateChangeStart.$inject = ['$rootScope', '$state', 'authService'];
    function runStateChangeStart($rootScope, $state, authService) {
        $rootScope.$on('$stateChangeStart',
           function (event, toState, toParams, fromState, fromParams) {
               var stateToGo = 'login';

               try {
                   if (toState.data.allowAnnonymous) return;

                   var userIsAdmin = false;

                   if (authService.authorization.groups)
                       userIsAdmin = authService.authorization.groups.any('isAdmin', true);

                   if (userIsAdmin) return;

                   if (authService.authentication.isAuth) {
                       var hasPermission = authService.checkAuthorize(toState.name);
                       if (hasPermission) return;
                   }
                   throw new Error("Not Authenticated");
               } catch (err) {
                   console.error(err.message);
                   cancelRouting();
               }
               function cancelRouting() {
                   authService.lastState = toState.name;
                   event.preventDefault();

                   $state.go(stateToGo);
               }
           });

        $rootScope.$on('$viewContentLoading', function (event, viewConfig) {
            console.log('todo');
        });
    }

    configBreadcrumb.$inject = ["$breadcrumbProvider"];
    function configBreadcrumb($breadcrumbProvider) {
        $breadcrumbProvider.setOptions({
            prefixStateName: 'home',
            includeAbstract: true,
            template: 'bootstrap3', // if templateUrl is undefined
            templateUrl: 'app/templates/layout/breadcrumb.html'
        });
    };
})(window.angular);