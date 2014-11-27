(function () {

    'use strict';
    //using
    eventsListController.$inject = ['eventsService', 'logger'];

    //namespace
    angular
        .module('controllers.module')
        .controller('eventsListController', eventsListController);

    //class
    function eventsListController(eventsService, logger) {
        var self = this;

        //script load
        activate();
        function activate() {
            
            self.events = eventsService.getEvents();
            self.selectedEvent = self.events[0];
            
            



        }

        //public methods
        self.selectEvent = function (event) {
            self.selectedEvent = event;
        };

        self.refresh = function () {
            location.reload();
        };

        self.delete = function (event) {
            
            eventsService.deleteEvent(event.id);
            
            
        };
    }

})();