(function () {
    'use strict';

    angular
        .module('ScheduleRApp')
        .config(config);

    config.$inject = ['$stateProvider', '$locationProvider'];

    function config($stateProvider, $locationProvider) {

        $stateProvider
            .state('student', {
                url: '/student',
                controller: 'StudentsController as st',
                templateUrl: '../app/students/students.list.html'
            })
            .state('teacher', {
                url: '/teacher',
                controller: 'TeachersController',
                templateUrl: '../app/teachers/teachers.list.html'
            })
            .state('class', {
                url: '/class',
                controller: 'ClassesController as cls',
                templateUrl: '../app/classes/classes.list.html'
            })
            .state('appointment', {
                url: '/appointment',
                controller: 'AppointmentsController as apt',
                templateUrl: '../app/appointments/appointments.list.html'
            });

        $locationProvider.html5Mode(true);
    }
})();