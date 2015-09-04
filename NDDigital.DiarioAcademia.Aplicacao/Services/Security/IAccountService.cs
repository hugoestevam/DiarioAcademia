using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface IAccountService: IService<Account>
    {
    }

    public class AccountService : IAccountService
    {
        private IUnitOfWork _uow;
        private IAccountRepository _repo;

        public AccountService(IAccountRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public void Add(Account obj)
        {
            _repo.Add(obj);
            _uow.Commit();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
            _uow.Commit();
        }

        public void Update(Account obj)
        {
            _repo.Update(obj);
            _uow.Commit();
        }

        IList<Account> IService<Account>.GetAll()
        {
            return _repo.GetAllIncluding(g => g.Groups);
        }

        Account IService<Account>.GetById(int id)
        {
            return _repo.GetByIdIncluding(id, g => g.Groups);
        }
    }
}