(function () {
    "use strict";

    angular.module("designer").controller("WorkflowCreateController", WorkflowCreateController);

    WorkflowCreateController.$inject = ["$log", "$location", "toaster", "UnitOfWork"];

    function WorkflowCreateController($log, $location, toaster, uow) {
        var vm = this;

        vm.saveWorkflow = function () {
            var entity = {
                name: vm.workflowName,
                description: vm.workflowDescription
            };

            uow.workflowRepository.post(entity).then(function (result) {
                if (!result.data.didError) {
                    toaster.pop("success", "Workflow was saved successfully");

                    $location.path("/workflowBatch");
                }
            });
        };
    };
})();
