(function () {
    'use strict';

    angular
        .module('ScheduleRApp',
        [
            'ngMaterial'
            , 'ui.router'
            , 'app.config'
            , 'app.custom.filters'
            , 'app.components'
            , 'data.service'
            , 'business.service'
        ])
        .constant('_', window._);
})();