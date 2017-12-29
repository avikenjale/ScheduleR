(function () {
    'use strict';

    angular
        .module('business.service')
        .factory('AppointmentBusinessService', AppointmentBusinessService);

    AppointmentBusinessService.$inject = ['AppointmentDataService', 'StudentDataService', 'ClassDataService', 'TeacherDataService'];

    function AppointmentBusinessService(AppointmentDataService, StudentDataService, ClassDataService, TeacherDataService) {

        var Appointments = [];
        var Students = [];
        var Classes = [];
        var Teachers = [];
        var AppointmentDetails = [];


        var service = {
            getAppointmentDetails: getAppointmentDetails,
            getAppointmentDetailsByDate: getAppointmentDetailsByDate,
            saveAppointment: saveAppointment
        }

        return service;

        function getAppointments() {
            return AppointmentDataService.getAppointments()
                .then(getAppointmentsData);
        }

        function getAppointmentsByDate(date) {
            return AppointmentDataService.getAppointmentsByDate(date)
                .then(getAppointmentsData);
        }

        function saveAppointment(appointment) {
            return AppointmentDataService.saveAppointment(appointment)
                .then(function (data) {
                    return data;
                });
        }

        function getAppointmentsData(data) {
            Appointments = data
            return Appointments;
        }

        function getStudents() {
            return StudentDataService.getStudents()
                .then(function (data) {
                    Students = data;
                    return Students;
                });
        }

        function getClasses() {
            return ClassDataService.getClasses()
                .then(function (data) {
                    Classes = data;
                    return Classes;
                })
        }

        function getTeachers() {
            return TeacherDataService.getTeachers()
                .then(function (data) {
                    Teachers = data;
                    return Teachers;
                })
        }

        function getAppointmentDetailsByDate(date) {
            return getAppointmentsByDate(date).then(function () {
                console.log('Appointments data loaded.');

                return getStudents().then(function () {
                    console.log('Students data loaded.');

                    return getClasses().then(function () {
                        console.log('Classes data loaded.');

                        return getTeachers().then(function () {
                            console.log('Teachers data loaded.');

                            GetDetails();
                            return AppointmentDetails;
                        });
                    });
                });
            });
        }

        function getAppointmentDetails() {
            return getAppointments().then(function () {
                console.log('Appointments data loaded.');

                return getStudents().then(function () {
                    console.log('Students data loaded.');

                    return getClasses().then(function () {
                        console.log('Classes data loaded.');

                        return getTeachers().then(function () {
                            console.log('Teachers data loaded.');

                            GetDetails();
                            return AppointmentDetails;
                        });
                    });
                });
            });
        }

        function GetDetails() {
            AppointmentDetails = _.map(Teachers, function (t) {

                // add the properties from second array matching the userID
                // to the vmect from first array and return the updated vmect
                /*var s = _.assign(a, _.find(Students, { studentId: a.studentId }));
                s = _.assign(s, _.find(Classes, { classId: s.classId }));
                s = _.assign(s, _.find(Teachers, { teacherId: s.teacherId }));*/

                var s = {};

                var teacher = t;

                var appointmentStudents = _.map(Appointments, function (a) {

                    return _.assign(a, _.find(Students, { studentId: a.studentId }));
                });

                var appointments = _.filter(appointmentStudents, { teacherId: t.teacherId });
                var students = _.map(appointments, function (a) {
                    return _.assign(a, _.find(Classes, { classId: a.classId }));
                });

                var appointment = {
                    teacherId: teacher.teacherId,
                    teacherFirstName: teacher.teacherFirstName,
                    teacherLastName: teacher.teacherLastName,
                    students: students
                }

                return appointment;
            });
        }
    }
})();