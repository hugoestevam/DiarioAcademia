(function (angular) {

    angular.module('directives.module')
        .directive('nddPopover', nddPopover);

    function nddPopover() {
        // Usage:
        //  <ndd-popover></ndd-popover>
        return {
            restrict: 'E',
            link: link,
            scope: {
                user: "="
            }
        };

        function link(scope, element, attrs) { }
   }

})(window.angular);