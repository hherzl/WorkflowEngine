(function () {
    "use strict";

    angular.module("designer").controller("WorkflowBatchController", WorkflowBatchController);
    angular.module("designer").controller("WorkflowBatchCreateController", WorkflowBatchCreateController);
    angular.module("designer").controller("WorkflowBatchDetailsController", WorkflowBatchDetailsController);
    angular.module("designer").controller("WorkflowBatchEditController", WorkflowBatchEditController);
    angular.module("designer").controller("WorkflowBatchCloneController", WorkflowBatchCloneController);

    WorkflowBatchController.$inject = ["$log", "$location", "toaster", "UnitOfWork"];
    WorkflowBatchCreateController.$inject = ["$log", "$location", "toaster", "UnitOfWork"];
    WorkflowBatchDetailsController.$inject = ["$log", "$location", "$routeParams", "toaster", "UnitOfWork"];
    WorkflowBatchEditController.$inject = ["$log", "$location", "$routeParams", "toaster", "UnitOfWork"];
    WorkflowBatchCloneController.$inject = ["$log", "$location", "$routeParams", "toaster", "UnitOfWork"];

    function WorkflowBatchController($log, $location, toaster, uow) {
        var vm = this;

        vm.workflowBatchResult = {};

        toaster.pop("wait", "Loading workflow batches...");

        uow.workflowBatchRepository.get().then(function (result) {
            vm.workflowBatchResult = result.data;
        });

        vm.addWorkflowBatch = function () {
            $location.path("/workflowBatch/create/");
        };

        vm.details = function (workflowBatch) {
            $location.path("/workflowBatch/details/" + workflowBatch.id);
        };

        vm.edit = function (workflowBatch) {
            $location.path("/workflowBatch/edit/" + workflowBatch.id);
        };

        vm.clone = function (workflowBatch) {
            $location.path("/workflowBatch/clone/" + workflowBatch.id);
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

        vm.id = $routeParams.id;

        vm.workflowBatchResult = {};

        uow.workflowBatchRepository.get(vm.id).then(function (result) {
            vm.workflowBatchResult = result.data;
        });

        vm.back = function () {
            $location.path("/workflowBatch");
        };

        vm.addWorkflow = function () {
            $location.path("/workflow/create/" + vm.id);
        };
    };

    function WorkflowBatchEditController($log, $location, $routeParams, toaster, uow) {
        var vm = this;

        vm.id = $routeParams.id;

        vm.workflowBatchResult = {};

        uow.workflowBatchRepository.get(vm.id).then(function (result) {
            vm.workflowBatchResult = result.data;
        });

        vm.save = function () {
            var entity = {
                id: vm.id,
                name: vm.workflowBatchResult.model.name,
                description: vm.workflowBatchResult.model.description
            };

            uow.workflowBatchRepository.put(entity).then(function (result) {
                if (!result.data.didError) {
                    toaster.pop("success", "Workflow batch was updated successfully");

                    $location.path("/workflowBatch");
                }
            });
        };

        vm.cancel = function () {
            $location.path("/workflowBatch");
        };
    };

    function WorkflowBatchCloneController($log, $location, $routeParams, toaster, uow) {
        var vm = this;

        vm.id = $routeParams.id;

        vm.workflowBatchResult = {};

        uow.workflowBatchRepository.get(vm.id).then(function (result) {
            vm.workflowBatchResult = result.data;
        });

        vm.clone = function () {
            uow.workflowBatchRepository.clone(vm.id).then(function (result) {
                if (result.data.model.didError) {
                    toaster.pop("info", "There was an error: " + result.model.errorMessage);
                } else {
                    $location.path("/workflowBatch/details/" + result. vm.id);
                }
            });
        };

        vm.back = function () {
            $location.path("/workflowBatch");
        };
    };
})();
