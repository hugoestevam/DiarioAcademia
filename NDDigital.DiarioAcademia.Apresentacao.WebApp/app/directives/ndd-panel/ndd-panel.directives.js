(function (angular) {

    angular.module('directives.module')
        .directive('nddPanel', nddModal);

    function nddModal() {
        // Usage:
        //  <ndd-panel title= "myTitle"  icon="fa-user" ></ndd-panel>
        return {
            restrict: 'EA',
            link: link,
            transclude: true,
            replace: false,
            scope: {
                title: "@",
                icon: "@",
            },
            templateUrl: 'app/directives/ndd-panel/ndd-panel.html'
        };

        function link(scope, element, attrs) {
            scope.class = getClassPanel(scope.title.toLowerCase());
        }

        function getClassPanel(name) {
            switch (name) {
                case 'alunos':
                    return 'bk-clr-one';
                case 'turmas':
                    return 'bk-clr-two ';
                case 'chamada':
                    return 'bk-clr-four';
                default:
                    return 'bk-clr-three';
            }
        }
    }



})(window.angular);

