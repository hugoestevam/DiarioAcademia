(function () {

    'use strict';

    //using
    shellController.$inject = ['$rootScope','$state', '$location', 'authService', 'languageService', 'resource'];

    //namespace
    angular
        .module('controllers.module')
        .controller('shellController', shellController);
    
    //class
    function shellController($rootScope,$state, $location, authService, languageService, res) {
        var self = this;

        //script load
        activate();
        function activate() {
            //authService.authentication.userName = authService.authentication.userName;
            self.authentication = authService.authentication;
            self.authorization = authService.authorization;
            toastr.options.preventDuplicates = true;
            self.currentLanguage = languageService.currentLanguage;
            reTranslate('pt-br');
        }

        self.reTranslate = reTranslate;

        //public methods
        self.logOut = function () {
            authService.logOut();
            $location.path('/home');
        };

        self.isVisible = function (state) {
            return self.authorization.isAuthorized(state);
        };
        
        //private methods
        function reTranslate(language) {

            languageService.updateLanguage(language);

        };
    }
})();