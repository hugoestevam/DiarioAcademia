(function (angular) {
    'use strict';
    var KEYS = angular.injector(['common.module']).get('CONSTANT_KEYS');

    angular
        .module('routes.module')
        .config(configRoutes);

    configRoutes.$inject = [KEYS.APP_ROUTES];

    function configRoutes(routes) {
        routes.push({
            name: 'manager',
            url: '/manager',
            templateUrl: '/app/templates/components/inner-view.html',
            redirect: '/manager/user',
            displayName: "Gerenciador",
            displayIcon: 'fa-wrench',
            $$permissionId: "11"
        }, {
            name: 'manager.user',
            url: '/user',
            templateUrl: '/app/views/manager/user/manager-user-list.html',
            controller: "managerUserListController as vm",
            displayName: "Usuario",
            displayIcon: 'fa-user',
            $$permissionId: "12"
        }, {
            name: 'manager.useredit',
            url: '/edit/user/:userId',
            templateUrl: '/app/views/manager/user/manager-user-edit.html',
            controller: "managerUserEditController as vm",
            displayName: "Edição de Usuário",
            displayIcon: 'fa-pencil',
            $$permissionId: "13"
        }, {
            name: 'manager.userGroupEdit',
            url: '/group/edit/user/:userId',
            templateUrl: '/app/views/manager/user/manager-user-edit-group.html',
            controller: "managerUserEditGroupController as vm",
            displayName: "Edição de Grupos de Usuário",
            displayIcon: 'fa-pencil',
            $$permissionId: "14"
        }, {
            name: 'manager.group',
            url: '/group',
            templateUrl: '/app/views/manager/group/manager-group-list.html',
            controller: "managerGroupListController as vm",
            displayName: "Grupo",
            displayIcon: 'fa-users',
            $$permissionId: "15"
        }, {
            name: 'manager.group.edit',
            url: '/edit/:groupId',
            templateUrl: '/app/views/manager/group/manager-group-edit.html',
            controller: "managerGroupEditController as vm",
            displayName: "Edição de Grupo",
            displayIcon: 'fa-pencil',
            $$permissionId: "16"
        }, {
            name: 'manager.groupPermissionsEdit',
            url: '/group/edit/permissions/:groupId',
            templateUrl: '/app/views/manager/group/manager-group-permission-edit.html',
            controller: "managerGroupPermissionEditController as vm",
            displayName: "Edição de Permissões de Grupo",
            displayIcon: 'fa-pencil',
            $$permissionId: "17"
        }, {
            name: 'manager.permissions',
            url: '/permissions',
            templateUrl: '/app/views/manager/permission/manager-permission.html',
            controller: "managerPermissionController as vm",
            displayName: "Permissões",
            displayIcon: 'fa-key',
            $$permissionId: "18"
        })
    }

})(window.angular);