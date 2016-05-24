(function (app) {
    "use strict";

    app.controller("WorkflowTaskController", WorkflowTaskController);

    WorkflowTaskController.$inject = ["$log", "$location"];

    function WorkflowTaskController($log, $location) {
        var vm = this;

        vm.tasks = [];

        vm.addTask = function () {
            $location.path("/workflow/create");
        };
    };
})(angular.module("designer"));
