(function (angular) {
    angular.module('controllers.module')
        .controller('managerPermissionController', managerPermissionController);

    managerPermissionController.$inject = ['permissionsService', 'compareState', 'permissions.factory', '$state', '$rootScope', 'changes.factory'];

    function managerPermissionController(permissionService, compareState, permissionsFactory, $state, $rootScope, changesFactory) {
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
            if (vm.changes.length == 0)
                return;
            var include = changesFactory.getInclude(vm.changes),
                exclude = changesFactory.getExclude(vm.changes);
            if (include.length != 0)
                save(include);
            if (exclude.length != 0)
                remove(exclude);
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
            permissionService.delete(item)
                .then(function (results) {
                    $state.reload();
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