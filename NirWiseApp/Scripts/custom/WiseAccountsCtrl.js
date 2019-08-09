mainApp.controller('accountsController', function ($scope, $window, blockUI, AccountsService) {
    blockUI.start();

    $scope.accounts = [];

    AccountsService.InitData().then(function (accounts) {
        $scope.accounts = accounts;
        blockUI.stop();
    });

    $scope.AddNewAccount = function () {
        blockUI.start();

        AccountsService.AddNewAccount($scope.newAccount).then(function () {
            alert("Account Added Succefully");
        }).catch(function (e) {
            alert("error");
        }).finally(function () {
            $window.location.reload();  
        });
    };

    $scope.SearchWiseAccounts = function () {
        blockUI.start();

        AccountsService.SearchWiseAccounts($scope.searchAccount).then(function (accounts) {
            $scope.accounts = accounts;
        }).catch(function (e) {
            alert("error");
        }).finally(function () {
            blockUI.stop(); 
        });
    };

    //@@ Clear
    $scope.ClearForm = function () {
        var searchFields = angular.element(document.querySelectorAll('.form-group input[type="text"]'));

        searchFields.val('');
    };
});