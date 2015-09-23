(function (angular) {

    'use strict';
    //using
    chamadaCtrl.$inject = ["chamadaService", "alunoService", "aulaService", "turmaService"];

    //namespace
    angular.module("controllers.module").controller("chamadaCtrl", chamadaCtrl);

    //class
    function chamadaCtrl(chamadaService, alunoService, aulaService, turmaService) {
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
            vm.chamada = convertToChamadaDto(vm.chamada);
            chamadaService.realizarChamada(vm.chamada);
            clearFields();
        };

        vm.populateAulas = function (turma) {
            if (turma) {
                vm.getAulaByTurma(turma);
                alunoService.getAlunoByTurmaId(turma.id).then(function (results) {
                    vm.talunos = convertToDto(results);
                });
                vm.turmaSelected = true;
            }
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


        //private methods

        function checkStatus(alunos) {
            for (var i = 0; i < vm.talunos.length; i++) {
                if (alunos.length == 0) {
                    vm.talunos[i].status = false;
                    continue;
                }  
                for (var j = 0; j < alunos.length; j++) {
                    if (vm.talunos[i].alunoId == alunos[j].alunoId)
                        vm.talunos[i].status = alunos[j] ? alunos[j].status != "F" : false;
                }
            }
        }

        function convertToDto(alunos) {
            var alunosDTO = [];
            for (var i = 0; i < alunos.length; i++) {
                alunosDTO[i] = {
                    alunoId: alunos[i].id,
                    nome: alunos[i].nome,
                    status: false,
                    turma: alunos[i].turma.id
                };
            }
            return alunosDTO;
        }

        function convertToChamadaDto(chamada) {
            var chamadaDto = {
                id: chamada.id,
                turmaId: chamada.turma.id,
                data: chamada.aula.data,
                aulaId: chamada.aula.id,
                alunos: vm.alunos
            };
            for (var i = 0; i < vm.alunos.length; i++) {
                chamadaDto.alunos[i].status = !vm.alunos[i].status ? "F" : "C";
            }
            return chamadaDto;
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
