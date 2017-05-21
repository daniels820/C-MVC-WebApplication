

    var serviceId = 'deviceFactory';

    angular.module('app').factory(serviceId, ['$http', deviceFactory]);

    function deviceFactory($http) {

        function GetAllDevices() {
            return $http.get('/api/device');
        }

        function DeviceByOwnerName(OwnerName) {
            //return $http({
            //    method: 'GET',
            //    url: '/api/DeviceByOwnerName/',
            //    params: OwnerName
            //});
            return $http.get('/api/DeviceByOwnerName/' + OwnerName);
        }

        function DeviceList(OwnerName) {
            return $http.get('/api/DeviceList');
        }

       


        var service = {
            GetAllDevices: GetAllDevices,
            DeviceByOwnerName: DeviceByOwnerName,
            DeviceList: DeviceList
        };

        return service;
    }
