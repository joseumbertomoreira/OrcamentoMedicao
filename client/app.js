let app = angular.module('appAdress', ["ngRoute"]);

app.config(function($routeProvider){
	$routeProvider.when('/', {
			controller: 'formController',
			templateUrl: 'views/form.html',
			reloadOnSearch: false
	})
}).run(function($http) {
	$http.defaults.headers.post['Content-Type'] = 'application/json';
});