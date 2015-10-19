(function () {

    'use strict';
    //using
    navbarController.$inject = [];

    //namespace
    angular
        .module('controllers.module')
        .controller('navbarController', navbarController);

    //class
    function navbarController() {
        var self = this;

        //script load
        activate();
        function activate() {

        }

        //public methods
        self.publicMethod = function () {
        };

        //private methods
        function privateMethod() {
        };
    }

})();