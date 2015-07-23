(function () {
    'use strict';
    angular.module('core.module', [
        //3th party
        'ui.router'
        , 'ui.bootstrap'
        , 'LocalStorageModule'
        , 'angular-loading-bar'
        , 'ngAutomapper'
    
        //app modules
        , 'common.module'
        , 'controllers.module'
        , 'directives.module'
        , 'filters.module'
        , 'routes.module'
        ,'services.module'
    ])
    
    .run(runStateChangeSuccess);

    

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
                // Somente autentica e/ou autoriza estado se o mesmo não tiver acesso anônimo permitido.
                if (toState.data.allowAnonymous)  return false;

                     var redirecToLogin = false;

                    // Autoriza o acesso se o estado possui papéis definidos, caso contrário apenas autentica.
                    if (toState.data.authorizedRoles)
                        redirecToLogin = !authService.authorization.isAuthorized(toState.data.authorizedRoles);
                    else {
                        redirecToLogin = !authService.authentication.isAuth;
                        // Guarda o estado atual para o posterior redirecionamento após autenticação.
                       // if (redirecToLogin)
                       //     authService.stateToGoAfterAuthenticated = toState.name;
                    }

                    // Redireciona para o estado de login, por falta de autorização ou autenticação.
                    if (redirecToLogin) {
                        event.preventDefault();
                        authService.logOut();
                        $state.go('login');
                    }
                
            });
    }

})(window.angular);