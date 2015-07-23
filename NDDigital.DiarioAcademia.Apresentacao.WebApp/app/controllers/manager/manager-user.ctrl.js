(function (angular) {

    managerUserController.$inject = ['$scope','userService'];

    angular
        .module('controllers.module')
        .controller('managerUserController', managerUserController);

    function managerUserController($scope, managerService) {
        var vm = this;     
        vm.title = 'Usuários';

        var users = [];
        $scope.filteredTodos = []
        $scope.currentPage = 1
        $scope.numPerPage = 10
        $scope.maxSize = 5;


       

        //public methods
        vm.edit = edit;
        vm.remove = remove;
        vm.modal = modal;


        activate();
        function activate() {
            managerService.getUsers().then(function (results) {
                users = results.data;
            });
        }

        $scope.$watch("currentPage + numPerPage", function () {
            var begin = (($scope.currentPage - 1) * $scope.numPerPage)
            , end = begin + $scope.numPerPage;

            vm.users = users.slice(begin, end);
        });

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