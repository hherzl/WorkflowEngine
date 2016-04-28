(function () {
    "use strict";

    angular.module("designerApi").service("UnitOfWork", UnitOfWork);

    UnitOfWork.$inject = ["WorkflowBatchService", "WorkflowService"];

    function UnitOfWork(workflowBatchSvc, workflowSvc) {
        var svc = this;

        svc.workflowBatchRepository = workflowBatchSvc;

        svc.workflowRepository = workflowSvc;
    };
})();
