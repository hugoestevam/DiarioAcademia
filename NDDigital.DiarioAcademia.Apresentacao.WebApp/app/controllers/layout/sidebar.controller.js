(function () {

    'use strict';
    //using
    sidebarController.$inject = ['authService', '$state'];

    //namespace
    angular
        .module('controllers.module')
        .controller('sidebarController', sidebarController);

    //class
    function sidebarController(authService, $state) {
        var self = this;

        //script load
        activate();
        function activate() {

        }

        self.editUser = function () {
            $state.go('manager.useredit', { userId: authService.authentication.userId });
        }

        self.closeItensOpen = function () {
            $("ul[aria-expanded=true]").collapse('hide');
        }
        //public methods
        self.publicMethod = function () {
        };

        //private methods
        function privateMethod() {
        };
    }

})();