(function () {
    'use strict';

    angular
        .module('ScheduleRApp',
        [
            'ngMaterial'
            , 'ui.router'
            , 'data.service'
        ])
        .constant('_', window._);
})();