(function () {
    'use strict';

    angular
        .module('data.service')
        .factory('StudentDataService', StudentDataService);

    StudentDataService.$inject = ['$http'];

    function StudentDataService($http) {
        var baseUrl = 'http://localhost:9000/api/students';
        var studentService = {
            getStudents: getStudents,
            getSingleStudent: getSingleStudent
        };

        return studentService;

        function getStudents() {
            return $http.get(baseUrl)
                .then(getStudentsData)
                .catch(logException);
        }

        function getSingleStudent(studentId) {
            return $http.get(baseUrl)
                .then(function (response) {
                    var student = _.find(response.data, function (o) {
                        return o.studentId == studentId;
                    });

                    return student.firstName;
                })
                .catch(logException);
        }

        function getStudentsData(response) {
            return response.data;
        }

        function logException(error) {
            console.log(error);
        }
    }
})();