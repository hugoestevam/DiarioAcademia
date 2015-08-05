(function () {
	'use strict';

	//using

	permissionsService.$inject = ['$http', 'logger', 'BASEURL', '$state', 'resource'];


	//namespace
	angular.module('services.module')
	   .service('permissionsService', permissionsService);

	//class
	function permissionsService($http, logger, baseUrl, $state, res) {
		var self = this;
		var serviceUrl = baseUrl + "api/permissions";

		var permissions = [{ name: "aluno.list", data: { displayName: 'Lista de Aluno', $$permissionId: '0x01' } },
						   { name: "aluno.create", data: { displayName: 'Criação de Aluno', $$permissionId: '0x03' } },
						   { name: "aluno.details", data: { displayName: 'Detalhes do Aluno', $$permissionId: '0x02' } },
						   { name: "manager.user", data: { displayName: 'Usuário', $$permissionId: '0x09' } }];

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
			logger.success(res.saved_successful, group);
		    // $http.post(serviceUrl, convertToDto(group));
			return new Promise(function (acc) { acc() });;
		};
		 


		self.delete = function (group) {
			logger.error(res.deleted_successful, group, "Delete");
		    //$http.delete(serviceUrl + "/" + group.id);
			return new Promise(function (acc) { acc() });;
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