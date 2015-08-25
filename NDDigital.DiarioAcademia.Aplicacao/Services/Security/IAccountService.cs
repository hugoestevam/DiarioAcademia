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
    public interface IAccountService : IService<Account>
    {
        List<Group> FindGroupByUsername(string username);
    }


    public class AccountService : IAccountService
    {
        AccountRepository _repo;

        public AccountService(AccountRepository repo)
        {
            _repo = repo;
        }

        public void Add(Account obj)
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

        public IList<Account> GetAll()
        {
            return _repo.GetUsers();
        }

        public Account GetById(int id)
        {
            return _repo.GetUserById(id.ToString());//TODO
        }

        public Account GetById(string id)
        {
            return _repo.GetUserById(id);
        }

        public void Update(Account obj)
        {
            throw new NotImplementedException(); ;
        }
    }




}
