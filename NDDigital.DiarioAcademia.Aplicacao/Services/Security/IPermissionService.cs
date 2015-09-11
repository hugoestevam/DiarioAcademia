using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface IPermissionService : IService<Permission>
    {
        Permission GetByPermissionId(string id);

        IList<Permission> GetByUser(string username);

        IList<Permission> GetByGroup(int groupId);
    }

    public class PermissionService : IPermissionService
    {
        private IUnitOfWork _uow;
        private IPermissionRepository _repo;

        public PermissionService(IPermissionRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public void Add(Permission obj)
        {
            _repo.Add(obj);
            _uow.Commit();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
            _uow.Commit();
        }

        public void Update(Permission obj)
        {
            _repo.Update(obj);
            _uow.Commit();
        }

        IList<Permission> IService<Permission>.GetAll()
        {
            return _repo.GetAll(); throw new NotImplementedException();
        }

        Permission IService<Permission>.GetById(int id)
        {
            return _repo.GetById(id); throw new NotImplementedException();
        }

        public Permission GetByPermissionId(string id)
        {
            return (from p in _repo.GetAll() where p.PermissionId == id select p).FirstOrDefault();
        }

        public IList<Permission> GetByUser(string username)
        {
            return _repo.GetByUser(username);
        }

        public IList<Permission> GetByGroup(int groupId)
        {
            return _repo.GetByGroup(groupId);
        }
    }
}