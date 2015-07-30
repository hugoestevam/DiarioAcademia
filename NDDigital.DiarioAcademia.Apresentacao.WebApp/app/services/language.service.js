(function () {
    'use strict';

    //using
    languageService.$inject = ['$http', 'BASEURL', 'resource'];

    //namespace
    angular.module('services.module')
       .service('languageService', languageService)
        .value('resource',{});

    //class
    function languageService($http, logger, baseUrl, resource) {
        var self = this;
        var serviceUrl = baseUrl + "api/language";

        //public methods
        self.setLanguage = function(language) {

            for (var p in resourcemock) resource[p] = resourcemock[p];

            return promise;
            $http.get(serviceUrl + '/' + cep)
                .then(logger.successCallback)
                .catch(logger.errorCallback);
        };



        var promise = new Promise(function (acc) {
            var response = {
                data: resourcemock,
                status: 200,
                statusText: 'Fetched data'
            };
            acc(response);
        });
        


        var resourcemock = {
            saved_successful: 'Excluido com sucesso',
            deleted_successful: 'Excluido com sucesso',
            unavailable_server: 'Servidor Indisponível',
            student_founded: function (id) { return "Aluno com id " + id + " encontrada"; },
            student_edited: function (name) { return "Aluno " + name + " editado"; },
            welcome: function (username) { return "Bem vindo " + username + "!"; },
        };

    }
})();