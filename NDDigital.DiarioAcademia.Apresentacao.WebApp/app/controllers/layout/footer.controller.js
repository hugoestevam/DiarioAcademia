(function () {

    'use strict';
    //using
    footerController.$inject = [];

    //namespace
    angular
        .module('controllers.module')
        .controller('footerController', footerController);

    //class
    function footerController() {
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