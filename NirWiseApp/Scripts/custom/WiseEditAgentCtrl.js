mainApp.controller('editAgentController', function ($scope, $window, $routeParams, blockUI, AgentsService, FeeAgreementsService) {
    blockUI.start();

    AgentsService.GetAgentById($routeParams.agentId).then(function (agent) {
        $scope.agent = agent;
    }).catch(function (e) {
        alert('error');
    });

    FeeAgreementsService.GetAccountIdsFromAgreementsForAgent($routeParams.agentId).then(function (accounts) {
        $scope.accounts = accounts;
    }).catch(function (e) {
        alert('error');
    }).finally(function () {
        blockUI.stop();
    });

    //@@ On GridItem Selection
    $scope.$watch('mySelectedAccounts[0]', function (newVal, oldVal) {
        if (newVal == oldVal || !newVal)
            return;

        blockUI.start();

        FeeAgreementsService.GetFeesForAgentAndAccount($routeParams.agentId, newVal.Id).then(function (productsFees) {
            $scope.productsFees = productsFees;
        }).catch(function (e) {
            alert('error');
        }).finally(function () {
            blockUI.stop();
        });
    });

    $scope.UpdateAgentFees = function () {
        var agreements = [];

        $scope.productsFees.forEach(function (pf) {
            var updatedFee = angular.element(`#${pf.ProductName}`).val();

            agreements.push({
                Id: pf.AgreementId,
                AccountId: $scope.mySelectedAccounts[0].Id,
                ProductId: pf.ProductId,
                AgentId: $routeParams.agentId,
                Fee: updatedFee
            });

            pf.Fee = updatedFee;
        });

        blockUI.start();

        FeeAgreementsService.BulkUpsertAgreements(agreements).then(function () {
            alert('Agreements Successfully Updated');
        }).catch(function (e) {
            alert('error');
        }).finally(function () {
            blockUI.stop();
        });
    };
});