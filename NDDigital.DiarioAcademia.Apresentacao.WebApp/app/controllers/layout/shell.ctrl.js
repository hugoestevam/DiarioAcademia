(function () {

    'use strict';
    //using
    shellController.$inject = ['$location', 'authService'];

    //shellspace
    angular
        .module('controllers.module')
        .controller('shellController', shellController);

    //class
    function shellController($location, authService) {
        var self = this;

        //script load
        activate();
        function activate() {
            authService.authentication.userName = "User";
            self.authentication = authService.authentication;
        }
        
        //public methods
        self.logOut = function () {
            authService.logOut();
            $location.path('/home');
        };
    }
})();