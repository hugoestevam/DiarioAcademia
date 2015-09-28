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
        var vm = this;

        vm.slides = ['/app/images/slides/slide_one.jpg',
                     '/app/images/slides/slide_two.jpg',
                     '/app/images/slides/slide_three.jpg'];

        //script load
        activate();
        function activate() {
            $(document).ready(function () {
                $('.carousel').carousel({
                    pause: "false"
                });
            });
           
        }

        //public methods
        vm.publicMethod = function () {
        };

        //private methods
        function privateMethod() {
        };
    }

})();