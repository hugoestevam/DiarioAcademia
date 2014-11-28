(function () {

    'use strict';
    //using
    eventDetailsController.$inject = ['eventsService', '$stateParams'];

    //namespace
    angular
        .module('controllers.module')
        .controller('eventDetailsController', eventDetailsController);

    //class
    function eventDetailsController(eventsService, params) {
        var self = this;

        //script load
        activate();
        function activate() {

            
            self.event = eventsService.getEventById(params.eventId);
            
            

        }


        //public methods
        self.save = function () {

            eventsService.saveEvent(self.event);

        };
    }

})();