
(function (angular) {

	angular
		.module('factories.module')
		.value('permissionGroups', [
				'aluno',
				'turma',
				'other',
				'manager',
				'aula',
				'chamada',
				'action',
				'action2',
				'action3'
		]);


})(window.angular);