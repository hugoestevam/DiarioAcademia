(function () {
	'use strict';

	//using
	permissionsService.$inject = ['$http', 'logger', 'BASEURL'];

	//namespace
	angular.module('services.module')
	   .service('permissionsService', permissionsService);

	//class
	function permissionsService($http, logger, baseUrl) {
		var self = this;
		var serviceUrl = baseUrl + "api/permissions";

		var permissions = [
			{ id: 0, name: "aluno.list" },
			{ id: 1, name: "aluno.create" },
			{ id: 2, name: "manager.user" }];

		//public methods
		self.getPermissions = function () {
			return promise;

			return $http.get(serviceUrl)
				 .then(logger.successCallback)
				 .catch(logger.errorCallback)
		};

		self.getPermissionById = function (id) {
			return new Promise(function (acc) {
				var index = permissions.indexOfObject({ id: id });
				var permission = index >= 0 ? permissions[index] : undefined;
				var response = {
					data: permission,
					status: 200,
					statusText: 'Fetched data'
				};
				acc(response);
			});

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

		var promise = new Promise(function (acc) {
			var response = {
				data: permissions,
				status: 200,
				statusText: 'Fetched data'
			};
			acc(response);
		});
	}
})();