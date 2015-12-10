(function () {
    "use strict";

    angular.module("designerApi").service("WorkflowBatchService", WorkflowBatchService);

    WorkflowBatchService.$inject = ["$log", "$http"];

    function WorkflowBatchService($log, $http) {
        var svc = this;

        var url = "/api/WorkflowBatch";

        svc.get = function (id) {
            return $http.get(id ? url + "/" + id : url);
        };

        svc.post = function (model) {
            return $http.post(url, model);
        };

        svc.put = function (model) {
            return $http.put(url + "/" + model.id, model);
        };
    };
})();
