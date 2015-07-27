(function () {
    'use strict';

    //using
    groupService.$inject = ['$http', 'logger', 'BASEURL'];

    //namespace
    angular.module('services.module')
       .service('groupService', groupService);

    //class
    function groupService($http, logger, baseUrl) {
        var self = this;
        var serviceUrl = baseUrl + "api/group";

        var roles = [
                { id: 1, name: "Admin" },
                { id: 2, name: "Writer", },
                {
                    id: 3,
                    name: "Reader",
                    permission: [
                      'aluno.list'
                    ]
                }
        ];

        //public methods
        self.getGroups = function () {

            return roles;

             return $http.get(serviceUrl)
                  .then(logger.successCallback)
                  .catch(logger.errorCallback)
                  .then(convertToObj);
        };

        self.getGroupById = function (id) {

            return {
                id: 2,
                name: "Reader",
                permission: [
                    'aluno.list'
                ]
            };


            return $http.get(serviceUrl + '/' + id)
                 .then(logger.successCallback)
                 .catch(logger.errorCallback)
                 .then(convertToObj);
        };        

        self.save = function (group) {
            logger.success("Salvo com sucesso", group);
           // $http.post(serviceUrl, convertToDto(group));
        };

        self.delete = function (group) {
            logger.error("Excluido com sucesso", group, "Delete");
            //$http.delete(serviceUrl + "/" + group.id);
        };

        self.checkPermission = function(groups,state) {
            return true;

        };

    }
})();