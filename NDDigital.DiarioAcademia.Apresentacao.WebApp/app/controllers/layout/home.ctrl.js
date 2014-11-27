(function () {

    'use strict';
    //using
    homeController.$inject = [];

    //namespace
    angular
        .module('controllers.module')
        .controller('homeController', homeController);

    //class
    function homeController() {
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