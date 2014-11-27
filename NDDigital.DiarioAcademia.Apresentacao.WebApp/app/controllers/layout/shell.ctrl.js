(function () {

    'use strict';
    //using
    shellController.$inject = ['$location'];

    //shellspace
    angular
        .module('controllers.module')
        .controller('shellController', shellController);

    //class
    function shellController($location ) {
        var self = this;

        //script load
        activate();
        function activate() {
        }
        
        //public methods
        self.logOut = function () {
            $location.path('/home');
        };

    }

    })();