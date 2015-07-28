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
    
    
    .run(runStateChangeSuccess)
    .run(runStateChangeStart);

    

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

                if (toState.data.allowAnnonymous) return;
                
                var stateToGo = 'login';


                if (authService.authentication.isAuth) {


                    var hasPermission=authService.checkAuthorize(toState.name);

                    stateToGo = hasPermission ? toState.name : stateToGo;
                    
                    authService.lastState = toState;


                    if (hasPermission) return;

                    event.preventDefault();
                    $state.go(stateToGo);


                }


            });
    }

})(window.angular);