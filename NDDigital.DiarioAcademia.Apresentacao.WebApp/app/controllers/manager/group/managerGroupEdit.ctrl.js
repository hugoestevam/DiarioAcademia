(function (angular) {
	angular.module('controllers.module')
		.controller('managerGroupEditController', managerGroupEditController);

	managerGroupEditController.$inject = ['groupService', 'permissionsService', 'permissions.factory', 'compareState',
		'$state', '$stateParams'];

	function managerGroupEditController(groupService, permissionsService, permissionsFactory,
		compareState, $state, params) {

		var vm = this;

		//public functions
		vm.save = save;
		vm.comparePermissions = compareState;
		vm.permissions = [];

		activate();
		function activate() {
			groupService.getGroupById(params.groupId).then(function (results) {
				if (results == undefined)
					$state.go('manager.group');
				vm.group = results;
			});

			permissionsService.getPermissions().then(function (results) {
			    var permissions = results.data;
			    for (var i = 0; i < permissions.length; i++) {
			        var permission = permissionsFactory.getPermissionById(permissions[i].permissionId);
			        vm.permissions.push(permission);
			    }
			});
		}

		function save() {
			groupService.save(vm.group);
		}
	}
})(window.angular);