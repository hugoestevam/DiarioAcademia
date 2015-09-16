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

        vm.save = function () {
            vm.chamada = convertToChamadaDto(vm.chamada);
            convertStatusPresencas(vm.chamada);
            chamadaService.
                realizarChamada(vm.chamada);
            clearFields();
        };


        function clearFields() {
            vm.chamada = {};
            vm.alunos = [];
            vm.turmaSelected = false;
            vm.aulaSelected = false;
        }

        function convertStatusPresencas(chamada) {
            for (var i = 0; i < chamada.alunos.length; i++) {
                vm.chamada.alunos[i].status =
                    chamada.alunos[i].status == false ? "F" : "C";
            }
        }

        vm.populateAulas = function (turma) {
            if (turma) {
                vm.getAulaByTurma(turma);
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
                chamadaService.getChamadaByAula(vm.chamada.aula.id)
                    .then(function (data) {
                        vm.chamadaDto = data;
                        vm.allAlunos = vm.chamadaDto.alunos;
                        convertStatus();
                        vm.alunos = vm.allAlunos;
                    });
            }
            vm.aulaSelected = true;
        }

        function convertStatus() {
            for (var i = 0; i < vm.allAlunos.length; i++) {
                vm.allAlunos[i].status = vm.allAlunos[i].status == "F" ? false : true;
            }
        }

        function convertAlunosList() {
            for (var i = 0; i < vm.allAlunos.length; i++) {
                vm.allAlunos[i] = convertDto(vm.allAlunos[i]);
            }
        }

        function convertDto(aluno) {
            return {
                alunoId: aluno.id,
                nome: aluno.descricao.split(':')[0],
                status: false,
                turma: aluno.turmaId
            };
        }

        function convertToChamadaDto(chamada) {
            return {
                id: chamada.id,
                turmaId: chamada.turma.id,
                data: chamada.aula.data,
                aulaId: chamada.aula.id,
                alunos: vm.alunos
            };
        }

        function convertDtoTo(chamada) {
            return {
                id: chamada.id,
                turma: turmaService.getTurmaById(chamada.turmaId),
                data: chamada.data,
                aula: aulaService.getAulaById(chamada.aulaId),
                alunos: chamada.alunos
            };
        }
    }
}(window.angular));
