using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface IAuthorizationService
    {
        void AddPermissionsGroup(int id);
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

        public void AddPermissionsGroup(int id)
        {
            var groupEncontrado = _groupRepository.GetById(id);
            var listPermissions = _permissionRepository.GetAll();

            if (groupEncontrado != null)
                groupEncontrado.Permissions.AddRange(listPermissions);

            _groupRepository.Update(groupEncontrado);

            _unitOfWork.Commit();
        }
    }
}