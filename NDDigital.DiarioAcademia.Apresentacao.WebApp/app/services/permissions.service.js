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
			logger.danger(res.deleted_successful, permission, "Delete");
			return $http.delete(serviceUrl + "/" + permission.permissionId)
		};
	}
})();