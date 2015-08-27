(function (angular) {
    angular.module('controllers.module')
        .controller('managerGroupPermissionEditController', managerGroupPermissionEditController);

    managerGroupPermissionEditController.$inject = ['groupService', 'permissionsService', 'permissions.factory', 'compareState',
        '$state', '$stateParams', 'changes.factory'];

    function managerGroupPermissionEditController(groupService, permissionsService, permissionsFactory,
        compareState, $state, params, changesFactory) {

        var vm = this;

        //public functions
        vm.comparePermissions = compareState;
        vm.permissions = [];
        vm.modal = modal;
        vm.saveChanges = saveChanges;
        vm.onchange = onchange;
        vm.hasChange = false;
        vm.changes = [];

        activate();
        function activate() {
            $(function () {
                $('[data-toggle="tooltip"]').tooltip();
            });

            groupService.getGroupById(params.groupId).then(function (results) {
                if (results == undefined)
                    $state.go('manager.group');
                vm.group = results;

                permissionsService.getPermissions().then(function (results) {
                    var permissionsDb = results;
                    for (var i = 0; i < permissionsDb.length; i++) {
                        var permission = permissionsFactory.getPermissionById(permissionsDb[i].permissionId);
                        permission.id = permissionsDb[i].id;
                        vm.permissions.push(permission);
                    }
                });

            });
        }

        function onchange(obj, check) {
            vm.hasChange = true;
            if (compareState(vm.changes, obj) < 0)
                vm.changes.push(obj);
            obj.action = check;
        }

        function saveChanges() {
            vm.hasChange = false;
            if (vm.changes.length != 0) {
                var include = changesFactory.getInclude(vm.changes);
                var exclude = changesFactory.getExclude(vm.changes);
                if (include.length > 0)
                    save(include);
                if (exclude.length > 0)
                    remove(exclude);
            }
        }

        function save(permission) {
            groupService.addPermission(vm.group, permission).then(function (results) {
                $state.go('manager.group.edit', { groupId: vm.group.id }, { reload: true });
            });
        }

        function remove(permission) {
            groupService.removePermission(vm.group, permission).then(function (results) { });
        }

        function modal() {
            vm.titleModalEdit = 'Edição';
            vm.bodyModalEdit = 'Editar ' + vm.group.name + ' ?';
        }
    }
})(window.angular);