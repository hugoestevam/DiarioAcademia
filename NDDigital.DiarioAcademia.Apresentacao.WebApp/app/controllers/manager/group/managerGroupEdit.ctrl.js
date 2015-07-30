(function (angular) {
	angular.module('controllers.module')
		.controller('managerGroupEditController', managerGroupEditController);

	managerGroupEditController.$inject = ['groupService', 'permissionsService', 'compareState',
		'$state', '$stateParams'];

	function managerGroupEditController(groupService, permissionsService,
		compareState, $state, params) {

		var vm = this;

		//public functions
		vm.save = save;
		vm.comparePermissions = compareState;

		activate();
		function activate() {
			groupService.getGroupById(params.groupId).then(function (results) {
				if (results.data == undefined)
					$state.go('manager.group');
				vm.group = results.data;
			});

			permissionsService.getPermissions().then(function (results) {
				vm.permissions = results.data;
			});
		}

		function save() {
			groupService.save(vm.group);
		}
	}
})(window.angular);