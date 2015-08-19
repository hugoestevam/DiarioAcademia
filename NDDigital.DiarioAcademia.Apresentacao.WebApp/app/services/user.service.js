(function (angular) {
	'use strict';

	//using
	userService.$inject = ['$http', 'logger', 'BASEURL', 'resource'];

	//namespace
	angular.module('services.module')
	   .service('userService', userService);

	//class
	function userService($http, logger, baseUrl, res) {
		var self = this;

		var serviceUrl = baseUrl + "api/accounts/user/";

		//public methods
		self.getUsers = function () {
			return $http.get(serviceUrl)
				 .then(logger.successCallback)
				 .catch(logger.errorCallback);
		};

		self.getUserById = function (id) {
			return $http.get(serviceUrl + id)
				 .then(logger.successCallback);
		};

		self.getUserByUsername = function (username) {
			return $http.get(serviceUrl + "username/"+ username)
				 .then(logger.successCallback);
		}

		self.delete = function (user) {
			logger.danger(res.deleted_successful, user, "Delete");
			return $http.delete(serviceUrl + "/" + user.id);
		};

		self.edit = function (user) {
			logger.success("User " + user.fullName + " editado", null, "Edição");
			return $http.put(serviceUrl + user.id, user);
		};
	}
})(window.angular);