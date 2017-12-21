(function () {
    'use strict';

    angular.module('data.service')
        .factory('TeacherService', TeacherService);

    TeacherService.$inject = ['$http'];

    function TeacherService($http) {

        var baseUrl = "http://localhost:9001/api/teachers";

        var service = {
            getTeachers: getTeachers
        };

        function getTeachers() {
            return $http.get(baseUrl)
                .then(getTeachersData)
                .catch(logError);
        }

        function getTeachersData(response) {
            return response.data;
        }

        function logError(error) {
            console.log(error);
        }

        return service;
    }
})();