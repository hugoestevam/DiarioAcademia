(function (angular) {
    angular.module('controllers.module')
        .controller('managerPermissionController', managerPermissionController);

    managerPermissionController.$inject = ['permissionsService', 'compareState', '$state'];

    function managerPermissionController(permissionService, compareState, $state) {
        var vm = this;

        vm.permission = [];
        vm.filters = ['aluno', 'turma', 'other', 'manager', 'aula', 'chamada'];
        vm.showRoutes = [];
        vm.hasChange = false;
        vm.changes = [];

        vm.compareState = compareState;
        vm.onchange = onchange;
        vm.saveChanges = saveChanges;


        activate();
        function activate() {
            permissionService.getPermissions().then(function (results) {
                vm.routes = results.data;
                vm.showRoutes = vm.routes.slice();
            });
            vm.permission = filterPermissions($state.get());
        }


        //public methods

        function onchange(obj, check) {
            vm.hasChange = true;
            if (compareState(vm.changes, obj) < 0)
                vm.changes.push(obj);
            obj.action = check;
        }

        function saveChanges() {
            vm.hasChange = false;
            for (var i = 0; i < vm.changes.length; i++) {
                if (vm.changes[i].action)
                    save(vm.changes[i]);
                else
                    remove(vm.changes[i]);
            }
            vm.changes = [];
        }

        //private methods

        function save(item) {
            permissionService.save(item)
                .then(function (data, status, headers, config) {
                    vm.routes.push(item);
                });
        }

        function remove(item) {
            if (compareState(vm.routes, item) < 0)
                return;
            permissionService.delete(item)
                .then(function (data, status, headers, config) {
                    var index = compareState(vm.routes, item)
                    if (index >= 0)
                        vm.routes.splice(index, 1);
                });
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