(function (angular) {
    'use strict';
    //using
    aulaListCtrl.$inject = ["aulaService"];

    //namespace
    angular
        .module("controllers.module")
        .controller("aulaListCtrl", aulaListCtrl);

    //class
    function aulaListCtrl(aulaService, $state) {
        var vm = this;
        vm.title = "Lista de Aulas";
        vm.classe = "selecionado";

        vm.criterioDeBusca = "";

        //script load
        activate();

        function activate() {
            makeRequest();
        }

        //public methods
        vm.delete = function () {
            if (!vm.aulaSelecionada)
                return;
            aulaService.delete(vm.aulaSelecionada).then(function () {
                vm.aulas.remove(vm.aulaSelecionada);
            });
        }

        //private methods
        function makeRequest() {
            aulaService.getAulas().
                then(function (data) {
                    vm.aulas = data;
                });
        };
    }
}(window.angular));