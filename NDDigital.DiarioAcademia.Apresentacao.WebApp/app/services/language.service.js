(function () {
    'use strict';

    //using
    languageService.$inject = ['$http', 'logger','BASEURL', 'resource', 'languageEnum'];

    //namespace
    angular.module('services.module')
        .service('languageService', languageService)
        .value('resource', {})
        .value('languageEnum', { 'en-us': 1, 'pt-br': 2, 'es-es': 3 });

    //class
    function languageService($http, logger, baseUrl, resource, languageId) {
        var self = this;


        var url = baseUrl + 'api/language/';

        self.get = get;
        self.updateLanguage = updateLanguage;
        self.currentLanguage = { value: '' };
        self.getCurrentLanguage = getCurrentLanguage;

        function get(language) {
            var id = 2;// languageId[language || 'en-us'];
            self.currentLanguage.value = resource.$currentLanguage = language;
            if (!id) throw new Error("Language not Found");
            return $http.get(url + id);
        }
        function updateLanguage(language) {
            get(language)
                .then(function (results) {
                    for (var i in results.data) {
                        var pair = results.data[i];
                        if(!pair.key) continue;
                        resource[pair.key] = pair.value;
                        resource[pair.key.toLowerCase()] = pair.value;
                    }
                    resource.isReady = true;
                }).catch(function () {

                });
        }
        function getCurrentLanguage() {
            return self.currentLanguage.value;
        }

    }
})();