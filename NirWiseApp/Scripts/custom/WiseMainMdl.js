var mainApp = angular.module('WiseMainModule', ['ngRoute', 'trNgGrid', 'blockUI']);

mainApp.config(function ($routeProvider) {
    $routeProvider.when("/accounts", {
        controller: "accountsController",
        templateUrl: "/templates/accounts.html"
    }).when("/products", {
        controller: "productsController",
        templateUrl: "/templates/products.html"
    }).when("/agents", {
        controller: "agentsController",
        templateUrl: "/templates/agents.html"
    }).when("/agents/:agentId", {
        controller: "editAgentController",
        templateUrl: "/templates/editAgent.html"
    }).when("/reports", {
        controller: "reportsController",
        templateUrl: "/templates/reports.html"
    }).otherwise({
        redirectTo: "/"
    })
});