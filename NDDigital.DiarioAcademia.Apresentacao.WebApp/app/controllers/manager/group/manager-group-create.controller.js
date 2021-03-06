﻿(function (angular) {

    managerGroupCreateController.$inject = ['groupService', '$state'];

    angular.module('controllers.module')
        .controller('managerGroupCreateController', managerGroupCreateController);


    function managerGroupCreateController(groupService, $state) {
        var vm = this;

        //public methods
        vm.save = save;
        vm.setAdmin = setAdmin;
        vm.group = {};

        function save() {
            if (!vm.group.name)
                return;
            groupService.save(vm.group).then(function (results) {
                $state.go('manager.group.list');
            });
        }

        function setAdmin() {
            vm.group.isAdmin = !vm.group.isAdmin;
        }

    }

})(window.angular);