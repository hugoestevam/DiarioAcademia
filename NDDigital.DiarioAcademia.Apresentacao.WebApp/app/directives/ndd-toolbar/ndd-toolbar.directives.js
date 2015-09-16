(function(angular){
	angular.module('directives.module')
		.directive('nddToolbar', nddToolbar);
	
	function nddToolbar(){
		return{
			restrict: 'E',
			link: link, 
			replace: false,
			transclude: false,
			scope:{
			    cbProperties: "=",
			    cbRemove: "=",
			    cbNew: "=",
				stateNew: "@",
				securityProperties: "@",
				securityRemove: "@"
			},
			templateUrl: '/app/directives/ndd-toolbar/ndd-toolbar.html'
		}
		
		function link(scope, element, attrs){
		}

		
	}
})(window.angular);