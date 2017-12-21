(function () {
    'use strict';

    angular
        .module('ScheduleRApp')
        .controller('StudentsController', StudentsController);

    StudentsController.$inject = ['StudentsService'];

    function StudentsController(StudentsService) {

        var vm = this;
        vm.Students = [];
        vm.SingleStudent = {};
        vm.Status = '';
        vm.getSingleStudent = getSingleStudent;

        activate();

        function activate() {
            return getStudents().then(function () {
                console.log('Activated students view.');
            });
        }

        function getStudents() {
            return StudentsService.getStudents()
                .then(function (data) {
                    vm.Students = data;
                    return vm.Students;
                })
        }

        function getSingleStudent() {
            return StudentsService.getSingleStudent(3)
                .then(function (data) {
                    vm.SingleStudent = data;
                    return vm.SingleStudent;
                });
        }
    }
})();