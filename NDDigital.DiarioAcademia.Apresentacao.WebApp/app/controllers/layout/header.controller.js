(function () {

    'use strict';
    //using
    headerController.$inject = [];

    //namespace
    angular
        .module('controllers.module')
        .controller('headerController', headerController);

    //class
    function headerController() {
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