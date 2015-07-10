(function(angular) {
    'use strict';

    authInterceptorService.$inject = ['$q', '$location', 'localStorageService'];
    angular
        .module('services.module')
        .factory('authInterceptorService', authInterceptorService);
    
    function authInterceptorService($q, $location, localStorageService) {
        var authInterceptorFactory = {};
        
        var request = function (config) {

            config.headers = config.headers || {};

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.token;
            }

            return config;
        };

        var responseError = function (rejection) {
            if (rejection.status === 401) {
                $location.path('/login');
            }
            return $q.reject(rejection);
        };

        authInterceptorFactory.request = request;
        authInterceptorFactory.responseError = responseError;

        return authInterceptorFactory;
    }

})(window.angular);