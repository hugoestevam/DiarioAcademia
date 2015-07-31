(function (angular) {

    managerUserController.$inject = ['$scope','userService'];

    angular
        .module('controllers.module')
        .controller('managerUserController', managerUserController);

    function managerUserController($scope, managerService) {
        var vm = this;     
        vm.title = 'Usuários';

        var users = [];
        vm.countUsers = 0;

        vm.currentPage = 1
        vm.numPerPage = 10
        vm.maxSize = 5;

     
        //public methods
        vm.edit = edit;
        vm.remove = remove;
        vm.modal = modal;


        activate();
        function activate() {
            managerService.getUsers().then(function (results) {
                users = results.data;
                vm.countUsers = users.length;

                $scope.$watch("vm.currentPage + vm.numPerPage", function () {
                    var begin = ((vm.currentPage - 1) * vm.numPerPage)
                    , end = begin + vm.numPerPage;
                    vm.users = users.slice(begin, end);
                });
            });
        }

       

        function edit(user) {

        }

        function remove() {

        }


        function modal(user) {
            vm.titleModelRemove = 'Exclusão';
            vm.bodyModelRemove = 'Remover ' + user.fullName + ' (' + user.userName + ') ?'
           
        }
    }
})(window.angular);