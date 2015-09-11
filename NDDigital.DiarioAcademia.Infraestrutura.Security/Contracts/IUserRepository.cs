using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts
{
    public interface IUserRepository
    {
        IList<User> GetUsersByGroup(Group group);

        IList<Group> GetGroupsByUser(string username);

        IList<User> GetUsers();

        User GetUserById(string id);

        User GetUserByUsername(string username);

        void Delete(string username);

        void AddUser(User user);
    }
}