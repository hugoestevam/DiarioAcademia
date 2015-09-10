(function (angular) {

    "use strict";
    //using

    turmaListCtrl.$inject = ["turmaService", "$state"];

    //namespace
    angular
        .module("controllers.module")
        .controller("turmaListCtrl", turmaListCtrl);

    //class
    function turmaListCtrl(turmaService, $state) {
        var vm = this;
        vm.title = "Lista das Turmas";
        vm.classe = "selecionado";

        vm.criterioDeBusca = "";

        //script load
        activate();

        function activate() {
            makeRequest();
        }

        //public methods 
        vm.edit = function () {
            if (vm.turmaSelecionada)
                $state.go('turma.details', { turmaId: vm.turmaSelecionada.id });
        }

        vm.remove = function () {
            if (!vm.turmaSelecionada)
                return;
            turmaService.delete(vm.turmaSelecionada).then(function () {
                vm.turmas.remove(vm.turmaSelecionada);
                vm.turmaSelecionada = {};
            });
        }

        //private methods
        function makeRequest() {
            turmaService.getTurmas().
                then(function (data) {
                    vm.turmas = data;
                });
        };
    }
}(window.angular));