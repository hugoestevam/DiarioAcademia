(function (angular) {
	angular.module('controllers.module')
		.controller('managerGroupEditController', managerGroupEditController);

	managerGroupEditController.$inject = ['groupService', '$stateParams', 'permissionsService', 'logger'];

	function managerGroupEditController(groupService, params, permissionsService, log) {
		var vm = this;

		//public functions
		vm.isChecked = isChecked;
		vm.changeGroup = changeGroup;
		vm.save = save;

		activate();
		function activate() {
			groupService.getGroupById(params.groupId).then(function (results) {
				vm.group = results.data;
			});

			permissionsService.getPermissions().then(function (results) {
				vm.permissions = results.data;
			});
		}

		function save() {
			disable();
			groupService.save(vm.group).then(function (results) {
				enable();
			});
		}

	    //Control Components Functions

		function isChecked(index, permission) {
			var text = $('#textGroup' + index);
			var check = $('#chkGroup' + index);
			if (!vm.group || !vm.group.permissions) {
				return false;
			}
			var result = vm.group.permissions.contains(permission);
			if (result) {
				text.addClass('border-success');
				check.addClass('border-success');
			} else {
				text.removeClass('border-success');
				check.removeClass('border-success');
			}
			return result;
		}

		function changeGroup(index, permission, chkGroups) {
			var text = $('#textGroup' + index);
			var check = $('#chkGroup' + index);

			if (chkGroups) {
				text.addClass('border-success');
				check.addClass('border-success');
				vm.group.permissions.push(permission);
			} else {
				text.removeClass('border-success');
				check.removeClass('border-success');
				vm.group.permissions.remove(permission);
			}

			save();
		}

		function disable() {
			$('input').prop('disabled', true);
			$('.list-group a').css('pointer-events', ' none');
			$('button').prop('disabled', true);
		}

		function enable() {
			$('input[type="checkbox"').prop('disabled', false);
			$('.list-group a').css('pointer-events', ' all');
			$('button').prop('disabled', false);
		}
	}
})(window.angular);