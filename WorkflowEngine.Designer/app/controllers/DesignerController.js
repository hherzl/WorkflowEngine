(function () {
    "use strict";

    angular.module("designer").controller("DesignerController", DesignerController);

    DesignerController.$inject = ["$log", "$location"];

    function DesignerController($log, $location) {
        var vm = this;

        vm.workflows = [];

        vm.addWorkflow = function () {
            $location.path("/workflow/create");
        };
    };
})();
