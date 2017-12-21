(function () {
    'use strict';

    var StudentComponent = {
        template: '<h2>Student component</h2>',
        bindings: {
        }
    }
    
    angular
        .module('ScheduleRApp')
        .component('studentComponent', StudentComponent);
})();