(function (angular) {
    angular.module('controllers.module')
        .controller('managerPermissionController', managerPermissionController);

    managerPermissionController.$inject = ['permissionsService', 'compareState', '$state'];

    function managerPermissionController(permissionService, compareState, $state) {
        var vm = this;

        vm.permission = [];
        vm.compareState = compareState;
        vm.filters = ['aluno', 'turma', 'other', 'manager'];

       activate();
        function activate() {
            permissionService.getPermissions().then(function (results) {
                vm.routes = results.data;
            });
            vm.permission = filterPermissions($state.get());
        }

        function filterPermissions(states) {
            var filtered = [];
            for (var i = 0; i < states.length; i++) {
                var state = states[i];
                if (state.abstract) {
                    states.splice(i, 1);
                    i--;
                    continue;
                }
                var filter = state.name.split(".");
                filter = filter.length >= 2 ? filter[0] : 'other';
                if (!filtered[filter])
                    filtered[filter] = [];
                if (!vm.filters.contains(filter))
                    vm.filters.push(filter);
                filtered[filter].push(state);
            }
            return filtered;
        }

    }
})(window.angular);