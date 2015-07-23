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
        });

   
    //Extensions Méthods
    (function() {
       Array.prototype.remove = function (item) {
           var index = typeof item === 'number' ? item : this.indexOf(item);
           this.splice(index, 1);          
        };
        Array.prototype.contains = function (item) {
            return this.indexOf(item) >= 0;
        };
    });

    


})();