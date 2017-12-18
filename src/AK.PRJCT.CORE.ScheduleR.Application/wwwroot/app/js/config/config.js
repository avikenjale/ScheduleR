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
                controller: 'StudentsListController',
                templateUrl: '../app/html/views/students/students.list.html'
            })
            .state('teacher', {
                url: '/teacher',
                controller: 'TeachersListController',
                templateUrl: '../app/html/views/teachers/teachers.list.html'
            })
            .state('class', {
                url: '/class',
                controller: 'ClassesListController',
                templateUrl: '../app/html/views/classes/classes.list.html'
            })
            .state('appointment', {
                url: '/appointment',
                controller: 'AppointmentsListController',
                templateUrl: '../app/html/views/appointments/appointments.list.html'
            });

        $locationProvider.html5Mode(true);
    }
})();