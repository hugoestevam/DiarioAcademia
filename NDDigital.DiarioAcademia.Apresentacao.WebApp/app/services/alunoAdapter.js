(function () {

    'use strict';
    //using
    adapter.$inject = ["automapper"];

    //namespace
    angular
        .module('services.module')
        .factory('alunoAdapter', adapter);

    //class
    function adapter(automapper) {
        var factory = {};

        init();

        function init() {
            automapper.createMap("aluno", "alunoDto")
                        .forMember("id", function () { return this.id })
                        .forMember("descricao", function () { return this.nome; })
                        .forMember("turmaId", function () { return this.turma.id; })
                        .forMember("cep", function () { return this.endereco.cep; })
                        .forMember("bairro", function () { return this.endereco.bairro; })
                        .forMember("localidade", function () { return this.endereco.localidade; })
                        .forMember("uf", function () { return this.endereco.uf; })
                        .ignore("endereco")
                        .ignore("turma")
                        .forAllMembers(function (property) { return this[property]; });

            automapper.createMap("alunoDto", "aluno")
               .forMember("id", function () { return this.id })
               .forMember("nome", function () { return this.descricao; })
               .forMember("turma", function () { return { id: this.turmaId }; })
               .forMember("endereco", function () {
                   return {
                       cep: this.cep,
                       bairro: this.bairro,
                       localidade: this.localidade,
                       uf: this.uf
                   };
               });
        }

        //public methods
        factory.makeTurmaDto = function (obj) {         
            return { ano: turma.ano };        
        };

        factory.convert = function (obj) {
            //return {
            //    turmaId: obj.turma.id,
            //    descricao: obj.nome,
            //    cep: obj.endereco.cep,
            //    bairro: obj.endereco.bairro,
            //    localidade: obj.endereco.localidade,
            //    uf: obj.endereco.uf
            //    };
            var result = {};

            automapper.map("aluno", "alunoDto", obj, result);

            return result;
        };

        factory.convertBack = function (obj) {
            //return {
            //    id: objDto.turmaId,
            //    nome: objDto.descricao.split(":"),
            //    endereco: { 
            //        cep: objDto.cep,
            //        bairro: objDto.bairro,
            //        localidade: objDto.localidade,
            //        uf: objDto.uf
            //    }
            //};

            var result = {};

            automapper.map("alunoDto", "aluno", obj, result);

            return result;
        };

        return factory;

    }

})();