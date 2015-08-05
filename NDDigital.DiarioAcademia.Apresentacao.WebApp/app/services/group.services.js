(function () {
	'use strict';

	//using
	groupService.$inject = ['$http', 'logger', 'BASEURL', 'resource', '$state'];

	//namespace
	angular.module('services.module')
	   .service('groupService', groupService);

	//class
	function groupService($http, logger, baseUrl, res, $state) {
		var self = this;
		var serviceUrl = baseUrl + "api/group";

		//temporario
		var permission = $state.get();
		var groups = [{ id: 1, name: "Aluno", permissions: [permission[2]] },
					   { id: 2, name: "Admin", permissions: [permission[2], permission[3]] },
					   { id: 3, name: "RH", permissions: [permission[2]] }];


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
		    return promise.then(function (results) {
		        return results.data
		    });

			return $http.get(serviceUrl)
				 .then(logger.successCallback)
				 .catch(logger.errorCallback)
		};

		self.getGroupById = function (id) {
			var promiseId = new Promise(function (acc) {
				var index = groups.indexOfObject({ id: id });
				var group = index >= 0 ? groups[index] : undefined;
				var response = {
					data: group,
					status: 200,
					statusText: 'Fetched data'
				};
				acc(response);
			});
			return promiseId.then(function (results) {
			    return results.data;
			})

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


		self.edit = function (group) {
			//   $http.put(serviceUrl + "/" +  group.id, group);
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