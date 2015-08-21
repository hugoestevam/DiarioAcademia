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
		vm.onchange = onchange;
		vm.changes = [];
		vm.hasChange = false;

		var originalUser;
		var originalGroups;


		activate();
		function activate() {
			userService.getUserById(params.userId).then(function (results) {
				vm.user = results;
				vm.user.groups = vm.user.groups ? vm.user.groups : [];
				originalUser = $.extend(true, {}, vm.user);
				vm.name = vm.user.firstName;
				vm.bodyModelEdit += vm.name;

				groupService.getGroups().then(function (results) {
				    vm.groups = results;
				    if (results)
				        originalGroups = results.slice();
				});
			});

			
		}

		//public methods
		function onchange(obj, check) {
			vm.hasChange = true;
			if (vm.changes.indexOfObject(obj) < 0)
				vm.changes.push(obj);
			obj.action = check;
		}


		function editUser() {
			//userService.edit(vm.user).then(function () { });
			$('body').removeClass('modal-open');
			$('.modal-backdrop').remove();
			saveChanges();
		}

		function saveChanges() {
			vm.hasChange = false;
			var include = [], exclude = [];
			for (var i = 0; i < vm.changes.length; i++) {
				if (vm.changes[i].action) {
					if (!vm.user.groups.containsObject(vm.changes[i]))
						include.push(vm.changes[i].id);
				}
				else
					exclude.push(vm.changes[i].id);
			}
			if (!vm.formUser.$pristine)
			    userService.edit(vm.user);
			else {
			    if (include > 0)
			        userService.addUserInGroup(vm.user, include);
			    if (exclude > 0)
			        userService.addUserInGroup(vm.user, exclude);
			}
		   
		}

		function clear() {
			vm.user = $.extend(true, {}, originalUser);
			vm.groups = originalGroups.slice();
			vm.hasChange = false;
		}
	}
})(window.angular);