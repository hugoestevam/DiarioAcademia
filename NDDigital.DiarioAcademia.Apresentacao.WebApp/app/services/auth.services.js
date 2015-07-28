(function (angular) {

    'use strict';

    authService.$inject = ['$http', '$q', 'localStorageService', 'logger', 'BASEURL', 'groupService'];

    angular.module('services.module')
        .service('authService', authService);

    function authService($http, $q, localStorageService, logger, serviceBase, groupService) {
        var self = this;

        var redirectState = "login";

        var authentication = {
            isAuth: false,
            userName: ""
        };
        var _lastState = { name: redirectState };


        var authorization = {
            isAuthorized: function(state) {
                self = this;
                if (!authentication.isAuth)
                    return false;
                var authorizedGroups = authorization.permissions ? authorization.permissions.indexOf(state) : -1;
                return authorizedGroups >= 0;
            },
            role: null
        };

        var saveRegistration = function(registration) {

            logOut();

            return $http.post(serviceBase + 'api/accounts/create/', registration).then(function(response) {
                return response;
                //todo salvar em local storage
            });

        };

        var login = function(loginData) {

            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

            var deferred = $q.defer();

            var headers = { 'Content-Type': 'application/x-www-form-urlencoded' };

            $http.post(serviceBase + 'oauth/token', data, { headers: headers }).success(function(response) {

                localStorageService.set('authorizationData', {
                    token: response.access_token,
                    userName: loginData.userName
                });

                authentication.isAuth = true;
                authentication.userName = loginData.userName;
                groupService.getGroupByUsername(authentication.userName)
                    .then(function(groups) {

                        authorization.groups = groups;
                        authorization.permissions = groupService.extractPermissions(groups);
                        ;
                    });

                logger.success("Bem vindo " + authentication.userName + "! ");
                deferred.resolve(response);

            }).error(function(err, status) {

                logger.error("Não autorizado");

                logOut();

                deferred.reject(err);

            });

            return deferred.promise;

        };
        var logOut = function() {

            localStorageService.remove('authorizationData');

            authentication.isAuth = false;
            authentication.userName = "User";

        };

        var fillAuthData = function() {

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                authentication.isAuth = true;
                authentication.userName = authData.userName;
            }
        };

        var checkAuthorize = function (toState) {
            if (authorization.permissions)
            return authorization.permissions.contains(toState);

        };


    self.saveRegistration = saveRegistration;
        self.login = login;
        self.logOut = logOut;
        self.fillAuthData = fillAuthData;
        self.authentication = authentication;
        self.authorization = authorization;
        self.checkAuthorize = checkAuthorize;


        var lastStateProperty = {
            get: function () {
                var value = _lastState;
                _lastState = { name: redirectState };
                return value;
            },
            set: function (value) {
                _lastState = value;
            }

        };
        Object.defineProperty(self, "lastState", lastStateProperty);


    }

})(window.angular);