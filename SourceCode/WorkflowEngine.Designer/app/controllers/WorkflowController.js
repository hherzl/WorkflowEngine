(function (app) {
    "use strict";

    app.controller("WorkflowCreateController", WorkflowCreateController);
    app.controller("WorkflowController", WorkflowController);
    app.controller("WorkflowDetailsController", WorkflowDetailsController);

    WorkflowCreateController.$inject = ["$log", "$location", "$routeParams", "toaster", "UnitOfWork"];
    WorkflowController.$inject = ["$log", "$location", "toaster", "UnitOfWork"];
    WorkflowDetailsController.$inject = ["$log", "$location", "$routeParams", "UnitOfWork"];

    function WorkflowCreateController($log, $location, $routeParams, toaster, uow) {
        var vm = this;

        var id = $routeParams.id;

        vm.saveWorkflow = function () {
            var entity = {
                name: vm.workflowName,
                description: vm.workflowDescription,
                workflowBatchID: id ? id : null
            };

            uow.workflowRepository.post(entity).then(function (result) {
                if (!result.data.didError) {
                    toaster.pop("success", "Workflow was saved successfully");

                    if (id) {
                        $location.path("/workflowBatch/details/" + id);
                    } else {
                        $location.path("/workflow");
                    }
                }
            });
        };
    };

    function WorkflowController($log, $location, toaster, uow) {
        var vm = this;

        vm.workflowResult = {};

        toaster.pop("wait", "Loading workflows...");

        uow.workflowRepository.get().then(function (result) {
            vm.workflowResult = result.data;
        });

        vm.addWorkflow = function () {
            $location.path("/workflow/create/");
        };

        vm.details = function (workflow) {
            $location.path("/workflow/details/" + workflow.id);
        };

        vm.edit = function (workflow) {
            $location.path("/workflow/edit/" + workflow.id);
        };
    };

    function WorkflowDetailsController($log, $location, $routeParams, uow) {
        var vm = this;

        vm.id = $routeParams.id;

        vm.workflowResult = {};

        uow.workflowRepository.get(vm.id).then(function (result) {
            vm.workflowResult = result.data;
        });

        vm.back = function () {
            $location.path("/workflow");
        };

        vm.addWorkflow = function () {
            $location.path("/workflow/create/" + vm.id);
        };
    };
})(angular.module("designer"));
