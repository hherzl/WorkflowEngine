(function (app) {
    "use strict";

    app.controller("HomeController", HomeController);

    HomeController.$inject = ["$log"];

    function HomeController($log) {
        var vm = this;
    };
})(angular.module("designer"));
