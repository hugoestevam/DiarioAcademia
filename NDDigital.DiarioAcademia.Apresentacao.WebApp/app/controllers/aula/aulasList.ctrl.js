(function (angular) {
    'use strict';
    //using
    aulaListCtrl.$inject = ["aulaService"];

    //namespace
    angular
        .module("controllers.module")
        .controller("aulaListCtrl", aulaListCtrl);

    //class
    function aulaListCtrl(aulaService) {
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
        vm.delete = function (aula) {
            aulaService.delete(aula).then(function () {
                vm.aulas.remove(aula);
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