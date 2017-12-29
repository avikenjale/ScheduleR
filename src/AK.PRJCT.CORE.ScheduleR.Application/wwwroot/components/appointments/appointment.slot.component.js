(function () {
    'use strict';

    var AppointmentSlot = {
        templateUrl: '../components/appointments/appointment.slot.component.html',
        controller: 'AppointmentComponentController as ctrl',
        bindings: {
            teacherId: '<',
            appointmentDate: '<',
            appointment: '=',
            appointmentClick: '&'
        }
    };

    angular
        .module('app.components')
        .component('appointmentSlot', AppointmentSlot);

})();