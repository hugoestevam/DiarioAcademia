(function () {
    'use strict';

    //using
    alunoService.$inject = ['$http', 'logger', 'BASEURL', "alunoAdapter",'resource'];

    //namespace
    angular.module('services.module')
       .service('alunoService', alunoService);

    //class
    function alunoService($http, logger, baseUrl, adapter,res) {
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
            logger.success(res.saved_successful, aluno);
            return $http.post(serviceUrl, convertToDto(aluno));
        };

        self.delete = function (aluno) {
            logger.error(res.deleted_successful, aluno, "Delete");
            return $http.delete(serviceUrl + "/" + aluno.id);
        };

        self.getTurmaById = function (id) {
            logger.success(res.student_founded(id), null, "GetById");
            return $http.get(serviceUrl + "/" + id)
                .then(function (response) {
                    return response.data;
                });
        };

        self.edit = function (aluno) {
            logger.success(res.student_edited(aluno.descricao.split(':')[0]) + " editado", null, "Edição");
            return $http.put(serviceUrl + "/" + aluno.id, aluno);
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