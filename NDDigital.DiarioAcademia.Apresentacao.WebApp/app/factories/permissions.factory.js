﻿(function () {
    angular.module('factories.module')
        .factory('permissions.factory', permissionFactory);

    permissionFactory.$inject = ['$state', 'compareState', 'permissionGroups'];

    function permissionFactory($state, compareState, permissionGroups) {

        return {
            getPermissions: getPermissions,
            getPermissionById: getPermissionById,
            getCustomPermissions: getCustomPermissions,
            getDefaultPermissions: getDefaultPermissions,
            getFilters: getFilters,
            createPermission: createPermission,
            filterPermissions: filterPermissions,
            containsPermissionByName: containsPermissionByName,
            getByName: getByName
        };

        //private methods
        function getCustomPermissions() {
            var customPermissions = [
                { name: "action.deleteAluno", displayName: "Excluir Aluno", permissionId: '27' },
                { name: "action.deleteTurma", displayName: "Excluir Turma", permissionId: '28' }];
            return customPermissions;
        }

        function getFilter(name) {
            if (permissionGroups.contains(name))
                return name;
            var filter = name.split(".");
            filter = filter.length >= 2 ? filter[0] : undefined;
            return filter;
        }

        //public methods
        function getPermissions() {
            var permissions = getDefaultPermissions();
            permissions = permissions.concat(getCustomPermissions()); // join 'states permissions' with 'custom permissions'
            return permissions; // all permissions
        }

        function getPermissionById(id) {
            var permissions = getPermissions();
            for (var i in permissions) {
                if (permissions[i].permissionId == id)
                    return permissions[i];
            }
            return undefined;
        }


        function getDefaultPermissions() {
            var states = $state.get();
            var filtered = [];
            for (var i = 0; i < states.length; i++) {
                var state = states[i];
                if (state.abstract) {
                    states.splice(i, 1);
                    i--;
                    continue;
                }
                filtered.push(createPermission(state)); // parse state for permission
            }
            return filtered;
        }

        function createPermission(state) {
            return {
                name: state.name,
                displayName: state.data.displayName,
                permissionId: state.data.$$permissionId,
                parent: state.parent || ""
            };
        }

        function filterPermissions(permissionDb) {

            var permissions = getPermissions();
            var filtered = [];
            var countCheck = 0;
            var filter;
            var permission;

            for (var i = 0; i < permissions.length; i++) {
                permission = permissions[i];
                filter = getFilter(permission.name);
                if (!filter)
                    continue;
                if (!filtered[filter])
                    filtered[filter] = [];
                filtered[filter].push(permission);
                if (compareState(permissionDb, permission) >= 0)
                    filtered[filter].countSelected = filtered[filter].countSelected ? filtered[filter].countSelected + 1 : 1;
                if (!permissionGroups.contains(filter))
                    permissionGroups.push(filter);
            }
            return filtered;
        }

        function getFilters() {
            return permissionGroups;
        }

        function getByName(permissions, name) {
            if (!permissions)
                return undefined;
            for (var i = 0; i < permissions.length; i++) {
                if (permissions[i].indexOf(name) >= 0)
                    return permissions[i];
            }
            return undefined;
        }

        function containsPermissionByName(permissions, name) {           
            return getByName(permissions, name) != undefined;
        }

    }
})(window.angular);


