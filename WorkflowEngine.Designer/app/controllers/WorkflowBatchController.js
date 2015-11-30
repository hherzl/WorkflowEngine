(function () {
    "use strict";

    angular.module("designer").controller("WorkflowBatchController", WorkflowBatchController);

    WorkflowBatchController.$inject = ["$log", "$location", "$mdDialog"];

    function WorkflowBatchController($log, $location, $mdDialog) {
        var vm = this;

        vm.addingWorkflowTask = false;

        vm.addWorkflow = function () {
            $location.path("/workflow/create/");
        };
    };
})();
