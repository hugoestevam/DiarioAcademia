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
		vm.isChecked = isChecked;
		vm.changeGroup = changeGroup;
		vm.clear = clear;

		vm.titleModelEdit = 'Confirmar Alteração';
		vm.bodyModelEdit = 'Deseja realmente editar o usuário ';

		var originalUser;
		var originalGroups;
		var result;

		activate();
		function activate() {
			userService.getUserById(params.userId).then(function (results) {
				vm.user = results.data;
				originalUser = $.extend(true, {}, vm.user);;
				vm.name = vm.user.fullName;
				vm.bodyModelEdit += vm.name;
			});

			groupService.getGroups().then(function (results) {
			    vm.groups = results.data;
			    if (results.data)
			        originalGroups = results.data.slice();
		    });
		}

		function editUser() {
			userService.edit(vm.user).then(function () {
				$('body').removeClass('modal-open');
				$('.modal-backdrop').remove();
				$state.go('manager.user');
			});
		}

		//Control Components Functions

		function isChecked(index, group) {
			var text = $('#textGroup' + index);
			var check = $('#chkGroup' + index);

			if (!vm.user.groups) {
				return false;
			}
			result = vm.user.groups.contains(group);
			if (result) {
				text.addClass('border-success');
				check.addClass('border-success');
			} else {
				text.removeClass('border-success');
				check.removeClass('border-success');
			}
			return result;
		}

		function changeGroup(index, group, chkGroups) {
			var text = $('#textGroup' + index);
			var check = $('#chkGroup' + index);

			if (chkGroups) {
				text.addClass('border-success');
				check.addClass('border-success');
				vm.user.groups.push(group);
			} else {
				text.removeClass('border-success');
				check.removeClass('border-success');
				vm.user.groups.remove(group);
			}
		}

		function clear() {
			vm.user = $.extend(true, {}, originalUser);
			vm.groups = originalGroups.slice();
		}

	}

})(window.angular);