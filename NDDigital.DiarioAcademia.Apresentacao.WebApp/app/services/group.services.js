(function () {
	'use strict';

	//using
	groupService.$inject = ['$http', 'logger', 'BASEURL', 'resource'];

	//namespace
	angular.module('services.module')
	   .service('groupService', groupService);

	//class
	function groupService($http, logger, baseUrl,res) {
		var self = this;
		var serviceUrl = baseUrl + "api/group";

		var groups = [{ id: 1, name: "Aluno", permissions: [{ id: 0, name: "aluno.list" }] },
					   { id: 2, name: "Admin", permissions: [{ id: 0, name: "aluno.list" }, { id: 1, name: "aluno.create" }] },
					   { id: 3, name: "RH", permissions: [{ id: 0, name: "aluno.list" }] }];

		var promise = new Promise(function (acc) {
			var response = {
				data: groups,
				status: 200,
				statusText: 'Fetched data'
			};
			acc(response);
		});

		//public methods
		self.getGroups = function () {
			return promise;

			return $http.get(serviceUrl)
				 .then(logger.successCallback)
				 .catch(logger.errorCallback)
		};

		self.getGroupById = function (id) {
			return new Promise(function (acc) {
				var index = groups.indexOfObject({ id: id });
				var group = index >= 0 ? groups[index] : undefined;
				var response = {
					data: group,
					status: 200,
					statusText: 'Fetched data'
				};
				acc(response);
			});

			return $http.get(serviceUrl + '/' + id)
				 .then(logger.successCallback)
				 .catch(logger.errorCallback)
		};

		self.getGroupByUsername = function (username) {
			return $http.get(serviceUrl + '?username=' + username)
				 .then(logger.successCallback)
				 .catch(logger.errorCallback)
		};

		self.save = function (group) {
			logger.success(res.saved_successful, group);

			if (group.id == undefined) {
				group.id = groups[groups.length - 1].id + 1;
				group.permissions = [];
			}

			return new Promise(function (acc) {
				acc(group)
			})
			// $http.post(serviceUrl, group);
		};

		self.delete = function (group) {
			logger.error(res.deleted_successful, group, "Delete");
			//$http.delete(serviceUrl + "/" + group.id);
		};

		self.checkPermission = function (username, state) {
			return $http.get(serviceUrl + "?username=" + username + "&state=" + state)
				.then(logger.successCallback)
				.catch(logger.errorCallback);
		};

		self.extractPermissions = function (groups) {
			var permissions = [];
			for (var i in groups) {
				var group = groups[i];
				for (var j in group.permissions) {
					var name = group.permissions[j].name;
					if (name)
						if (permissions.indexOf(name) < 0) permissions.push(name);
				}
			}
			return permissions;
		}
	}
})();