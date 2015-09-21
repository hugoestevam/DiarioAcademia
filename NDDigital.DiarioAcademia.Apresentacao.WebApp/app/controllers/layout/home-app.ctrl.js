(function () {

    'use strict';
    //using
    homeAppController.$inject = ['alunoService', 'turmaService', 'aulaService'];

    //namespace
    angular
        .module('controllers.module')
        .controller('homeAppController', homeAppController);

    //class
    function homeAppController(alunoService, turmaService, aulaService) {
        var vm = this;

        //script load
        activate();

        function activate() {
            alunoService.getAlunos().then(function (alunos) {
                vm.alunos = alunos.length;

                turmaService.getTurmas().then(function (turmas) {
                    vm.turmas = turmas.length;

                    aulaService.getAulas().then(function (aulas) {
                        vm.aulas = aulas.length;
                    });
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