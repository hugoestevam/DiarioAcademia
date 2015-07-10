(function (angular) {
    'use strict';
    //using
    alunoListCtrl.$inject = ["alunoService"];

    //namespace
    angular
        .module("controllers.module")
        .controller("alunoListCtrl", alunoListCtrl);

    //class
    function alunoListCtrl(alunoService) {
        var vm = this;
        vm.title = "Lista de Alunos";
        vm.classe = "selecionado";

        vm.criterioDeBusca = "";

        //script load
        activate();

        function activate() {
            makeRequest();
        }

        //public methods
        vm.delete = function (aluno) {
            alunoService.delete(aluno);
            makeRequest();
        }

        //private methods
        function makeRequest() {
            alunoService.getAlunos().
                then(function (data) {
                    vm.alunos = data;
                });
        };
    }
}(window.angular));