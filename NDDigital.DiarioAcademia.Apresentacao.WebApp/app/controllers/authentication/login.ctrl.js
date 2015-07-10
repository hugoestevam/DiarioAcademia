(function() {
 
    'use strict';
    //using
    loginController.$inject = ['$location', 'authService'];
    
    //namespace
    angular
        .module('controllers.module')
        .controller('loginController', loginController);
    
    //class
    function loginController($location, auth) {
        var vm = this;
        vm.title = "Entrar";
        vm.user = "User";

        
        //script load
        activate();
        function activate() {
            vm.loginData = {
                userName: "",
                password: ""
            };
            vm.message = "";
        }
        
        //public methods
        vm.login = function () {
            auth.login(vm.loginData).then(function () {
                $location.path('/home');
            },
            function (err) {
                vm.message = "Erro ao logar";
            });
        };
    }

})();