(function (angular) {

    "use strict";
    //using

    turmaListCtrl.$inject = ["turmaService"];

    //namespace
    angular
        .module("controllers.module")
        .controller("turmaListCtrl", turmaListCtrl);

    //class
    function turmaListCtrl(turmaService) {
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
        vm.delete = function (turma) {
            turmaService.delete(turma).then(function () {
                vm.turmas.remove(turma);
            });
        };

        //private methods
        function makeRequest() {
            turmaService.getTurmas().
                then(function (data) {
                    vm.turmas = data;
                });
        };
    }
}(window.angular));