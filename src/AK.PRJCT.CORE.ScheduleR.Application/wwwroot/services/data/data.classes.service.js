(function () {
    'use strict';

    angular.module('data.service')
        .factory('ClassService', ClassService);

    ClassService.$inject = ['$http'];

    function ClassService($http) {
        var baseUrl = "http://localhost:9002/api/classes";

        var service = {
            getClasses: getClasses
        };

        return service;

        function getClasses() {
            return $http.get(baseUrl)
                .then(getClassesData)
                .catch(logError);
        }

        function getClassesData(response) {
            return response.data;
        }

        function logError(error) {
            console.log(error);
        }
    }
})();