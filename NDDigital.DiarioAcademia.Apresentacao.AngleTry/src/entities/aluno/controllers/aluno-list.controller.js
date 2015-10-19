(function (angular) {
    'use strict';
    //using
    alunoListCtrl.$inject = ["alunoService", "$state"];

    //namespace
    angular
        .module("app.aluno")
        .controller("alunoListCtrl", alunoListCtrl);

    //class
    function alunoListCtrl(alunoService, $state) {
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
        vm.edit = edit;
        vm.remove = remove;

        function edit(aluno) {
            if (aluno)
                $state.go('app.aluno.details', { alunoId: aluno.id });
        }

       function remove(aluno) {
            if (!aluno)
                return;
            alunoService.delete(aluno).then(function () {
                makeRequest();
            });
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