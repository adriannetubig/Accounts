(function () {
    'use strict';

    angular
        .module('App')
        .controller('RoleController', RoleController);

    RoleController.$inject = ['$filter', '$window', 'RoleService'];

    function RoleController($filter,$window, RoleService) {
        var vm = this;

        vm.UserId;
        
        vm.AssignedRoles = [];
        vm.Roles = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;
        vm.UpdateRole = UpdateRole;
        vm.Delete = Delete;

        function Initialise(userId) {
            vm.UserId = userId;
            Read();
            if (vm.UserId !== undefined)
            ReadAssignedRole();
        }
        function GoToUpdatePage(roleId) {
            $window.location.href = '../Role/Update/' + roleId;
        }
        function UpdateRole(role) {
            role.AssignedRoles = $filter('filter')(vm.AssignedRoles, { roleId: role.RoleId })[0];
        }
        function Read() {
            RoleService.Read()
                .then(function (response) {
                    vm.Roles = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }
        function ReadAssignedRole() {
            RoleService.ReadAssignedRole(vm.UserId)
                .then(function (response) {
                    vm.AssignedRoles = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function Delete(roleId) {
            RoleService.Delete(roleId)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }
    }
})();