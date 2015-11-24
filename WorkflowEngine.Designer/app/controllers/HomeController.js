(function () {
    "use strict";

    angular.module("designer").controller("HomeController", HomeController);

    HomeController.$inject = ["$log"];

    function HomeController($log) {
        var vm = this;
    };
})();
