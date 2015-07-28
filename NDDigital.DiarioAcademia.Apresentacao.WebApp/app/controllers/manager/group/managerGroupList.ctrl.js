(function (angular) {
    angular.module('controllers.module')
        .controller('managerGroupListController', managerGroupListController);

    managerGroupListController.$inject = ['groupService', '$state'];

    function managerGroupListController(groupService, $state) {
        var vm = this;

        vm.groups = [];
        vm.showGroup = showGroup;
        activate();
        function activate() {
            groupService.getGroups().then(function (results) {
                vm.groups = results.data;
            });
        }

        function showGroup(group) {
            $state.go('manager.group.edit', { groupId: group.id });
        }
    }

})(window.angular);