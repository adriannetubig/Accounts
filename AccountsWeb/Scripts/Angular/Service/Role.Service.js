(function () {
    'use strict';

    angular
        .module('App')
        .factory('RoleService', RoleService);

    RoleService.$inject = ['$http'];

    function RoleService($http) {
        return {
            Read: Read,
            ReadAssignedRole: ReadAssignedRole,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Role/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadAssignedRole(userId) {
            return $http({
                method: 'POST',
                url: '/Role/ReadAssignedRole/' + userId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(roleId) {

            var ok = confirm("Are you sure to delete this role?");

            if (ok == true) {

                return $http({
                    method: 'DELETE',
                    url: '/Role/Delete/' + roleId,
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                });
            }
        }
    }
})();