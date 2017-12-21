(function () {
    'use strict';

    angular
        .module('ScheduleRApp')
        .controller('ClassesController', ClassesController);

    ClassesController.$inject = ['ClassService'];
    function ClassesController(ClassService) {

        var vm = this;
        vm.Classes = [];
        vm.status = {};

        activate();

        function activate() {
            return ClassService.getClasses()
                .then(function (data) {
                    vm.Classes = data;
                    return vm.Classes;
                });
        }
    }
})();