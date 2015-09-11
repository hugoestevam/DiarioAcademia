using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System.Collections.Generic;
using System;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface IGroupService : IService<Group>
    {
        IList<Group> GetByUser(string username);
        bool isAdmin(string username);
    }

    public class GroupService : IGroupService
    {
        private IUnitOfWork _uow;
        private IGroupRepository _repo;

        public GroupService(IGroupRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public void Add(Group obj)
        {
            _repo.Add(obj);
            _uow.Commit();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
            _uow.Commit();
        }

        public void Update(Group obj)
        {
            _repo.Update(obj);
            _uow.Commit();
        }

        IList<Group> IService<Group>.GetAll()
        {
            return _repo.GetAllIncluding(g => g.Permissions);
        }

       Group IService<Group>.GetById(int id)
        {
            return _repo.GetByIdIncluding(id, g => g.Permissions);
        }

        public IList<Group> GetByUser(string username)
        {
            return _repo.GetByUser(username);
        }

        public bool isAdmin(string username)
        {
            return _repo.IsAdmin(username);
        }
    }
}