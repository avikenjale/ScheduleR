(function () {
    'use strict';

    angular
        .module('app.custom.filters', [])
        .filter('twentyFourToTwelve', twentyFourToTwelve);

    function twentyFourToTwelve() {
        return function (inputTime) {
            inputTime = inputTime.toString(); //value to string for splitting
            var splitTime = inputTime.split(':');
            var ampm = (splitTime[0] >= 12 ? ' PM' : ' AM'); //determine AM or PM 
            splitTime[0] = splitTime[0] % 12;
            splitTime[0] = (splitTime[0] == 0 ? 12 : splitTime[0]); //adjust for 0 = 12

            return splitTime.join(':') + ampm;
        };
    };
})();