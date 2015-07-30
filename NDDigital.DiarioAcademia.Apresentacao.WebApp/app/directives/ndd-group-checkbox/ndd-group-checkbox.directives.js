(function (angular) {
    angular.module('directives.module')
        .directive('nddGroupCheckbox', nddGroupCheckbox);

    function nddGroupCheckbox() {
        // Usage:
        //  <ndd-group-checkbox array="vm.myArray" compare="vm.compareArray" 
        //                      callback="vm.actionOnChange" method="vm.compareMethod"></ndd-group-checkbox>

        return {
            restrict: 'E',
            link: link,
            transclude: false,
            replace: false,
            scope: {
                array: "=",
                compare: "=",
                callback: "=",
                method: "="
            },
            templateUrl: 'app/directives/ndd-group-checkbox/ndd-group-checkbox.html'
        };


        function link(scope, element, attrs) {
            scope.check = check;
            scope.onclick = onclick;
        }

        function check(obj, compare, method) {
            return method && compare ? method(compare, obj) >= 0 :
                             compare ? compare.containsObject(obj) : false;

        }

        function onclick(obj, compare, chkGroups, callback, method) {
            if (chkGroups) {
                compare.push(obj);
            } else {
                var index = method ? method(compare, obj) : compare.indexOfObject(obj);
                if (index >= 0)
                    compare.splice(index, 1);
            }
            if (callback)
                callback();
        }
    }

})(window.angular);