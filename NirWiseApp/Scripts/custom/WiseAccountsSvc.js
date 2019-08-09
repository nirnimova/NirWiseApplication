mainApp.service('AccountsService', function ($http, $q) {
    this.InitData = function () {
        var deferred = $q.defer();

        setTimeout(function () {
            $http.get('/odata/WiseAccounts').then(function (result) {
                deferred.resolve(result.data.value);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };

    this.AddNewAccount = function (newAccount) {
        var deferred = $q.defer();

        setTimeout(function () {
            $http.post('/odata/WiseAccounts', JSON.stringify(newAccount)).then(function (result) {
                deferred.resolve(result.data.value);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };

    this.SearchWiseAccounts = function (searchAccount) {
        var deferred = $q.defer();

        setTimeout(function () {
            $http.post('/api/WiseAccountsExt/SearchWiseAccounts', JSON.stringify(searchAccount)).then(function (result) {
                deferred.resolve(result.data.Data);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };

    this.SearchTopWiseAccounts = function (searchAccount, topAccountResults) {
        var deferred = $q.defer();

        var data = {
            Account: searchAccount,
            TopResults: topAccountResults
        };

        setTimeout(function () {
            $http.post('/api/WiseAccountsExt/SearchTopWiseAccounts', JSON.stringify(data)).then(function (result) {
                deferred.resolve(result.data.Data);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };
});