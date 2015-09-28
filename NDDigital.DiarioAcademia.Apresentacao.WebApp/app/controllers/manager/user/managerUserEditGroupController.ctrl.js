(function (angular) {

    angular.module('controllers.module')
        .controller('managerUserEditGroupController', managerUserEditGroupController);

    managerUserEditGroupController.$inject = ['userService','groupService', "$stateParams"];


    function managerUserEditGroupController(userService, groupService, $stateParams) {
        var vm = this;
        vm.hasChange = false;
        vm.changes = [];

        vm.saveChanges = saveChanges;
        vm.onchange = onchange;
        vm.modal = modal;

        activate();
        function activate() {
            userService.getUserById($stateParams.userId).then(function (results) {
                vm.user = results;
                vm.user.groups = vm.user.groups ? vm.user.groups : [];
                originalUser = $.extend(true, {}, vm.user);
                vm.name = vm.user.firstName;
                vm.bodyModelEdit += vm.name;

                groupService.getGroups().then(function (results) {
                    vm.groups = results;
                    if (results)
                        originalGroups = results.slice();
                });
            });
        }

        function onchange(obj, check) {
            vm.hasChange = true;
            if (vm.changes.indexOfObject(obj) < 0)
                vm.changes.push(obj);
            obj.action = check;
        }


        function modal(){
            vm.titleModelEdit = "Edição de Grupos de Usuário";
            vm.bodyModelEdit = "Deseja realmente editar os grupos de " + vm.user.firstName + "? ";
        }

        function saveChanges() {
            vm.hasChange = false;
            var include = [], exclude = [];
            for (var i = 0; i < vm.changes.length; i++) {
                if (vm.changes[i].action)
                    include.push(vm.changes[i].id);
                else
                    exclude.push(vm.changes[i].id);
            }
            if (include.length > 0)
                userService.addUserGroup(vm.user, include);
            if (exclude.length > 0)
                userService.removeUserGroup(vm.user, exclude);
        }

    }

})(window.angular);