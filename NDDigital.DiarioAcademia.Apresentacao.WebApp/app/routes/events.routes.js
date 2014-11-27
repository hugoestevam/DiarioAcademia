(function () {
    'use strict';
    var KEYS = angular.injector(['common.module']).get('CONSTANT_KEYS');

    angular
        .module('routes.module')
        .config(configRoutes);

    configRoutes.$inject = [KEYS.APP_ROUTES];
    function configRoutes(routes) {

        routes.push({
            state: 'events',
            url: '/events',
            templateUrl: '/app/templates/components/inner-view.html'
        }, {
            state: 'events.list',
            url: '/list',
            controller: 'eventsListController as vm',
            templateUrl: '/app/views/events/events-list.html'
        }, {
            state: 'events.details',
            url: '/details/:eventId',
            controller: 'eventDetailsController as vm',
            templateUrl: '/app/views/events/event-details.html'
        }, {
            state: 'events.create',
            url: '/create',
            controller: 'eventCreateController as vm',
            templateUrl: '/app/views/events/event-create.html'
        }
 );


    }

})();