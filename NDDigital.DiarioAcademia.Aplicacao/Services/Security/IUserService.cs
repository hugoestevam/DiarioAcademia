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
        List<Group> FindGroupByUsername();
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
          //  _repo.Create(obj);
        }

        public void Delete(int id)
        {
          //  _repo.Delete(id);
        }

        public List<Group> FindGroupByUsername()
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAll()
        {
            return null; // _repo.GetAll();
        }

        public User GetById(int id)
        {
            return null;// _repo.GetById(id);
        }

        public void Update(User obj)
        {
           // _repo.Update(obj);
        }
    }




}
