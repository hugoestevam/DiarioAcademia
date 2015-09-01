(function (angular) {
    angular.module('controllers.module')
        .controller('managerPermissionController', managerPermissionController);

    managerPermissionController.$inject = ['permissionsService', 'compareState', 'permissions.factory', '$state', '$rootScope', 'changes.factory'];

    function managerPermissionController(permissionService, compareState, permissionsFactory, $state, $rootScope, changesFactory) {
        var vm = this;

        vm.filters = permissionsFactory.getFilters();
        vm.showRoutes = [];
        vm.hasChange = false;
        vm.changes = [];

        vm.compareState = compareState;
        vm.onchange = onchange;
        vm.saveChanges = saveChanges;
        vm.selectPermissions = selectPermissions;


        activate();
        function activate() {
            permissionService.getPermissions().then(function (results) {
                vm.routes = results;
                vm.showRoutes = vm.routes.slice();
                vm.permission = permissionsFactory.filterPermissions(vm.showRoutes);
            });
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
        function save(array) {
            clearPermissions(array, true);
            if (array.length == 0)
                return;
            permissionService.save(array)
                .then(function (results) {
                    vm.routes = vm.routes.concat(results);
                    vm.permission = permissionsFactory.filterPermissions(vm.showRoutes);
                });
        }

        function remove(array) {
            clearPermissions(array, false);
            if (array.length == 0)
                return;
            permissionService.delete(array)
                .then(function (results) {
                    $state.reload();
                });
        }

        function clearPermissions(array, isSaved) {
            var index;
            for (var i = 0; i < array.length; i++) {
                index = compareState(vm.routes, array[i]);
                if (isSaved ? index >= 0 : index < 0) {
                    array.splice(i, 1);
                    i--;
                }    
            }
        }

        function selectPermissions(isAll, filter) {
            var isShow, index, array = vm.permission[filter];
            for (var i = 0; i < array.length; i++) {
                index = compareState(vm.showRoutes, array[i]);
                isShow = index >= 0;
                if (isAll && !isShow) {
                    vm.showRoutes.push(array[i]);
                    onchange(array[i], isAll);

                } else if (!isAll && isShow) {
                    vm.showRoutes.splice(index, 1);
                    onchange(array[i], isAll);
                }
            }
        }


    }
})(window.angular);