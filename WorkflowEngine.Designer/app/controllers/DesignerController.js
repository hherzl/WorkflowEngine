(function () {
    "use strict";

    angular.module("designer").controller("DesignerController", DesignerController);

    DesignerController.$inject = ["$log", "$scope", "$location"];

    function DesignerController($log, $scope, $location) {
        $scope.workflows = [];

        $scope.addWorkflow = function () {
            $location.path("/workflow/create");
        };
    };
})();
