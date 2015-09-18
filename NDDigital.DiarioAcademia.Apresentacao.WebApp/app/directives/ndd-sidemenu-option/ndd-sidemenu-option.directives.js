(function (angular) {

    angular.module('directives.module')
        .directive('nddSidemenuOption', nddSidemenuOption);

    function nddSidemenuOption() {
        controller.$inject = ['$state'];
        // Usage:
        //  <ndd-sidemenu-option routeShow="route.toShow" route-actived="route.actived" route: "route.toRedirect" 
        //                       name="myName" state="route.actualState" icon="fa-icon"> </ndd-sidemenu-option>
        return {
            restrict: 'E',
            link: link,
            controller: controller,
            transclude: true,
            replace: false,
            scope: {
                routeShow: "@",
                routeActived: "@",
                route: "@",
                name: "@",
                state: "@",
                icon: "@"
            },
            templateUrl: 'app/directives/ndd-sidemenu-option/ndd-sidemenu-option.html'
        };

        function link(scope, element, attrs) {
            scope.redirect = controller.redirect;
        }

        function controller($state) {
            controller.redirect = function (route) {
                if (route && route != "")
                    $state.go(route);
            }
        }

    }

})(window.angular);