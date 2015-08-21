(function (angular) {
	angular.module('controllers.module')
		.controller('managerGroupEditController', managerGroupEditController);

	managerGroupEditController.$inject = ['groupService', 'permissionsService', 'permissions.factory','compareState',
		'$state', '$stateParams'];

	function managerGroupEditController(groupService, permissionsService, permissionsFactory,
		compareState, $state, params) {

		var vm = this;

		//public functions
		vm.comparePermissions = compareState;
		vm.permissions = [];
		vm.modal = modal;
		vm.saveChanges = saveChanges;
		vm.onchange = onchange;
		vm.hasChange = false;
		vm.changes = [];


		activate();
		function activate() {
			groupService.getGroupById(params.groupId).then(function (results) {
				if (results == undefined)
					$state.go('manager.group');
				vm.group = results;

				permissionsService.getPermissions().then(function (results) {
					var permissionsDb = results;
					for (var i = 0; i < permissionsDb.length; i++) {
						var permission = permissionsFactory.getPermissionById(permissionsDb[i].permissionId);
						vm.permissions.push(permission);
					}
				});

			});
		}

		function onchange(obj, check) {
			vm.hasChange = true;
			if (compareState(vm.changes, obj))
				vm.changes.push(obj);
			obj.action = check;
		}

		function saveChanges() {
			vm.hasChange = false;
			var add = [], exclude = [];
			for (var i = 0; i < vm.changes.length; i++) {
				if (vm.changes[i].action)
					add.push(vm.changes[i].permissionId);
				else
					exclude.push(vm.changes[i].permissionId);
			}

			if (add.length > 0)
				save(add);
			if (exclude.length > 0)
				remove(exclude);
		}

		function save(permission) {
			groupService.addPermission(vm.group, permission).then(function (results) { });
		}

		function remove(permission) {
			groupService.removePermission(vm.group, permission).then(function (results) { });
		}

		function modal() {
			vm.titleModalEdit = 'Edição';
			vm.bodyModalEdit = 'Editar ' + vm.group.name + ' ?';
		}

		function edit() {
			groupService.edit(vm.group).then(function (results) {
				vm.group = results;
			});
		}
	}
})(window.angular);