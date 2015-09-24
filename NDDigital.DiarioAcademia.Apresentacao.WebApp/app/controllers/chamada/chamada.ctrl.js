(function (angular) {

    'use strict';
    //using
    chamadaCtrl.$inject = ["chamadaService", "aulaService", "turmaService"];

    //namespace
    angular.module("controllers.module").controller("chamadaCtrl", chamadaCtrl);

    //class
    function chamadaCtrl(chamadaService, aulaService, turmaService, $scope) {
        var vm = this;

        vm.title = "Realizar chamada";

        vm.alunos = [];
        vm.turmas = [];
        vm.aulas = [];
        vm.turmaSelected = false;
        vm.aulaSelected = false;


        activate();
        function activate() {
            turmaService.getTurmas().then(function (data) {
                vm.turmas = data;

                aulaService.getAulas().then(function (data) {
                    vm.allAulas = data;
                });
            });
        }

        //public methods
        vm.save = function () {
            vm.chamada.alunos = vm.alunos;
            chamadaService.realizarChamada(vm.chamada);
            clearFields();
        };

        vm.populateAulas = function (turma) {
            if (turma) {
                vm.getAulaByTurma(turma);
                chamadaService.getAlunosChamadaByTurma(turma.id).then(function (results) {
                    vm.talunos = results;
                    vm.aulaSelected = false;
                });
                vm.turmaSelected = true;
                vm.aulaSelected = false;
            }
        }

        vm.getChamada = function () {
            vm.alunos = [];
            if (vm.chamada.aula) {
                chamadaService.getChamadaByAula(vm.chamada.aula.id).then(function (data) {
                    vm.chamadaDto = data;
                    checkStatus(vm.chamadaDto.alunos);
                    vm.alunos = vm.talunos;
                });
            }
            vm.aulaSelected = true;
        }


        vm.getAulaByTurma = function (turma) {
            vm.aulas = [];
            for (var i = 0; i < vm.allAulas.length; i++) {
                if (turma) {
                    if (vm.allAulas[i].turmaId == turma.id) {
                        vm.aulas.push(vm.allAulas[i]);
                    }
                }
            }
        }

        //private methods
        function checkStatus(alunos) {
            var index;
            for (var j = 0; j < vm.talunos.length; j++) {
                index = containsAluno(alunos, vm.talunos[j]);
                vm.talunos[j].status = index >= 0 ? alunos[index].status != "F" : false;
            }
        }

        function containsAluno(alunos, aluno) {
            if (!alunos || alunos.length == 0)
                return -1;
            for (var i = 0; i < alunos.length; i++) {
                if (alunos[i].alunoId == aluno.alunoId)
                    return i;
            }
            return -1;
        }

        function clearFields() {
            vm.chamada = {};
            vm.alunos = [];
            vm.aulas = [];
            vm.turmaSelected = false;
            vm.aulaSelected = false;
        }
    }
}(window.angular));
