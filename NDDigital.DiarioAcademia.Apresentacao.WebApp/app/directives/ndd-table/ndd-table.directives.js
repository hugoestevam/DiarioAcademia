(function (angular) {
	angular.module('directives.module')
		.directive('nddTable', nddToolbar);

	function nddToolbar() {
		// Usage:
		//  <ndd-table columns="['column1', 'column2']", attrs="['attribute1', 'attribute2']" data="[obj1, obj2]" cbClick="vm.onClick"></ndd-table>
		return {
			restrict: 'E',
			link: link,
			replace: false,
			transclude: false,
			scope: {
				columns: "=",
				attrs: "=",
				data: "=",
				cbClick: "=",
				dataFilter: "=ngModel",
				
			},
			templateUrl: '/app/directives/ndd-table/ndd-table.html'
		}

		function link(scope, element, attrs) {
			scope.isBool = function (value) {
				return typeof (value) == 'boolean';
			}
			scope.onClick = function (value) {
				scope.selectedEntity = value;
			};
		}

	}
})(window.angular);