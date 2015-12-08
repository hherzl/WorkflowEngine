(function () {
    "use strict";

    angular.module("designer", [
        "ngMaterial",
        "ngRoute",
        "toaster",
        "designerApi"
    ]);

    angular.module("designer").config(function ($routeProvider) {
        var base = "/app/views/";

        $routeProvider
            .when("/", {
                templateUrl: base + "home/index.html",
                controller: "HomeController",
                controllerAs: "vm"
            })
            .when("/workflowBatch", {
                templateUrl: base + "workflowBatch/index.html",
                controller: "WorkflowBatchController",
                controllerAs: "vm"
            })
            .when("/workflowBatch/create", {
                templateUrl: base + "workflowBatch/create.html",
                controller: "WorkflowBatchCreateController",
                controllerAs: "vm"
            })
            .when("/workflowBatch/details/:id", {
                templateUrl: base + "workflowBatch/details.html",
                controller: "WorkflowBatchDetailsController",
                controllerAs: "vm"
            })
            .when("/workflowBatch/edit/:id", {
                templateUrl: base + "workflowBatch/edit.html",
                controller: "WorkflowBatchEditController",
                controllerAs: "vm"
            })
            .when("/workflow", {
                templateUrl: base + "workflow/index.html",
                controller: "WorkflowController",
                controllerAs: "vm"
            })
            .when("/workflow/create/:id", {
                templateUrl: base + "workflow/create.html",
                controller: "WorkflowCreateController",
                controllerAs: "vm"
            })
            .when("/workflowTask", {
                templateUrl: base + "workflowTask/index.html",
                controller: "WorkflowTaskController",
                controllerAs: "vm"
            });
    });
})();
