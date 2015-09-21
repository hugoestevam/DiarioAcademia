(function (angular) {
    angular.module('directives.module')
             .directive('nddChartKnob', nddChartKnob);

    function nddChartKnob() {
        //Usage:
        //<ndd-chart-knob name="displayNameChart" color="#ccc" data="vm.entities.length"><ndd-chart-knob>

        return {
            restrict: "E",
            link: link,
            scope: {
                name: "@",
                data: '@',
                color: '@',
                target: "@",
                security: "@"
            },
            templateUrl: 'app/directives/ndd-chart-knob/ndd-chart-knob.html'
        };

        function link(scope, element, attrs) {
            attrs.$observe('data', function (newValue, oldValue) {
                chartAlunos(newValue, scope.color, scope.target);
            });
        }

        function chartAlunos(count, color, target) {
            if (!count)
                return;
            $(document).ready(function () {
                $("#" + target).each(function () {
                    var elm = $(this);
                    elm.knob({
                        'min': 0,
                        'max': count,
                        "skin": "tron",
                        "readOnly": true,
                        "thickness": .02,
                        'dynamicDraw': true,
                        "displayInput": true,
                        "lineCap": "round",
                        "fgColor": color || "62C4FF",
                        angleArc: "250",
                        angleOffset: "-125"
                    });

                    $({ value: 0 }).delay(600).animate({ value: count }, {
                        duration: 1000,
                        easing: 'swing',
                        progress: function () {
                            elm.val(Math.ceil(this.value)).trigger('change');
                        }
                    });

                    $('ndd-chart-knob[target =' + target + '] strong').attr({ 'style': 'color: ' + color });
                });

            });
        }

    }

})(window.angular);