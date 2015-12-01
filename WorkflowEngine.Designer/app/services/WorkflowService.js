(function () {
    "use strict";

    angular.module("designerApi").service("WorkflowService", WorkflowService);

    WorkflowService.$inject = ["$log", "$http"];

    function WorkflowService($log, $http) {
        var svc = this;

        var url = "/api/Workflow";

        svc.get = function () {
            return $http.get(url);
        };

        svc.post = function (model) {
            return $http.post(url, model);
        };
    };
})();
