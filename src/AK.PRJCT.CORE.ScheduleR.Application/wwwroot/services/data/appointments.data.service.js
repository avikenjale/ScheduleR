(function () {
    'use strict';

    angular
        .module('data.service')
        .factory('AppointmentDataService', AppointmentDataService);

    AppointmentDataService.$inject = ['$http'];

    function AppointmentDataService($http) {

        var baseUrl = 'http://localhost:9003/api/appointments';

        var appointmentService = {
            getAppointments: getAppointments,
            getAppointmentsByDate: getAppointmentsByDate,
            saveAppointment: saveAppointment
        };

        return appointmentService;

        function getAppointments() {
            return $http
                .get(baseUrl)
                .then(getAppointmentsData)
                .catch(logError);
        }

        function getAppointmentsByDate(date) {
            return $http.get(baseUrl + "/date/" + date)
                .then(getAppointmentsData)
                .catch(logError);
        }

        function saveAppointment(appointment) {
            return $http.post(baseUrl, appointment)
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