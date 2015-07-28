(function (angular) {

    angular.module('controllers.module')
        .controller('managerGroupEditController', managerGroupEditController);

    managerGroupEditController.$inject = ['groupService', '$stateParams'];

    function managerGroupEditController(groupService, params) {
        var vm = this;

        vm.group = {};

        activate();
        function activate() {
            groupService.getGroupById(params.groupId).then(function (results) {
                vm.group = results.data;
            });
        }
    }

})(window.angular);