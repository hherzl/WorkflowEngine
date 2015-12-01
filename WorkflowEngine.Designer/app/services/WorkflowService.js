(function () {
    "use strict";

    angular.module("designer").service("WorkflowService", WorkflowService);

    WorkflowService.$inject = ["$log", "$http"];

    function WorkflowService($log, $http) {
        var svc = this;

        var url = "/api/Workflow";

        svc.post = function (model) {
            return $http.post(url, model);
        };
    };
})();
