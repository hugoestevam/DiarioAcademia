using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Dominio.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        IList<User> GetUsersByGroup(Group group);

        IList<Group> GetGroupsByUser(string username);

        IList<User> GetUsers();

        User GetUserById(string id);

        User GetUserByUsername(string username);

        void Delete(string username);
    }
}