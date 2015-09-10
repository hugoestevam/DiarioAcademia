(function (angular) {
    'use strict';
    //using
    alunoListCtrl.$inject = ["alunoService", "$state"];

    //namespace
    angular
        .module("controllers.module")
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
        vm.edit = function () {
            if (vm.alunoSelecionado)
                $state.go('aluno.details', { alunoId: vm.alunoSelecionado.id });
        }

        vm.remove = function () {
            if (!vm.alunoSelecionado)
                return;
            alunoService.delete(vm.alunoSelecionado).then(function () {
                vm.alunos.remove(vm.alunoSelecionado);
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