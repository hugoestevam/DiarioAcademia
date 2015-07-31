(function (angular) {
    angular.module('directives.module')
             .directive('nddHead', nddHead);

    function nddHead() {
        //Usage:
        //<ndd-head title="myTitle"><ndd-head>
        return {
            restrict: "E",
            link: link,
            transclude: true,
            replace: false,
            scope: {
                title:"@"
            },
            templateUrl: 'app/directives/ndd-head/ndd-head.html'
        };

        function link(scope, element, attrs) {

        }
    }

})(window.angular);