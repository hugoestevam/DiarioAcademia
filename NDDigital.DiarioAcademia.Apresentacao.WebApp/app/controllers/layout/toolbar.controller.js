(function () {

    'use strict';
    //using
    toolbarController.$inject = [];

    //namespace
    angular
        .module('controllers.module')
        .controller('toolbarController', toolbarController);

    //class
    function toolbarController() {
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