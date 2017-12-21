(function () {
    'use strict';

    angular
        .module('data.service')
        .factory('AppointmentService', AppointmentService);

    AppointmentService.$inject = ['$http'];

    function AppointmentService($http) {

        var baseUrl = 'http://localhost:9003/api/appointments';

        var appointmentService = {
            getAppointments: getAppointments
        };

        return appointmentService;

        function getAppointments() {
            return $http
                .get(baseUrl)
                .then(getAppointmentsData)
                .catch(logError);
        }

        function getAppointmentsData(response) {
            return response.data;
        }

        function logError(error) {
            console.log(error);
        }
    }
})();