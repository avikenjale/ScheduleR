(function () {
    'use strict';

    angular
        .module('ScheduleRApp')
        .controller('MainController', MainController);

    function MainController() {
        var cntrl = this;
        cntrl.Name = "Avinash kenjale";

        cntrl.goto  = function(selection)
        {
            cntrl.Tab = selection;
        }
    }    
})();