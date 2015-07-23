(function () {

    'use strict';

    // global variable
    var KEYS = angular.injector(['common.module']).get('CONSTANT_KEYS');
    
    //using
    shellController.$inject = ['$location', 'authService',KEYS.USER_ROLES];

    //shellspace
    angular
        .module('controllers.module')
        .controller('shellController', shellController);

    //class
    function shellController($location, authService,USER_ROLES) {
        var self = this;

        //script load
        activate();
        function activate() {
            authService.authentication.userName = "User";
            self.authentication = authService.authentication;
            self.authorization = authService.authorization;
            self.USER_ROLES = USER_ROLES;
        }
        
        //public methods
        self.logOut = function () {
            authService.logOut();
            $location.path('/home');
        };
    }
})();