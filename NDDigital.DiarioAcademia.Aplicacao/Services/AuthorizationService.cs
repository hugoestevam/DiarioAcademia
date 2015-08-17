using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System.Collections.Generic;
using System;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface IAuthorizationService
    {
        void AddPermissionsGroup(int id, string[] permissions);
        void AddPermissionsGroup(Group group, string[] permissions);
        void RemovePermissionsGroup(int id, string[] permissions);
    }

    public class AuthorizationService : IAuthorizationService
    {
        private IPermissionRepository _permissionRepository;
        private IGroupRepository _groupRepository;
        private UserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        public AuthorizationService(IGroupRepository groupRepository, IPermissionRepository permissionRepository, IUnitOfWork uow)
        {
            _permissionRepository = permissionRepository;
            _groupRepository = groupRepository;
            _unitOfWork = uow;
        }

        public void AddPermissionsGroup(int id,string[] permissions)
        {
            var groupEncontrado = _groupRepository.GetByIdIncluding(id);
            var listPermissions = _permissionRepository.GetAllSpecific(permissions);

            if (groupEncontrado != null)
                groupEncontrado.Permissions.AddRange(listPermissions);

            _groupRepository.Update(groupEncontrado);

            _unitOfWork.Commit();
        }

        public void AddPermissionsGroup(Group group, string[] permissions)
        {
            //_groupRepository.IsEntry(group);

            AddPermissionsGroup(group.Id,permissions);
        }

        public void RemovePermissionsGroup(int id, string[] permissions)
        {
            var groupEncontrado = _groupRepository.GetByIdIncluding(id);

            foreach (var permId in permissions)
            {
                for (var i=0; i<groupEncontrado.Permissions.Count;i++)
                {
                    var per = groupEncontrado.Permissions[i];  

                    if (per.PermissionId == permId)
                    {
                        groupEncontrado.Permissions.Remove(per);i--;
                    }
                }
            }

            _groupRepository.Update(groupEncontrado);

            _unitOfWork.Commit();
        }
    }
}