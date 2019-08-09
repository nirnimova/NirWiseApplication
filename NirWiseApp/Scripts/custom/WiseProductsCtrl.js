mainApp.controller('productsController', function ($scope, $window, blockUI, ProductsService, FeeAgreementsService) {
    blockUI.start();

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

    $scope.filterResults = function () {
        blockUI.start();

        FeeAgreementsService.GetAccountAndAgentNamesForProduct($scope.product).then(function (agentsWithAccounts) {
            $scope.agentsWithAccounts = agentsWithAccounts;
        }).catch(function (e) {
            alert('error');
        }).finally(function () {
            blockUI.stop();
        });
    }
});