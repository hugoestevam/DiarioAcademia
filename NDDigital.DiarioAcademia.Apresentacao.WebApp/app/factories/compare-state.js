(function (angular) {
    angular.module("factories.module")
        .factory("compareState", compareState);

    function compareState() {
        return function (array, obj) {
            for (var i = 0; i < array.length; i++) {
                if (array[i].name == obj.name)
                    return i;
            }
            return -1;
        }
    }
})(window.angular);