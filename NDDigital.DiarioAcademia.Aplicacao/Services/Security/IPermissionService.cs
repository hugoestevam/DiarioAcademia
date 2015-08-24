using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface IPermissionService : IService<Permission>
    {
        Permission GetByPermissionId(string id);
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

        public void Add(Dominio.Entities.Security.Permission obj)
        {
            _repo.Add(obj);
            _uow.Commit();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
            _uow.Commit();
        }

        public void Update(Dominio.Entities.Security.Permission obj)
        {
            _repo.Update(obj);
            _uow.Commit();
        }

        IList<Dominio.Entities.Security.Permission> IService<Dominio.Entities.Security.Permission>.GetAll()
        {
            return _repo.GetAll(); throw new NotImplementedException();
        }

        Dominio.Entities.Security.Permission IService<Dominio.Entities.Security.Permission>.GetById(int id)
        {
            return _repo.GetById(id); throw new NotImplementedException();
        }

        public Permission GetByPermissionId(string id)
        {
            return (from p in _repo.GetAll() where p.PermissionId == id select p).First();
        }
    }
}