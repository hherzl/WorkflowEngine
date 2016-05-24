(function (app) {
    "use strict";

    app.service("WorkflowService", WorkflowService);

    WorkflowService.$inject = ["$log", "$http"];

    function WorkflowService($log, $http) {
        var svc = this;

        var url = "/api/Workflow";

        svc.get = function (id) {
            return $http.get(id ? url + "/" + id : url);
        };

        svc.post = function (model) {
            return $http.post(url, model);
        };
    };
})(angular.module("designer"));
