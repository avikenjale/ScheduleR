(function () {
    'use strict';

    angular
        .module('app.components')
        .controller('AppointmentComponentController', AppointmentComponentController);

    AppointmentComponentController.$inject = ['$mdDialog'];

    function AppointmentComponentController($mdDialog) {

        var vm = this;
        vm.showAppointment = showAppointment;

        vm.message = {};

        function showAppointment() {
            vm.appointment.teacherId = vm.teacherId;
            vm.appointment.appointmentTime = vm.appointmentDate + ' ' +vm.appointment.slot + ':00';
            vm.appointmentClick({
                app: vm.appointment
            });
        }
    }
})();