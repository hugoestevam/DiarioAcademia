
(function (angular) {

	angular
		.module('factories.module')
		.value('permissionGroups', [
				'aluno',
				'turma',
				'manager',
				'aula',
				'chamada',
				'action',
				'action2',
				'action3'
		]);


})(window.angular);