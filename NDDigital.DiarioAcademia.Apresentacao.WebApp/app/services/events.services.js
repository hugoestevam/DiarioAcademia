(function () {

    'use strict';
    
    //using
    eventsService.$inject = ['$http', 'logger','BASEURL'];

    //namespace
    angular.module('services.module')
       .service('eventsService', eventsService);

    //class

    function eventsService($http, logger, baseUrl) {
        var self = this;
        var serviceUrl = baseUrl + "api/events";


        
        //public methods
        self.getEvents = function() {
            return events;
        };
        self.getEventById = function(id) {
            return events[id];
        };
        self.saveEvent = function(event) {
            event.information = event.descriptionEvent;
            return events.unshift(event);
        };
        self.postEvent = function(event) {
            return events[event.id] = event;
        };
        self.deleteEvent = function(id) {
            return events.splice(id, 1);
        };
        
        


        
    }
})();



var events = [{
    "id": 0,
    "type": "System Event",
    "dateEventOccurrence": "2014-09-04T01:06:18.4432434-03:00",
    "timeElapsedDateOccurrence": "21 horas atrás",
    "information": "Esta empresa não tem impressões desde ontem",
    "moreInformation": "21 horas atrás",
    "site": "172.31.0.01",
    "criticyLevel": "Warning",
    "printerName": "Ricoh Aficio MP C30001",
    "printerIp": "172.31.5.01"
},
{
    "id": 1,
    "type": "System Event",
    "dateEventOccurrence": "2014-09-04T02:06:18.4432434-03:00",
    "timeElapsedDateOccurrence": "22 horas atrás",
    "information": "Esta empresa não tem impressões desde ontem",
    "moreInformation": "22 horas atrás",
    "site": "172.31.0.11",
    "criticyLevel": "Warning",
    "printerName": "Ricoh Aficio MP C30011",
    "printerIp": "172.31.5.11"
},
{
    "id": 2,
    "type": "System Event",
    "dateEventOccurrence": "2014-09-04T03:06:18.4432434-03:00",
    "timeElapsedDateOccurrence": "23 horas atrás",
    "information": "Esta empresa não tem impressões desde ontem",
    "moreInformation": "23 horas atrás",
    "site": "172.31.0.21",
    "criticyLevel": "Danger",
    "printerName": "Ricoh Aficio MP C30021",
    "printerIp": "172.31.5.21"
},
{
    "id": 3,
    "type": "System Event",
    "dateEventOccurrence": "2014-09-04T04:06:18.4432434-03:00",
    "timeElapsedDateOccurrence": "24 horas atrás",
    "information": "Esta empresa não tem impressões desde ontem",
    "moreInformation": "24 horas atrás",
    "site": "172.31.0.31",
    "criticyLevel": "Danger",
    "printerName": "Ricoh Aficio MP C30031",
    "printerIp": "172.31.5.31"
},
{
    "id": 4,
    "type": "System Event",
    "dateEventOccurrence": "2014-09-04T05:06:18.4432434-03:00",
    "timeElapsedDateOccurrence": "25 horas atrás",
    "information": "Esta empresa não tem impressões desde ontem",
    "moreInformation": "25 horas atrás",
    "site": "172.31.0.41",
    "criticyLevel": "Danger",
    "printerName": "Ricoh Aficio MP C30041",
    "printerIp": "172.31.5.41"
},
{
    "id": 5,
    "type": "System Event",
    "dateEventOccurrence": "2014-09-04T06:06:18.4432434-03:00",
    "timeElapsedDateOccurrence": "26 horas atrás",
    "information": "Esta empresa não tem impressões desde ontem",
    "moreInformation": "26 horas atrás",
    "site": "172.31.0.51",
    "criticyLevel": "Danger",
    "printerName": "Ricoh Aficio MP C30051",
    "printerIp": "172.31.5.51"
},
{
    "id": 6,
    "type": "System Event",
    "dateEventOccurrence": "2014-09-04T07:06:18.4432434-03:00",
    "timeElapsedDateOccurrence": "27 horas atrás",
    "information": "Esta empresa não tem impressões desde ontem",
    "moreInformation": "27 horas atrás",
    "site": "172.31.0.61",
    "criticyLevel": "Warning",
    "printerName": "Ricoh Aficio MP C30061",
    "printerIp": "172.31.5.61"
},
{
    "id": 7,
    "type": "System Event",
    "dateEventOccurrence": "2014-09-04T08:06:18.4432434-03:00",
    "timeElapsedDateOccurrence": "28 horas atrás",
    "information": "Esta empresa não tem impressões desde ontem",
    "moreInformation": "28 horas atrás",
    "site": "172.31.0.71",
    "criticyLevel": "Danger",
    "printerName": "Ricoh Aficio MP C30071",
    "printerIp": "172.31.5.71"
},
{
    "id": 8,
    "type": "System Event",
    "dateEventOccurrence": "2014-09-04T09:06:18.4432434-03:00",
    "timeElapsedDateOccurrence": "29 horas atrás",
    "information": "Esta empresa não tem impressões desde ontem",
    "moreInformation": "29 horas atrás",
    "site": "172.31.0.81",
    "criticyLevel": "Danger",
    "printerName": "Ricoh Aficio MP C30081",
    "printerIp": "172.31.5.81"
},
{
    "id": 9,
    "type": "System Event",
    "dateEventOccurrence": "2014-09-04T10:06:18.4432434-03:00",
    "timeElapsedDateOccurrence": "210 horas atrás",
    "information": "Esta empresa não tem impressões desde ontem",
    "moreInformation": "210 horas atrás",
    "site": "172.31.0.91",
    "criticyLevel": "Warning",
    "printerName": "Ricoh Aficio MP C30091",
    "printerIp": "172.31.5.91"
}
];

