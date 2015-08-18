using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface IUserService : IService<User>
    {
        List<Group> FindGroupByUsername(string username);
    }


    public class UserService : IUserService
    {
        UserRepository _repo;

        public UserService(UserRepository repo)
        {
            _repo = repo;
        }

        public void Add(User obj)
        {
            _repo.CreateAsync(obj);
        }

        public void Delete(int id)
        {
            //_repo.Delete(id);
        }

        public List<Group> FindGroupByUsername(string username)
        {
            return _repo.GetGroupsByUser(username).ToList();
        }

        public IList<User> GetAll()
        {
            return _repo.GetUsers();
        }

        public User GetById(int id)
        {
            return _repo.GetUserById(id.ToString());//todo
        }

        public User GetById(string id)
        {
            return _repo.GetUserById(id);
        }

        public void Update(User obj)
        {
            throw new NotImplementedException(); ;
        }
    }




}
