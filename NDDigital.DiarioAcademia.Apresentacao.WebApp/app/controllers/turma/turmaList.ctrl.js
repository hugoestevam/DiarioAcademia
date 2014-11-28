(function () {

    'use strict';
    //using
    turmaListController.$inject = ['turmaService'];

    //namespace
    angular
        .module('controllers.module')
        .controller('turmaListController', turmaListController);

    //class
    function turmaListController(turmaService) {
        var self = this;

        //script load
        activate();
        function activate() {


            self.turmas = turmaService.getTurmas();


        }

        self.refresh = function () {
            location.reload();
        };
        self.delete = function(turma) {

            if (self.turmas.contains(turma))
                self.turmas.delete(turma);


        };
        self.numberLimit = 10;

        self.selectTurma = function(turma) {
            self.selectedTurma = turma;
        };
    }

})();