mainApp.service('AgentsService', function ($http, $q) {
    this.InitData = function () {
        var deferred = $q.defer();

        setTimeout(function () {
            $http.get('/odata/WiseAgents').then(function (result) {
                deferred.resolve(result.data.value);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };

    this.GetAgentById = function (agentId) {
        var deferred = $q.defer();

        setTimeout(function () {
            $http.get(`/odata/WiseAgents(${agentId})`).then(function (result) {
                deferred.resolve(result.data);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };

    this.AddNewAgent = function (newAgent) {
        var deferred = $q.defer();

        setTimeout(function () {
            $http.post('/odata/WiseAgents', JSON.stringify(newAgent)).then(function (result) {
                deferred.resolve(result.data.Id);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };

    this.SearchWiseAgents = function (searchAgent) {
        var deferred = $q.defer();

        setTimeout(function () {
            $http.post('/api/WiseAgentsExt/SearchWiseAgents', JSON.stringify(searchAgent)).then(function (result) {
                deferred.resolve(result.data.Data);
            }).catch(function () {
                deferred.reject();
            });
        }, 1000);

        return deferred.promise;
    };
});