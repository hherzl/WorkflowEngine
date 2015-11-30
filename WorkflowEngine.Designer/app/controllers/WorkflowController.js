(function () {
    "use strict";

    angular.module("designer").controller("WorkflowCreateController", WorkflowCreateController);

    WorkflowCreateController.$inject = ["$log", "$location", "$mdDialog"];

    function WorkflowCreateController($log, $location, $mdDialog) {
        var vm = this;

        vm.saveWorkflow = function () {
            
        };
    };
})();
