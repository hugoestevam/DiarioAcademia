(function (angular) {
    angular.module('controllers.module')
        .controller('managerGroupListController', managerGroupListController);

    managerGroupListController.$inject = ['groupService', '$state', '$location', '$scope'];

    function managerGroupListController(groupService, $state, $location, $scope) {
        var vm = this;
        var groups = [];
        vm.groups = [];

        vm.new = save;
        vm.showGroup = showGroup;

        vm.newGroup = {};
        vm.creating = false;
        vm.selectedGroup = undefined;

        var params = getParams();

        //angular pagination
        vm.currentPage = 1;
        vm.numPerPage = 4;
        vm.countGroups = 0;
        vm.countTotalGroups = 0;

        activate();
        function activate() {
            groupService.getGroups().then(function (results) {
                groups = results;
                $scope.$watch("vm.currentPage + vm.numPerPage", function () {
                    pagination();
                });
            });

            if (params != "") {
                groupService.getGroupById(parseInt(params)).then(function (results) {
                    vm.selectedGroup = results;
                });
            }
        }

        // public methods
        function showGroup(group) {
            $state.go('manager.group.edit', { groupId: group.id });
            vm.selectedGroup = group;
        }

        //actions
        function save() {
            if (!vm.newGroup.name)
                return;
            groupService.save(vm.newGroup).then(function (results) {
                vm.creating = false;
                groups.push(results);
                pagination();
                vm.newGroup = {};
            });
        }

        // helpers

        function getParams() {
            var path = $location.path().replace('/manager/group', "")
            return path.slice(path.lastIndexOf('/') + 1, path.length);
        }

        function pagination() {
            vm.countTotalGroups = groups.length;
            vm.countGroups = (groups.length / vm.numPerPage) * 10;
            var begin = ((vm.currentPage - 1) * vm.numPerPage)
                   , end = begin + vm.numPerPage;
            vm.groups = groups.slice(begin, end);
        }
    }
})(window.angular);