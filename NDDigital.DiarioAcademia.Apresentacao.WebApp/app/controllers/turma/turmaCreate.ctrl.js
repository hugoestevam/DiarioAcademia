(function () {

    'use strict';
    //using
    turmaCreateController.$inject = ['turmaService','$state'];

    //namespace
    angular
        .module('controllers.module')
        .controller('turmaCreateController', turmaCreateController);

    //class
    function turmaCreateController(turmaService,state) {
        var self = this;

        self.turma = new DiarioAcademia.Turma(new Date().getYear(),"");

        //script load
        activate();
        function activate() {

        }

        self.create = function() {

            turmaService.create(self.turma);
            state.go('turma.list');


        };


    }

})();