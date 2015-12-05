(function () {
    "use strict";

    angular.module("designer").controller("WorkflowBatchController", WorkflowBatchController);
    angular.module("designer").controller("WorkflowBatchCreateController", WorkflowBatchCreateController);
    angular.module("designer").controller("WorkflowBatchDetailsController", WorkflowBatchDetailsController);

    WorkflowBatchController.$inject = ["$log", "$location", "UnitOfWork"];
    WorkflowBatchCreateController.$inject = ["$log", "$location", "toaster", "UnitOfWork"];
    WorkflowBatchDetailsController.$inject = ["$log", "$location", "$routeParams", "toaster", "UnitOfWork"];

    function WorkflowBatchController($log, $location, uow) {
        var vm = this;

        vm.workflowBatchResult = {};

        uow.workflowBatchRepository.get().then(function (result) {
            vm.workflowBatchResult = result.data;
        });

        vm.addWorkflowBatch = function () {
            $location.path("/workflowBatch/create/");
        };

        vm.details = function (workflowBatch) {
            $location.path("/workflowBatch/details/" + workflowBatch.id);
        };
    };

    function WorkflowBatchCreateController($log, $location, toaster, uow) {
        var vm = this;

        vm.saveWorkflowBatch = function () {
            var entity = {
                name: vm.workflowBatchName,
                description: vm.workflowBatchDescription
            };

            uow.workflowBatchRepository.post(entity).then(function (result) {
                if (!result.data.didError) {
                    toaster.pop("success", "Workflow batch was saved successfully");

                    $location.path("/workflowBatch");
                }
            });
        };
    };

    function WorkflowBatchDetailsController($log, $location, $routeParams, toaster, uow) {
        var vm = this;

        var id = $routeParams.id;

        vm.workflowBatchResult = {};

        uow.workflowBatchRepository.get(id).then(function (result) {
            vm.workflowBatchResult = result.data;

            debugger;
        });
    };
})();
