(function () {
    "use strict";

    angular.module("designer").service("UnitOfWork", UnitOfWork);

    UnitOfWork.$inject = ["DesignerService"];

    function UnitOfWork(designerSvc) {
        var svc = this;

        svc.designerRepository = designerSvc;
    };
})();
