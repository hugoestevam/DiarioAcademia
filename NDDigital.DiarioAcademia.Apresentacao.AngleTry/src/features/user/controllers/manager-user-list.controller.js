(function (angular) {

    angular
        .module('app.user')
        .controller('managerUserListController', managerUserListController);

    managerUserListController.$inject = ['$scope', 'userService', '$state'];

    function managerUserListController($scope, managerService, $state) {
        var vm = this;
        var users = [];

      
        //public methods
        vm.modal = modal;
        vm.remove = remove;
        vm.cbRemove = cbRemove;
        vm.cbEdit = cbEdit;

        //angular pagination
        vm.currentPage = 1;
        vm.numPerPage = 10;
        vm.maxSize = 4;
        vm.countUsers = 0;

        activate();
        function activate() {
            makeRequest();     
        }

        function makeRequest() {
            managerService.getUsers().then(function (results) {
                users = results;
                vm.countUsers = users.length;

                $scope.$watch("vm.currentPage + vm.numPerPage", function () {
                    var begin = ((vm.currentPage - 1) * vm.numPerPage)
                    , end = begin + vm.numPerPage;
                    vm.users = users.slice(begin, end);
                });
            });
        }


        function cbEdit(user) {
            if (user)
                $state.go('app.user.edit', { userId: user.id });
        }

       
        function cbRemove(user) {
            if (!user)
                return;
            vm.user = user;
            vm.modal(user);
            $("#modelRemoveUser").modal();
        }

        // Private Methods
        function remove() {
            managerService.delete(vm.user).then(function (results) {
                makeRequest();
                vm.user = undefined;
            });
        }

        function modal(user) {
            vm.user = user;
            vm.titleModelRemove = 'Exclusão';
            vm.bodyModelRemove = 'Remover ' + user.fullName + ' (' + user.userName + ') ?'
        }

    }
})(window.angular);