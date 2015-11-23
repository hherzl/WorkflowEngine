(function () {
    "use strict";

    angular.module("designer").controller("WorkflowCreateController", WorkflowCreateController);

    WorkflowCreateController.$inject = ["$log", "$scope", "$location", "$mdDialog"];

    function WorkflowCreateController($log, $scope, $location, $mdDialog) {
        $scope.addingWorkflowTask = false;

        $scope.addWorkflowTask = function () {
            $scope.addingWorkflowTask = true;
        };
    };
})();
