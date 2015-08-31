(function (angular) {

    'use strict';

    authService.$inject = ['$http', '$q', 'localStorageService', 'logger', 'BASEURL', 'groupService', 'storageKeys', 'resource', 'userService'];

    angular.module('services.module')
        .service('authService', authService);

    function authService($http, $q, localStorageService, logger, serviceBase, groupService, storageKeys, res, userService) {
        var self = this;

        var redirectState = "home";
        var _username = "";
        var _fullname = "";

        var authentication = {
            isAuth: false,
        };

        var userNameProperty = {
            get: function () {
                return _username;
            },
            set: function (value) {
                _username = value;
            }

        };

        var fullNameProperty = {
            get: function () {
                return _fullname;
            },
            set: function (value) {
                _fullname = value;
            }

        };

        Object.defineProperty(authentication, "userName", userNameProperty);
        Object.defineProperty(authentication, "fullName", fullNameProperty);


        var _lastState = redirectState;




        var authorization = {
            //used for control menus on sidebars
            isAuthorized: function (state) {
                if (!authentication.isAuth)
                    return false;
                var authorizedGroups = authorization.permissions ? authorization.permissions.indexOf(state) : -1;
                return authorizedGroups >= 0;
            },
            role: null
        };

        activate();
        function activate() {
            fillAuthData();
        }

        var saveRegistration = function (registration) {

            logOut();

            return $http.post(serviceBase + 'api/accounts/create/', registration).then(function (response) {
                return response;
            });

        };

        var login = function (loginData) {

            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

            var deferred = $q.defer();

            var headers = { 'Content-Type': 'application/x-www-form-urlencoded' };

            $http.post(serviceBase + 'oauth/token', data, { headers: headers }).success(function (response) {


                authentication.isAuth = true;
                authentication.userName = loginData.userName;
                userService.getUserByUsername(authentication.userName)
                         .then(function (results) {
                             authentication.fullName = results.firstName + " " + results.lastName;
                             authentication.userId = results.id;
                             //criptografar isto
                             localStorageService.set(storageKeys.authoData, {
                                 token: response.access_token,
                                 userName: loginData.userName,
                                 fullName: authentication.fullName,
                                 userId: authentication.userId
                             });
                             localStorageService.set(storageKeys.autheData, authorization);
                             //get groups
                             groupService.getGroupByUsername(authentication.userName)
                                 .then(function (groups) {
                                     authorization.groups = groups;
                                     authorization.permissions = groupService.extractPermissions(groups);
                                   
                                 });
                         });

                logger.success(res.welcome + " " + (authentication.userName));
                deferred.resolve(response);

            }).error(function (err, status) {
                if (!status)
                    logger.error(res.unavailable_server);
                else
                    logger.error(err.error_description);
                logOut();
                deferred.reject(err);

            });

            return deferred.promise;

        };

        var logOut = function () {

            localStorageService.remove(storageKeys.authoData);
            localStorageService.remove(storageKeys.autheData);

            authentication.isAuth = false;
            authentication.userName = "";

            authorization.groups = authorization.permissions = undefined;

        };

        function fillAuthData() {

            var authoData = localStorageService.get(storageKeys.authoData);
            var autheData = localStorageService.get(storageKeys.autheData);
            if (authoData) {
                authentication.isAuth = true;
                authentication.userName = authoData.userName;
                authentication.fullName = authoData.fullName;
                authentication.userId = authoData.userId;
            }
            if (autheData) {
                authorization.groups = autheData.groups;
                authorization.permissions = autheData.permissions;
            }

        };

        //used for authorize the access to view
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
                _lastState = redirectState;
                return value;
            },
            set: function (value) {
                _lastState = value;
            }

        };

        Object.defineProperty(self, "lastState", lastStateProperty);

    }

})(window.angular);