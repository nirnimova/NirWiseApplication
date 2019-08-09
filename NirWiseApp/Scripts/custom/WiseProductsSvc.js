mainApp.service('ProductsService', function ($http, $q) {
    this.GetInitData = function () {
        var deferred = $q.defer();

        setTimeout(function () {
            $http.get('/odata/WiseProducts').then(function (result) {
                deferred.resolve(result.data.value);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };

    this.SetProduct = function (productName) {
        var deferred = $q.defer();

        var product = {
            Name: productName
        };

        setTimeout(function () {
            $http.post('/odata/WiseProducts', JSON.stringify(product)).then(function (result) {
                deferred.resolve(result.data.value);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };
});