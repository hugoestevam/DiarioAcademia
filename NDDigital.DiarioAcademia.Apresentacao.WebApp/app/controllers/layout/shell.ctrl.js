(function () {

    'use strict';

    //using
    shellController.$inject = ['$state','$location', 'authService'];

    //namespace
    angular
        .module('controllers.module')
        .controller('shellController', shellController);
    
    //class
    function shellController($state,$location, authService) {
        var self = this;

        //script load
        activate();
        function activate() {
            authService.authentication.userName = authService.authentication.userName||"User";
            self.authentication = authService.authentication;
            self.authorization = authService.authorization;
            


        }
        
        //public methods
        self.logOut = function () {
            authService.logOut();
            $location.path('/home');
        };

        self.isVisible = function (state) {
            return self.authorization.isAuthorized(state);
        };
    }
})();