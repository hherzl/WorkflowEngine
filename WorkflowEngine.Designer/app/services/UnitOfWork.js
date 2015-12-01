(function () {
    "use strict";

    angular.module("designerApi").service("UnitOfWork", UnitOfWork);

    UnitOfWork.$inject = ["DesignerService", "WorkflowService"];

    function UnitOfWork(designerSvc, workflowSvc) {
        var svc = this;

        svc.designerRepository = designerSvc;

        svc.workflowRepository = workflowSvc;
    };
})();
