(function () {
    'use strict';
    angular.module("common.module", [])

        .constant('CONSTANT_KEYS', {
            APP_ROUTES: 'APP_ROUTES'
        })

        .constant('APP_ROUTES', []);

   
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