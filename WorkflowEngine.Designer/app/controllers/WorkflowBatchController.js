(function () {
    "use strict";

    angular.module("designer").controller("WorkflowBatchController", WorkflowBatchController);

    WorkflowBatchController.$inject = ["$log", "$location", "UnitOfWork"];

    function WorkflowBatchController($log, $location, uow) {
        var vm = this;

        vm.workflowResult = {};

        uow.workflowRepository.get().then(function (result) {
            vm.workflowResult = result.data;
        });

        vm.addingWorkflowTask = false;

        vm.addWorkflow = function () {
            $location.path("/workflow/create/");
        };
    };
})();
