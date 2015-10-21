(function () {
    'use strict';

    adapter.$inject = ["automapper"];

    angular
      .module('app.chamada')
      .factory('chamadaAdapter', adapter);


    function adapter(automapper) {

        var factory = this;

        init();
        function init() {
            automapper.createMap("aluno", "chamadaAlunoDto")
                     .forMember("alunoId", function () { return this.id })
                     .forMember("nome", function () { return this.nome })
                     .forMember("status", function () { return false; })
                     .forMember("turma", function () { return this.turma.id; })
                     .ignore("faltas")
                     .ignore("presencas")
                     .ignore("endereco");


            automapper.createMap("chamada", "chamadaDto")
                       .forMember("id", function () { return this.id })
                       .forMember("turmaId", function () { return this.turma.id })
                       .forMember("data", function () { return this.aula.dataAula; })
                       .forMember("aulaId", function () { return this.aula.id; })
                       .forMember("alunos", function () { return formatStatus(this.alunos); })
                       .ignore("turma")
                       .ignore("aula");

            function formatStatus(alunos) {
                for (var i = 0; i < alunos.length; i++) {
                    alunos[i].status = !alunos[i].status ? "F" : "C";
                }
                return alunos;
            }
        }

        //public methods
        factory.toChamadaDto = function (obj) {
            var result = {};
            automapper.map("chamada", "chamadaDto", obj, result);
            return result;
        };

        factory.toAlunoChamadaDto = function (obj) {
            var result = {};
            automapper.map("aluno", "chamadaAlunoDto", obj, result);
            return result;
        };

        return factory;
    }
})();