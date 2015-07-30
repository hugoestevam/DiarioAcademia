(function (angular) {
	'use strict';

	//using
	userService.$inject = ['$http', 'logger', 'BASEURL', 'resource'];

	//namespace
	angular.module('services.module')
	   .service('userService', userService);

	//class
	function userService($http, logger, baseUrl,res) {
		var self = this;

		var users = createItens();

		var serviceUrl = baseUrl + "api/user";


		//public methods
		self.getUsers = function () {
			return promise;

			return $http.get(serviceUrl)
				 .then(logger.successCallback)
				 .catch(logger.errorCallback)
				 .then(convertToObj);
		};

		self.getUserById = function (id) {
		    var promiseById = new Promise(function (acc) {
		        var index = users.indexOfObject({ id: id });
				var user = index >= 0 ? users[index] : undefined;
				var response = {
					data: user,
					status: 200,
					statusText: 'Fetched data'
				};
				acc(response);
			});

			return promiseById;

			return $http.get(serviceUrl + '/' + id)
				 .then(logger.successCallback);
		};

		self.delete = function (user) {
			logger.error(res.deleted_successful, user, "Delete");
			// $http.delete(serviceUrl + "/" + user.id);
		};

		self.edit = function (user) {
			logger.success("User " + user.nome + " editada", null, "Edição");
			// $http.put(serviceUrl + "/" + user.id, user);
		};

		var promise = new Promise(function (acc) {
			var response = {
				data: users,
				status: 200,
				statusText: 'Fetched data'
			};
			acc(response);
		});


		function createItens() {
			var itens = [];

			itens.push({
				"url": "http://localhost:50299/api/accounts/user/fedbf2b8-1c5c-4300-bac9-e08e2d7f630e",
				"id": "fedbf2b8-1c5c-4300-bac9-e08e2d7f630e",
				"userName": "anisanwesley",
				"fullName": "Wesley Lemos",
				"email": "anisan_wesley@live.com",
				"emailConfirmed": true,
				"level": 3,
				"joinDate": "2015-07-22T00:00:00",
				"groups": [
					{ id: 1, name: "Aluno" }
				]
			}, {
				"url": "http://localhost:50299/api/accounts/user/fedbf2b8-1c5c-4300-bac9-e08e2d7f630d",
				"id": "fedbf2b8-1c5c-4300-bac9-e08e2d7f630d",
				"userName": "gui",
				"fullName": "Guilherme Toniello",
				"email": "guitoniello@gmail.com",
				"emailConfirmed": false,
				"level": 3,
				"joinDate": "2015-05-22T00:00:00",
				"groups": [
					{ id: 1, name: "Aluno" },
					{ id: 2, name: "Admin" },
					{ id: 3, name: "RH" }
				]
			}, {
				"url": "http://localhost:50299/api/accounts/user/fedbf2b8-1c5c-4300-bac9-e08e2d7f630d",
				"id": "fedbf2b8-1c5c-4300-bac9-e08e2d7f630c",
				"userName": "ttsartor",
				"fullName": "Thiago Sartor",
				"email": "thiago.sartor@nddigital.com.br",
				"emailConfirmed": false,
				"level": 3,
				"joinDate": "2015-04-22T00:00:00",
				"groups": [
					{ id: 2, name: "Admin" }
				]
			});
			return itens;
		}

	}
})(window.angular);