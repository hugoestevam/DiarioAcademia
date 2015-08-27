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
		var serviceUrl = baseUrl + "api/permission";

		//public methods
		self.getPermissions = function () {
			return $http.get(serviceUrl)
				 .then(logger.successCallback)
				 .catch(logger.errorCallback)
		};

		self.getPermissionById = function (id) {
			return $http.get(serviceUrl + '/' + id)
				 .then(logger.successCallback)
				 .catch(logger.errorCallback)
		};

		self.save = function (permission) {
			logger.success(res.saved_successful, permission);
			return $http.post(serviceUrl, permission);
		};

		self.delete = function (permission) {
			permission = getPermissionsId(permission);
			logger.danger(res.deleted_successful, permission, "Delete");
			return $http({
			    url: serviceUrl,
			    method: 'DELETE',
			    data:  permission,
			    headers: { "Content-Type": "application/json;charset=utf-8" }
			})
				.then(logger.successCallback)
				.catch(logger.errorCallback);
		};

		function getPermissionsId(array) {
			var permissionsIds = [];
			for (var i = 0; i < array.length; i++) {
				permissionsIds.push(array[i].permissionId);
			}
			return permissionsIds;
		}
	}
})();