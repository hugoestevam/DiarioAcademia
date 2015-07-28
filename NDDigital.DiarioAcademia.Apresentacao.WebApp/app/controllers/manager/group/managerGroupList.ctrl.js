(function (angular) {
    angular.module('controllers.module')
        .controller('managerGroupListController', managerGroupListController);

    managerGroupListController.$inject = ['groupService', '$state', '$location'];

    function managerGroupListController(groupService, $state, $location) {
        var vm = this;

        vm.groups = [];
        vm.showGroup = showGroup;
        vm.selectedGroup = undefined;
        vm.remove = remove;
        vm.modal = modal;

        var params = getParams();

        activate();
        function activate() {
            groupService.getGroups().then(function (results) {
                vm.groups = results.data;
            });
            if (params == "")
                return;
            groupService.getGroupById(parseInt(params)).then(function (results) {
                vm.selectedGroup = results.data;
            });
        }

        // public methods
        function showGroup(group) {
            $state.go('manager.group.edit', { groupId: group.id });
            vm.selectedGroup = group;
        }

        function remove() {
            groupService.delete(vm.selectedGroup).then(function (results) {
                vm.groups.remove(vm.selectedGroup);
            });
        }

        function modal() {
            vm.titleModelRemove = 'Exclusão';
            vm.bodyModelRemove = 'Remover ' + vm.selectedGroup.name + ' ?';
        }

        function getParams() {
            var path = $location.path();
            path = path.replace('/manager/group', "")
            path = path.slice(path.lastIndexOf('/') + 1, path.length);
            return path;
        }
    }

})(window.angular);