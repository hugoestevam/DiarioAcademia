(function () {
    angular.module('factories.module').factory('permissions.factory', permissionValue);

    permissionValue.$inject = ['$state'];

    function permissionValue($state) {

        return {
            getPermissions: getPermissions,
            getPermissionById: getPermissionById,
            getCustomPermissions: getCustomPermissions,
            getDefaultPermissions: getDefaultPermissions
        }


        //public methods
        function getPermissions() {
            var permissions = getDefaultPermissions();
            permissions.join(getCustomPermissions()); // join 'states permissions' with 'custom permissions'
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


        //private methods
        function getCustomPermissions() {
            var customPermissions = [
                { name: "Excluir Aluno", permissionId: '20' },
                { name: "Adicionar Turma", permissionId: '20' }];

            return customPermissions;
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
                permissionId: state.data.$$permissionId
            };
        }
    }
})(window.angular);


