(function () {
    'use strict';

    angular
        .module('app.config', [])
        .config(config);

    config.$inject = ['$stateProvider', '$locationProvider', '$mdDateLocaleProvider', '$mdThemingProvider'];

    function config($stateProvider, $locationProvider, $mdDateLocaleProvider, $mdThemingProvider) {

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

        //format Date
        $mdDateLocaleProvider.formatDate = function (date) {
            return date ? moment(date).format('DD-MM-YYYY') : null;
        };

        $mdDateLocaleProvider.parseDate = function (dateString) {
            var m = moment(dateString, 'DD-MM-YYYY', true);
            return m.isValid() ? m.toDate() : new Date(NaN);
        };

        //themes are still defined in config, but the css is not generated
        $mdThemingProvider.theme('altTheme')
            .primaryPalette('brown')
            .accentPalette('blue')
            .warnPalette('red')
            .dark();

        $mdThemingProvider.theme('myTheme')
            .primaryPalette('pink')
            .accentPalette('orange')
            .dark();

        $mdThemingProvider.alwaysWatchTheme(true);
    }
})();