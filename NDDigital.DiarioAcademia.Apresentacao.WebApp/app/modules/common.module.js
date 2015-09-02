(function () {
    'use strict';
    angular.module("common.module", [])

        .constant('CONSTANT_KEYS', {
            APP_ROUTES: 'APP_ROUTES',
            USER_ROLES: 'USER_ROLES'
        })

        .constant('APP_ROUTES', [])
        .constant('USER_ROLES', {
            manager: 1,
            writer: 3,
            reader: 7
        })
        .value('storageKeys', {
            authoData: 'authorizationData',
            autheData:'authenticationData'
        })
        .value('settings', {
            language:'pt-br'
        });

})();
