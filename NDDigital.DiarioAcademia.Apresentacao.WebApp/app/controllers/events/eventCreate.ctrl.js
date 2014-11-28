(function () {

    'use strict';
    //using
    eventCreateController.$inject = ['eventsService','$state'];

    //namespace
    angular
        .module('controllers.module')
        .controller('eventCreateController', eventCreateController);

    //class
    function eventCreateController(eventsService,state) {
        var self = this;

        //script load
        activate();
        function activate() {
            self.event = {
                id: '0',
                printerId:'1',
                criticyLevel: 'Danger',
                descriptionEvent:""
            };
        }
        self.levels = ["Warning", "Danger", "Info"];
        

        //public methods
        self.save = function () {


            
            eventsService.saveEvent(self.event);
            state.go('events.list');
            
            
        };

    }

})();