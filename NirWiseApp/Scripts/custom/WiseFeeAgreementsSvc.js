mainApp.service('FeeAgreementsService', function ($http, $q) {
    this.UpsertAgreement = function (agentId, productId, accountId, fee) {
        var deferred = $q.defer();

        var agreement = {
            AccountId: accountId,
            ProductId: productId,
            AgentId: agentId,
            Fee: fee
        };

        setTimeout(function () {
            $http.post('/api/WiseFeeAgreements/UpsertAgreement', JSON.stringify(agreement)).then(function (result) {
                deferred.resolve(result.data.value);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };

    this.BulkUpsertAgreements = function (agreement) {
        var deferred = $q.defer();

        setTimeout(function () {
            $http.post('/api/WiseFeeAgreements/BulkUpsertAgreements', JSON.stringify(agreement)).then(function (result) {
                deferred.resolve(result.data.value);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };

    this.GetAccountIdsFromAgreementsForAgent = function (agentId) {
        var deferred = $q.defer();

        setTimeout(function () {
            $http.get(`/api/WiseFeeAgreements/GetAccountsFromAgreementsForAgent?agentId=${agentId}`).then(function (result) {
                deferred.resolve(result.data.Data);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };

    this.GetFeesForAgentAndAccount = function (agentId, accountId) {
        var deferred = $q.defer();

        setTimeout(function () {
            $http.get(`/api/WiseFeeAgreements/GetFeesForAgentAndAccount?agentId=${agentId}&accountId=${accountId}`).then(function (result) {
                deferred.resolve(result.data.Data);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };

    this.GetAccountAndAgentNamesForProduct = function (productId) {
        var deferred = $q.defer();

        setTimeout(function () {
            $http.get(`/api/WiseFeeAgreements/GetAccountAndAgentNamesForProduct?productId=${productId}`).then(function (result) {
                deferred.resolve(result.data.Data);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };
});