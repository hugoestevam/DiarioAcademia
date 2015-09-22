(function () {

    'use strict';
    //using
    homeAppController.$inject = ['alunoService', 'turmaService', 'aulaService', 'authService'];

    //namespace
    angular
        .module('controllers.module')
        .controller('homeAppController', homeAppController);

    //class
    function homeAppController(alunoService, turmaService, aulaService, authService) {
        var vm = this;

        //script load
        activate();

        function activate() {
            getAlunos();
        }

        //private methods
        function getAlunos() {
            if (!authService.authorization.isAuthorized('aluno.list')) {
                return getTurmas();
            }
            alunoService.getAlunos().then(function (alunos) {
                vm.alunos = alunos.length;
                getTurmas();
            });
        };

        function getTurmas() {
            if (!authService.authorization.isAuthorized('turmas.list')) {
                return getAulas();
            }
            turmaService.getTurmas().then(function (turmas) {
                vm.turmas = turmas.length;
                getAulas();
            });
        };

        function getAulas() {
            if (!authService.authorization.isAuthorized('aulas.list'))
                return
            aulaService.getAulas().then(function (aulas) {
                vm.aulas = aulas.length;
            });
        };
    }

})();