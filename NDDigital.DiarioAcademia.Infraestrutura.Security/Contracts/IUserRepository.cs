using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
