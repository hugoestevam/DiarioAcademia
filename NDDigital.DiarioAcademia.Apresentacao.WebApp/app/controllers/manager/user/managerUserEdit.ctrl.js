(function (angular) {
    angular
        .module('controllers.module')
        .controller('managerUserEditController', managerUserEditController);

    managerUserEditController.$inject = ['userService', "$stateParams", '$scope', '$state']

    function managerUserEditController(managerService, params, $scope, $state) {
        var vm = this;
        vm.user = {};
        vm.groups = [];
        vm.editUser = editUser;

        //public functions
        vm.isChecked = isChecked;
        vm.changeGroup = changeGroup;
        vm.clear = clear;

        vm.titleModelEdit = 'Confirmar Alteração';
        vm.bodyModelEdit = 'Deseja realmente editar o usuário ';

        var originalUser;
        var originalGroups;
        var result;

        activate();
        function activate() {
            managerService.getUserById(params.userId).then(function (results) {
                vm.user = results.data;

                originalUser = $.extend(true, {}, vm.user);;
                vm.name = vm.user.fullName;
                vm.bodyModelEdit += vm.name;
            });
            for (var i = 0; i < 10; i++) {
                vm.groups.push({ id: i, name: "Group " + i });
            }
        }


        function editUser() {
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
            //TODO
            $state.go('manager.user');
        }

        function isChecked(index, group) {
            var text = $('#textGroup' + index);
            var check = $('#chkGroup' + index);

            if (!vm.user.groups) {
                return false;
            }
            result = vm.user.groups.contains(group);
            if (result) {
                text.addClass('border-success');
                check.addClass('border-success');
            }
            return result;
        }

        function changeGroup(index, group, chkGroups) {
            var text = $('#textGroup' + index);
            var check = $('#chkGroup' + index);

            if (chkGroups) {
                text.addClass('border-success');
                check.addClass('border-success');
                vm.user.groups.push(group);
            } else {
                text.removeClass('border-success');
                check.removeClass('border-success');
                vm.user.groups.remove(group);
            }
        }

        function clear() {
            vm.groups = [];
            vm.user = $.extend(true, {}, originalUser);
            for (var i = 0; i < 10; i++) {
                vm.groups.push({ id: i, name: "Group " + i });
            }
        }

    }

})(window.angular);