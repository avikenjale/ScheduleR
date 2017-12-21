(function () {
    'use strict';

    angular
        .module('ScheduleRApp')
        .controller('AppointmentsController', AppointmentsController);

    AppointmentsController.$inject = ['AppointmentService', 'StudentsService', 'ClassService', 'TeacherService'];

    function AppointmentsController(AppointmentService, StudentsService, ClassService, TeacherService) {

        var vm = this;
        vm.Appointments = [];
        vm.Students = [];
        vm.AppointmentStudents = [];
        vm.Classes = [];
        vm.Teachers = [];

        activate();

        function getAppointments() {
            return AppointmentService.getAppointments()
                .then(getAppointmentsData);
        }

        function getAppointmentsData(data) {
            vm.Appointments = data
            return vm.Appointments;
        }

        function getStudents() {
            return StudentsService.getStudents()
                .then(function (data) {
                    vm.Students = data;
                    return vm.Students;
                });
        }

        function getClasses() {
            return ClassService.getClasses()
                .then(function (data) {
                    vm.Classes = data;
                    return vm.Classes;
                })
        }

        function getTeachers() {
            return TeacherService.getTeachers()
                .then(function (data) {
                    vm.Teachers = data;
                    return vm.Teachers;
                })
        }

        function activate() {
            return getAppointments().then(function () {
                console.log('Appointments data loaded.');

                return getStudents().then(function () {
                    console.log('Students data loaded.');

                    return getClasses().then(function () {
                        console.log('Classes data loaded.');

                        return getTeachers().then(function () {
                            console.log('Teachers data loaded.');
                        });
                    });
                });
            });
        }

        vm.GetData = function () {
            vm.AppointmentStudents = _.map(vm.Students, function (s) {

                // add the properties from second array matching the userID
                // to the vmect from first array and return the updated vmect
                var a = _.assign(s, _.find(vm.Appointments, { studentId: s.studentId }));
                a = _.assign(a, _.find(vm.Classes, { classId: a.classId }));
                a = _.assign(a, _.find(vm.Teachers, { teacherId: a.teacherId }));

                return a;
            });
        }
    }
})();