(function () {

    'use strict';
    //using
    sidebarController.$inject = [];

    //namespace
    angular
        .module('controllers.module')
        .controller('sidebarController', sidebarController);

    //class
    function sidebarController() {
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