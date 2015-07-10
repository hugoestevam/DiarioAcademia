(function () {
    'use strict';

    //using
    chamadaService.$inject = ['$http', 'logger', 'BASEURL'];

    //namespace
    angular.module('services.module')
       .service('chamadaService', chamadaService);

    //class
    function chamadaService($http, logger, baseUrl) {
        var self = this;
        var serviceUrl = baseUrl + "api/chamada";

        //public methods
        self.realizarChamada = function (chamada) {
            logger.success("Salvo com sucesso", chamada);

            $http.post(serviceUrl, chamada);
        };

        //public methods
        self.getChamadass = function () {
            return $http.get(serviceUrl)
                 .then(logger.successCallback)
                 .catch(logger.errorCallback);
        };

        //public methods
        self.getChamadaByAula = function (id) {
            return $http.get(serviceUrl + '/' + id)
                .then(logger.successCallback)
                .catch(logger.errorCallback);
        };
    }
})();