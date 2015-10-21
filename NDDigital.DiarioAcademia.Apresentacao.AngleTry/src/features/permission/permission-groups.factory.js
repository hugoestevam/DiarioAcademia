(function (angular) {

	angular
		.module('app.permission')
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