(function (angular) {
    angular.module('controllers.module')
        .controller('managerPermissionController', managerPermissionController);

    managerPermissionController.$inject = ['permissionsService', 'compareState', 'permissions.factory', '$state', '$rootScope'];

    function managerPermissionController(permissionService, compareState, permissionsFactory, $state, $rootScope) {
        var vm = this;

        vm.filters = ['aluno', 'turma', 'other', 'manager', 'aula', 'chamada', 'customize'];
        vm.showRoutes = [];
        vm.hasChange = false;
        vm.changes = [];

        vm.compareState = compareState;
        vm.onchange = onchange;
        vm.saveChanges = saveChanges;

     

        activate();
        function activate() {
            permissionService.getPermissions().then(function (results) {
                vm.routes = results;
                vm.showRoutes = vm.routes.slice();
            });
            vm.permission = filterPermissions(permissionsFactory.getDefaultPermissions());

           
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

            var index = compareState(vm.routes, item);
            if (index >= 0)
                var permission = vm.routes[index];
            permissionService.delete(permission)
                .then(function (data, status, headers, config) {
                        vm.routes.splice(index, 1);
                });
        }

        function filterPermissions(permissions) {
            var filtered = [];
            for (var i = 0; i < permissions.length; i++) {
                var permission = permissions[i];
                var filter = permission.name.split(".");
                filter = filter.length >= 2 ? filter[0] : 'other';
                if (!filtered[filter])
                    filtered[filter] = [];
                if (!vm.filters.contains(filter))
                    vm.filters.push(filter);
                filtered[filter].push(permission); // parse state for permission
            }
            filtered['customize'] = permissionsFactory.getCustomPermissions();
            return filtered;
        }

    }
})(window.angular);