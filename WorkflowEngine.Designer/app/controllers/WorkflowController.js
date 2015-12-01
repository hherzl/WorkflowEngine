(function () {
    "use strict";

    angular.module("designer").controller("WorkflowCreateController", WorkflowCreateController);

    WorkflowCreateController.$inject = ["$log", "$location", "UnitOfWork"];

    function WorkflowCreateController($log, $location, uow) {
        var vm = this;

        vm.saveWorkflow = function () {
            var entity = {
                name: vm.workflowName,
                description: vm.workflowDescription
            };

            uow.workflowRepository.post(entity).then(function (result) {
                
            });
        };
    };
})();
