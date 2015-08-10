(function (angular) {
	angular
		.module('controllers.module')
		.controller('managerUserEditController', managerUserEditController);

	managerUserEditController.$inject = ['userService', 'groupService', "$stateParams", '$scope', '$state'];

	function managerUserEditController(userService, groupService, params, $scope, $state) {
		var vm = this;

		vm.user = {};
		vm.groups = [];
		vm.editUser = editUser;

		//public functions
		vm.clear = clear;

		vm.titleModelEdit = 'Confirmar Alteração';
		vm.bodyModelEdit = 'Deseja realmente editar o usuário ';

		var originalUser;
		var originalGroups;

		activate();
		function activate() {
			userService.getUserById(params.userId).then(function (results) {
				vm.user = results;
				originalUser = $.extend(true, {}, vm.user);
				vm.name = vm.user.fullName;
				vm.bodyModelEdit += vm.name;
			});

			groupService.getGroups().then(function (results) {
				vm.groups = results;
				if (results)
					originalGroups = results.slice();
			});
		}

		function editUser() {
			userService.edit(vm.user).then(function () {
				$('body').removeClass('modal-open');
				$('.modal-backdrop').remove();
				$state.go('manager.user');
			});
		}

		function clear() {
			vm.user = $.extend(true, {}, originalUser);
			vm.groups = originalGroups.slice();
		}
	}
})(window.angular);