(function (angular) {
    'use strict';
    var KEYS = angular.injector(['common.module']).get('CONSTANT_KEYS');

    angular
        .module('routes.module')
        .config(configRoutes);

    configRoutes.$inject = [KEYS.APP_ROUTES];

    function configRoutes(routes) {
        routes.push({
            state: 'manager',
            url: '/manager',
            templateUrl: '/app/templates/components/inner-view.html',
            'abstract': true,
            redirect: '/manager/user',
        }, {
            state: 'manager.user',
            url: '/user',
            templateUrl: '/app/views/manager/user/manager-user-list.html',
            controller: "managerUserListController as vm"
        }, {
            state: 'manager.useredit',
            url: '/edit/user/:userId',
            templateUrl: '/app/views/manager/user/manager-user-edit.html',
            controller: "managerUserEditController as vm"
        }, {
            state: 'manager.group',
            url: '/group',
            templateUrl: '/app/views/manager/group/manager-group.html',
            controller: "managerGroupListController as vm"
        }, {
            state: 'manager.group.edit',
            url: '/edit/:groupId',
            templateUrl: '/app/views/manager/group/manager-group-edit.html',
            controller: "managerGroupEditController as vm"
        }, {
            state: 'manager.permissions',
            url: '/permissions',
            templateUrl: '/app/views/manager/permission/manager-permission.html',
            controller: "managerPermissionController as vm"
        })
    }

})(window.angular);