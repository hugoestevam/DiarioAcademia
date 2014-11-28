(function () {

    'use strict';

    //using
    turmaService.$inject = ['$http', 'logger', 'BASEURL'];

    //namespace
    angular.module('services.module')
       .service('turmaService', turmaService);

    //class
    function turmaService($http, logger, baseUrl) {
        var self = this;
        var serviceUrl = baseUrl + "api/turma";

        var turmas = [

               new DiarioAcademia.Turma(2012, 'Academia do Rech'),
               new DiarioAcademia.Turma(2014, 'new Geek(2014)')

        ];


        self.getTurmas = function () {
            return turmas;
        };
        self.create = function(turma) {
            turmas.unshift(turma);
            logger.success('Turma para '+turma.ano+" adicionada.");
        };

    }


})();