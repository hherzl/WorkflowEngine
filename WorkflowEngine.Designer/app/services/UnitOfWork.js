(function () {
    "use strict";

    angular.module("designer").service("UnitOfWork", UnitOfWork);

    UnitOfWork.$inject = ["DesignerService", "WorkflowService"];

    function UnitOfWork(designerSvc, workflowSvc) {
        var svc = this;

        svc.designerRepository = designerSvc;

        svc.workflowRepository = workflowSvc;
    };
})();
