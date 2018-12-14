'use strict';

app.controller('formController', function($scope, $http) {

	let addressJson = {};
	$scope.alert = false;
	$scope.districtIf = false;

	$scope.submit = (street, district) =>{
		console.log(street, district)
		$http.post('/form', {"street":street, "district": district})
	    .then(function (success) {

	    	if(success.data){
	    		$scope.districtObj = success.data;
	    		console.log('oi', $scope.districtObj);
	    		$scope.districtIf = true;
	    		$scope.alert = false;
	    	}else{
	    		$scope.districtIf = false;
	    		$scope.alert = true;
	    	}
	  	})

	}


});