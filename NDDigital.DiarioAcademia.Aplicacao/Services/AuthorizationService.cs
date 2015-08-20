using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System.Collections.Generic;
using System;
using Microsoft.AspNet.Identity;
using System.Text;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface IAuthorizationService
    {
        void AddPermissionsToGroup(int id, string[] permissions);
        void RemovePermissionsFromGroup(int id, string[] permissions);

        void AddGroupToUser(string username, int[] groups);
        void RemoveGroupFromUser(string username, int[] groups);
    }

    public class AuthorizationService : IAuthorizationService
    {
        private IPermissionRepository _permissionRepository;
        private IGroupRepository _groupRepository;
        private UserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        public AuthorizationService(IGroupRepository groupRepository, IPermissionRepository permissionRepository, UserRepository userRepository, IUnitOfWork uow)
        {
            _permissionRepository = permissionRepository;
            _groupRepository = groupRepository;
            _unitOfWork = uow;
            _userRepository = userRepository;
        }

        public void AddPermissionsToGroup(int id,string[] permissions)
        {
            var groupEncontrado = _groupRepository.GetByIdIncluding(id,x=>x.Permissions);
            var listPermissions = _permissionRepository.GetAllSpecific(permissions);



            if (groupEncontrado != null)
            {
                foreach (var item in listPermissions)
                {
                    if (!groupEncontrado.Permissions.Contains(item))
                    {
                        groupEncontrado.Permissions.Add(item);
                    }
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

        public void AddGroupToUser(string username, int[] groups)
        {
            var userEncontrado = _userRepository.GetByUserName(username);
            var listGroups= _groupRepository.GetAllSpecific(groups);

            SetGroups(userEncontrado, listGroups);

            _userRepository.Update(userEncontrado);

            _unitOfWork.Commit();
        }

        public void RemoveGroupFromUser(string username, int[] groups)
        {
            throw new NotImplementedException();
        }

        private void SetGroups(User userEncontrado,IList<Group>listGroups)
        {
            if (userEncontrado != null)
            {
                userEncontrado.Groups = userEncontrado.Groups ?? new List<Group>();
                foreach (var item in listGroups)
                {
                    if (!userEncontrado.Groups.Contains(item))
                    {
                        userEncontrado.Groups.Add(item);
                    }
                }
            }
        }





        
    }
}