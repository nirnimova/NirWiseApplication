mainApp.controller('agentsController', function ($scope, $window, blockUI, AgentsService, ProductsService, AccountsService, FeeAgreementsService) {
    blockUI.start();

    const topAccountResults = 3;

    $scope.accounts = [];

    AgentsService.InitData().then(function (agents) {
        $scope.agents = agents;
    });

    ProductsService.GetInitData().then(function (products) {
        if (products.length == 0) {
            ProductsService.SetProduct('Gemel').then(function () {
                ProductsService.SetProduct('Hishtalmut').then(function () {
                    ProductsService.SetProduct('Pensia').then(function () {
                        $window.location.reload();
                    });
                });
            });
        }
        else {
            $scope.products = products;
            blockUI.stop();
        }
    });

    $scope.AddNewAgent = function () {
        blockUI.start();

        AgentsService.AddNewAgent($scope.newAgent).then(function (newAgentId) {
            FeeAgreementsService.UpsertAgreement(newAgentId, $scope.product, $scope.mySelectedAccounts[0].Id, $scope.fee).then(function () {
                alert("Agent Added Succefully");
            }).catch(function (e) {
                alert("error");
            }).finally(function () {
                $window.location.reload();
            });
        }).catch(function (e) {
            alert("error");
        });
    };

    AccountsService.SearchTopWiseAccounts({}, topAccountResults).then(function (accounts) {
        $scope.accounts = accounts;
    }).catch(function (e) {
        alert("error");
    }).finally(function () {
        blockUI.stop();
    });

    $scope.SearchWiseAgents = function () {
        blockUI.start();

        AgentsService.SearchWiseAgents($scope.searchAgent).then(function (agents) {
            $scope.agents = agents;
        }).catch(function (e) {
            alert("error");
        }).finally(function () {
            blockUI.stop();
        });
    };

    $scope.SearchTopWiseAccounts = function () {
        blockUI.start();

        AccountsService.SearchTopWiseAccounts($scope.searchAccount, topAccountResults).then(function (accounts) {
            $scope.accounts = accounts;
        }).catch(function (e) {
            alert("error");
        }).finally(function () {
            blockUI.stop();
        });
    };

    $scope.RedirectToEditMode = function (agentId) {
        $window.location.href = '#!agents/' + agentId;
    };

    //@@ Clear
    $scope.ClearForm = function () {
        var searchFields = angular.element(document.querySelectorAll('.form-group input[type="text"]'));

        searchFields.val('');
    };
});