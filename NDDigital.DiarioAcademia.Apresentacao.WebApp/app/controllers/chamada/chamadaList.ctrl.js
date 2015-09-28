(function (angular) {
    'use strict';
    //using
    chamadaListCtrl.$inject = ["chamadaService"];

    //namespace
    angular
        .module("controllers.module")
        .controller("chamadaListCtrl", chamadaListCtrl);

    //class
    function chamadaListCtrl(chamadaService) {
        var vm = this;
        vm.title = "Listas de Chamadas Realizadas";
        vm.classe = "selecionado";

        vm.criterioDeBusca = "";

        //script load
        activate();

        function activate() {
            makeRequest();
        }

        //public methods
        vm.delete = function (chamada) {
            chamadaService.delete(chamada);
            makeRequest();
        }

        //private methods
        function makeRequest() {
            chamadaService.getChamadas().
                then(function (data) {
                    vm.chamadas = data;
                });
        };
    }
}(window.angular));