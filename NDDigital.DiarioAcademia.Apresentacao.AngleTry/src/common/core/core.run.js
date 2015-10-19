(function () {
    'use strict';

    angular
        .module('app.core')
        .run(appRun)
        .run(runStateChangeSuccess)
        .run(runStateChangeStart);


    appRun.$inject = ['$rootScope', '$state', '$stateParams', '$window', '$templateCache', 'Colors'];
    function appRun($rootScope, $state, $stateParams, $window, $templateCache, Colors) {
        // Set reference to access them from any scope
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;
        $rootScope.$storage = $window.localStorage;

        // Allows to use branding color with interpolation
        // {{ colorByName('primary') }}
        $rootScope.colorByName = Colors.byName;

        // cancel click event easily
        $rootScope.cancel = function ($event) {
            $event.stopPropagation();
        };

        // Hooks Example
        // ----------------------------------- 

        // Hook not found
        $rootScope.$on('$stateNotFound',
          function (event, unfoundState/*, fromState, fromParams*/) {
              console.log(unfoundState.to); // "lazy.state"
              console.log(unfoundState.toParams); // {a:1, b:2}
              console.log(unfoundState.options); // {inherit:false} + default options
          });
        // Hook error
        $rootScope.$on('$stateChangeError',
          function (event, toState, toParams, fromState, fromParams, error) {
              console.log(error);
          });
        // Hook success
        $rootScope.$on('$stateChangeSuccess',
          function (/*event, toState, toParams, fromState, fromParams*/) {
              // display new view from top
              $window.scrollTo(0, 0);
              // Save the route title
              $rootScope.currTitle = $state.current.title;
          });

        // Load a title dynamically
        $rootScope.currTitle = $state.current.title;
        $rootScope.pageTitle = function () {
            var title = $rootScope.app.name + ' - ' + ($rootScope.currTitle || $rootScope.app.description);
            document.title = title;
            return title;
        };
    }


    runStateChangeSuccess.$inject = ["$rootScope"];
    function runStateChangeSuccess($rootScope) {
        $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
            $rootScope.previousState = fromState;
            $rootScope.title = toState.data.displayName;
            $rootScope.state = toState.name;
            console.log({ Change: "succes: ", fromState: fromState.name, toState: toState.name });
        });
        $rootScope.$on('$stateNotFound',
               function (event, unfoundState, fromState, fromParams) {
                   console.log({ Change: "error: ", fromState: fromState.name, toState: unfoundState.to });
               });
    };


    runStateChangeStart.$inject = ['$rootScope', '$state', 'authService', 'logger'];
    function runStateChangeStart($rootScope, $state, authService, logger) {

        $rootScope.$on('$stateChangeStart',
           function (event, toState, toParams, fromState, fromParams) {

               if (authService.authentication.isAuth && toState.name == 'login') {
                   event.preventDefault();
                   return $state.go('app.home');
               }

               if (!authService.authentication.isAuth && toState.name == 'app.home') {
                   event.preventDefault();
                   return $state.go('login');
               }

               if (toState.data.allowAnnonymous) return;

               if (authService.authorization.groups)
                   var userIsAdmin = authService.authorization.groups.any('isAdmin', true);

               if (authService.authorization.isAdmin) return;

               var stateToGo = 'login';

               if (authService.authentication.isAuth) {
                   var hasPermission = authService.checkAuthorize(toState.name);
                   if (hasPermission) return;
               }

               logger.warning("Você não tem permissão para acessar \"" + toState.data.displayName + "\"");

               authService.lastState = toState.name;
               event.preventDefault();
               $state.go(stateToGo);
           });
    }


})();

