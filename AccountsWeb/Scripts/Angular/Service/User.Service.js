(function () {
    'use strict';

    angular
        .module('App')
        .factory('UserService', UserService);

    UserService.$inject = ['$http'];

    function UserService($http) {
        return {
            Read: Read,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/User/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(userId) {

            var ok = confirm("Are you sure to delete this item?");

            if (ok == true) {

                return $http({
                    method: 'DELETE',
                    url: '/User/Delete/' + userId,
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                });
            }
        }
    }
})();