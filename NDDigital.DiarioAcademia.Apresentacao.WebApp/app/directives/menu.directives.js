(function (angular) {

	'use strict';
	//using
	menuDirective.$inject = [];

	//namespace
	angular.module("diarioAcademia").directive("menu", menuDirective);

	//class
	function menuDirective() {

		// Usage:
		//  <div directive-name-1></div>
		return {
			restrict: 'E',
			link: link,
			templateUrl: '/app/templates/directives/menu.html',
			scope: {
				source: '='
			},
			replace: true
		};

		function link(scope, element, attrs) {

			$('#menu').multilevelpushmenu({
				menu: scope.source,
				containersToPush: [$('#pushobj')],
				preventItemClick: false,
				// Just for fun also changing the look of the menu
				wrapperClass: 'multilevelpushmenu_wrapper',
				menuInactiveClass: 'multilevelpushmenu_inactive'
			});			
		}
	}

}(window.angular));