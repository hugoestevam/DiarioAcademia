(function (angular) {
    angular.module('app.group')
        .controller('managerGroupListController', managerGroupListController);

    managerGroupListController.$inject = ['groupService', '$state', '$location', '$scope'];

    function managerGroupListController(groupService, $state, $location, $scope) {
        var vm = this;
        vm.groups = [];

        vm.remove = remove;
        vm.cbEdit = cbEdit;
        vm.cbRemove = cbRemove;

        vm.selectedGroup = undefined;


        activate();
        function activate() {
            makeRequest();
        }

        function makeRequest() {
            groupService.getGroups().then(function (results) {
                vm.groups = results;
            });
        }

        // public methods

        function cbEdit(group) {
            if (!group)
                return;
            $state.go('app.group.edit', { groupId: group.id })
        }

        function cbRemove(group) {
            if (!group)
                return;
            vm.selectedGroup = group;
            modal(group);
            $("#modelRemoveGroup").modal();
        }

        function remove() {
            groupService.delete(vm.selectedGroup).then(function (results) {
                makeRequest();
                vm.selectedGroup = {};
            });
        }

        function modal(group) {
            vm.titleModelRemove = 'Exclusão';
            vm.bodyModelRemove = 'Remover ' + group.name + '?'
        }
    }
})(window.angular);