(function () {
    'use strict';

    //using
    alunoService.$inject = ['$http', 'logger', 'BASEURL', "alunoAdapter"];

    //namespace
    angular.module('services.module')
       .service('alunoService', alunoService);

    //class
    function alunoService($http, logger, baseUrl, adapter) {
        var self = this;
        var serviceUrl = baseUrl + "api/aluno";

        //public methods
        self.getAlunos = function () {
            return $http.get(serviceUrl)
                 .then(logger.successCallback)
                 .catch(logger.errorCallback)
                 .then(convertToObj);
        };

        self.getAlunoById = function (id) {
            return $http.get(serviceUrl + '/' + id)
                 .then(logger.successCallback)
                 .catch(logger.errorCallback)
                 .then(convertToObj);
        };        

        self.save = function (aluno) {
            logger.success("Salvo com sucesso", aluno);
            $http.post(serviceUrl, convertToDto(aluno));
        };

        self.delete = function (aluno) {
            logger.error("Excluido com sucesso", aluno, "Delete");
            $http.delete(serviceUrl + "/" + aluno.id);
        };

        self.getTurmaById = function (id) {
            logger.success("Aluno com id " + id + " encontrada", null, "GetById");
            return $http.get(serviceUrl + "/" + id)
                .then(function (response) {
                    return response.data;
                });
        };

        self.edit = function (aluno) {
            logger.success("Aluno " + aluno.nome + " editada", null, "Edição");
            $http.put(serviceUrl + "/" + aluno.id, aluno);
        };

        function convertToObj(data) {
            if ($.isArray(data)) {
               return $.map(data, function (item) {
                    return adapter.convertBack(item);
                });
            } else {
                return adapter.convertBack(data);
            }
        };

        function convertToDto(data) {
            return adapter.convert(data);
        };
    }
})();