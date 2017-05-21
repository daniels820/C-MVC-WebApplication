app.controller('TableCtrl', function ($scope, deviceFactory ,$http) {


    $scope.updateBool = false;
    var editindex = 0;
    $scope.sortType = 'Name';
    $scope.sortReverse = false;
    $scope.searchFish = '';

    var myModel = new MyList();
   // $scope.people = MyList;
    $scope.DeviceByName = [];
    $scope.people = [];


    // on start
      deviceFactory.DeviceList().then(
        // callback function for successful http request
        function success(response) {
            $scope.people = response.data;
            console.log($scope.people);
        },
        // callback function for error in http request
        function error(response) {
            // log errors
        }
    );

    
    $scope.GetAllDevices = function () {
        
        deviceFactory.GetAllDevices().then(
            // callback function for successful http request
            function success(response) {
              
                console.log($scope.people);
                 $scope.people = response.data;
              //   $scope.$apply();
                // $scope.$digest();
         //        $route.reload();
                
            },
            // callback function for error in http request
            function error(response) {
                // log errors
            }
        );
       
    };


    $scope.DeviceByOwnerName = function (OwnerName) {
 
        deviceFactory.DeviceByOwnerName(OwnerName).then(
            // callback function for successful http request
            function success(response) {
             
                
   
                $scope.DeviceByName = response.data;
                console.log($scope.DeviceByName);

                //    $scope.$apply();
                //    $scope.$digest();
      //              $route.reload();
            },
            // callback function for error in http request
            function error(response) {
                // log errors
            }
        );
      

    }




    /* 
    var people =  $.getJSON("test.json" , function(  data ) {
     return data;
    });
    function loadData () {
        var httpRequest = $http({
            method: 'POST',
            url: 'test.json',
            data: people

        }).success(function (data, status) {
            $scope.people = data;
        });
    }
    loadData();
    */

    $scope.addNewRow = function(){
        $scope.addingNewRow = true ;
    };


    $scope.addRow = function(){

        $scope.people.push({ 'Name':$scope.name, 'Address': $scope.Address, 'Phone Number':$scope.PhoneNumber, 'Image URL':$scope.Img });
        $scope.name='';
        $scope.Address='';
        $scope.PhoneNumber='';
        $scope.Img='';
        $scope.addingNewRow = false ;




        var t = document.getElementsByTagName('table');
        console.log(t);


        //$scope.$apply();
        console.log($scope.people);
    };

    $scope.delete = function (person) {
        $scope.people.splice($scope.people.indexOf(person),1);
        // debugger;
        
    };

    $scope.editContent = function (p) {
        $scope.addingNewRow = false;
        $scope.updateBool = true;
        ExPerson = p;
        $scope.editablerow = '';
        $scope.editablerow = angular.copy(p);
    };

    $scope.saveData = function (editablerow) {
        // console.log(ExPerson );
        // console.log(editablerow);
        var index = $scope.people.indexOf(ExPerson);
        $scope.people[index] = angular.copy($scope.editablerow);
        // console.log($scope.people);
        $scope.cancel();
    };

    $scope.cancel = function(){
        $scope.addingNewRow = false;
        $scope.updateBool = false;
        $scope.editablerow = [];
    };

    $scope.reset = function () {
        $.getJSON( "assets/json/people.json" , function( data ) {
            console.log(data);
            $scope.people = data;


            var httpRequest = $http({
                method: 'DELETE',
                url: 'test.json',
                data: people

            }).success(function (data, status) {
                $scope.people = data;
            });


        });

    };

    //TODO validation media queries for toolbar 


});

function MyList() {
    var _this = this;










    _this.updateNumber = function () {
        _this.number += 1;
        alert('new number should display ' + _this.number);
    }

    return _this;
}
