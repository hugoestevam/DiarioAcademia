using Microsoft.AspNet.Identity;
using NDDigital.DiarioAcademia.Aplicacao.Services.Security;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    

    public class AuthorizationService : IAuthorizationService
    {
        private IPermissionRepository _permissionRepository;
        private IGroupRepository _groupRepository;
        private IAccountRepository _accountRepository;
        private IUnitOfWork _unitOfWork;

        public AuthorizationService(
            IGroupRepository groupRepository,
            IPermissionRepository permissionRepository,
            IAccountRepository accountRepository,
            IUnitOfWork uow)
        {
            _permissionRepository = permissionRepository;
            _groupRepository = groupRepository;
            _unitOfWork = uow;
            _accountRepository = accountRepository;
        }

        public void AddPermissionsToGroup(int id, string[] permissions)
        {
            var groupEncontrado = _groupRepository.GetByIdIncluding(id, x => x.Permissions);
            var listPermissions = _permissionRepository.GetAllSpecific(permissions);

            if (groupEncontrado != null)
            {
                foreach (var item in listPermissions)
                {
                    if (!groupEncontrado.Permissions.Contains(item))
                        groupEncontrado.Permissions.Add(item);

                }
            }
            _groupRepository.Update(groupEncontrado);

            _unitOfWork.Commit();
        }

        public void RemovePermissionsFromGroup(int id, string[] permissions)
        {
            var groupEncontrado = _groupRepository.GetByIdIncluding(id, x => x.Permissions);

            foreach (var permId in permissions)
            {
                var perm = groupEncontrado.Permissions.FirstOrDefault(p => p.PermissionId == permId);
                if (perm != null)
                {
                    groupEncontrado.Permissions.Remove(perm);
                };
            }
            _groupRepository.Update(groupEncontrado);

             _unitOfWork.Commit();
        }

        public void AddGroupToUser(string username, int[] groups)
        {
            var userEncontrado = _accountRepository.GetByUserName(username);

            var listGroups = _groupRepository.GetAllSpecific(groups);

            SetGroups(userEncontrado, listGroups);

            _accountRepository.Update(userEncontrado);

            _unitOfWork.Commit();
        }

        public void RemoveGroupFromUser(string username, int[] groups)
        {

            var userEncontrado = _accountRepository.GetByUserName(username);

            foreach (var groupId in groups)
            {
                var group = userEncontrado.Groups.FirstOrDefault(p => p.Id == groupId);
                if (group != null)
                    userEncontrado.Groups.Remove(group);
                
            }
            _accountRepository.Update(userEncontrado);
            _unitOfWork.Commit();
        }

        private void SetGroups(Account userEncontrado, IList<Group> listGroups)
        {
            if (userEncontrado != null)
            {
                userEncontrado.Groups = userEncontrado.Groups ?? new List<Group>();
                foreach (var item in listGroups)
                    if (!userEncontrado.Groups.Contains(item))
                        userEncontrado.Groups.Add(item);
            }
        }
    }
}