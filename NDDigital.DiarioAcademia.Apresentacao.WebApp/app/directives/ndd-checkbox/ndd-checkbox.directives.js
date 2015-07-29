(function (angular) {

    angular.module('directives.module')
        .directive('nddCheckbox', nddCheckbox);

    function nddCheckbox() {
        // Usage:
        //  <ndd-checkbox array="vm.myArray" compare="vm.compareArray" callback="vm.actionOnChange"></ndd-checkbox>
        return {
            restrict: 'EA',
            link: link,
            transclude: false,
            replace: false,
            scope: {
                array: "=",
                compare: "=",
                callback: "="
            },
            templateUrl: 'app/directives/ndd-checkbox/ndd-checkbox.html'
        };

        function link(scope, element, attrs) {
            scope.onstart = onstart;
            scope.onclick = onclick;
        }

        function onstart(index, obj, compare) {
            var element = $('#inputGroup' + index + " *");
            var result = compare.containsObject(obj);
            if (result) {
                element.addClass('border-success');
            } else {
                element.removeClass('border-success');
            }
            return result;
        }

        function onclick(index, obj, compare, chkGroups, callback) {
            var element = $('#inputGroup' + index + " *");
            if (chkGroups) {
                element.addClass('border-success');
                compare.push(obj);
            } else {
                element.removeClass('border-success');
                compare.remove(obj);
            }
            if (callback)
                callback();
        }
    }



})(window.angular);

