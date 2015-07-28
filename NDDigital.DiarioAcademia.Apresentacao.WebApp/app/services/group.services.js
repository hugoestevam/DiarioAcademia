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

		//public methods
		self.getGroups = function () {
			return promise;

			return $http.get(serviceUrl)
				 .then(logger.successCallback)
				 .catch(logger.errorCallback)
		};

		self.getGroupById = function (id) {

			return $http.get(serviceUrl + '/' + id)
				 .then(logger.successCallback)
				 .catch(logger.errorCallback)
		};

		self.save = function (group) {
			logger.success("Salvo com sucesso", group);
			// $http.post(serviceUrl, convertToDto(group));
		};

		self.delete = function (group) {
			logger.error("Excluido com sucesso", group, "Delete");
			//$http.delete(serviceUrl + "/" + group.id);
		};

		self.checkPermission = function (groups, state) {
			return true;
		};

		var promise = new Promise(function (acc) {
			var response = {
				data: [{ id: 1, name: "Aluno" },
					   { id: 2, name: "Admin" },
					   { id: 3, name: "RH" }],
				status: 200,
				statusText: 'Fetched data'
			};
			acc(response);
		});
	}
})();