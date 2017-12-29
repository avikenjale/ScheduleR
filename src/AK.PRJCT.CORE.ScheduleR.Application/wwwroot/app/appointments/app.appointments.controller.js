(function () {
    'use strict';

    angular
        .module('ScheduleRApp')
        .controller('AppointmentsController', AppointmentsController);

    AppointmentsController.$inject = ['$scope', '$filter', '$mdDialog', 'AppointmentBusinessService'];

    function AppointmentsController($scope, $filter, $mdDialog, AppointmentBusinessService) {

        var vm = this;

        vm.Date = new Date();
        vm.appointment = {};
        vm.AppointmentDetails = [];

        vm.getAppointmentsByDate = getAppointmentsByDate;
        vm.saveAppointment = saveAppointment;
        vm.getSubstring = getSubstring;        
        vm.showScheduleAppointmentDialog = showScheduleAppointmentDialog;
        vm.closeDialog = closeDialog;

        vm.DayTimeSlots = ["10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30",
            "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30"];

        activate();

        function activate() {
            return getAppointmentsByDate();
        }

        function getAppointmentsByDate() {
            var dates = $filter('date')(new Date(vm.Date), 'yyyy-MM-dd');

            return AppointmentBusinessService.getAppointmentDetailsByDate(dates)
                .then(function (data) {
                    vm.AppointmentDetails = getSlottedAppointments(data);
                    return vm.AppointmentDetails;
                });
        }

        function getSlottedAppointments(data) {

            var teacherAppointmentments = _.map(data, function (teacher) {

                var studentSlots = _.map(vm.DayTimeSlots, function (time) {

                    var studentInSlot = _.find(teacher.students, function (student) {
                        return student.appointmentTime.indexOf(time) > -1;
                    });

                    return _.assign({ slot: time }, studentInSlot);
                });

                return _.assign(
                    { teacherAppointments: studentSlots },
                    { teacherId: teacher.teacherId, teacherFirstName: teacher.teacherFirstName, teacherLastName: teacher.teacherLastName });
            });
            return teacherAppointmentments;
        }

        function getSubstring(str, start, end) {
            if (angular.isDefined(str))
                return str.substring(start, end);
        }        

        function resetAppointment() {
            vm.appointment = {
                appointmentId: 0,
                teacherId: 0,
                classId: 0,
                studentId: 0,
                appointmentTime: ''
            };
        }

        //#region $mdDialog

        function saveAppointment() {
            return AppointmentBusinessService.saveAppointment(vm.appointment)
                .then(function (data) {
                    console.log(data);
                    if (data === "Appointment saved successfully.") {

                        resetAppointment();
                        $mdDialog.hide();

                        return getAppointmentsByDate();
                    }
                });
        }

        function showScheduleAppointmentDialog(app) {

            vm.appointment = {
                appointmentId: app.appointmentId,
                teacherId: app.teacherId,
                classId: app.classId,
                studentId: app.studentId,
                appointmentTime: app.appointmentTime
            };

            $mdDialog.show({
                contentElement: '#scheduleAppointDialog',
                parent: angular.element(document.body),
                controllerAs: 'vm'
            });
        }

        function closeDialog() {
            $mdDialog.hide();
        }

        //#endregion
    }
})();