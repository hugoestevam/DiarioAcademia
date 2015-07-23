(function() {
    'use strict';
    angular.module('services.module', [])
        .value("BASEURL", "http://localhost:31648/")
        .value('LOCAL_STORAGE_KEYS', {
            AUTH_DATA: 'watcher.authData',
            LAST_LOGIN_DATA: 'watcher.lastLoginData',
            TOUR_INSTRUCTIONS: 'watcher.tourInstructionsData'
        });;
})();
