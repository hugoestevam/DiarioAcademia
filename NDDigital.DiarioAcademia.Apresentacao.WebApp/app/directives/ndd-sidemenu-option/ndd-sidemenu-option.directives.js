(function (angular) {

    angular.module('directives.module')
        .directive('nddSidemenuOption', nddSidemenuOption);

    function nddSidemenuOption() {
        controller.$inject = ['$state'];

        // Usage:
        //  <ndd-sidemenu-option >
        return {
            restrict: 'E',
            link: link,
            controller: controller,
            transclude: true,
            replace: true,
            scope: {
                routeShow: "@",
                route: "@",
                name:"@",
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
                $state.go(route);
            }
        }

    }

})(window.angular);