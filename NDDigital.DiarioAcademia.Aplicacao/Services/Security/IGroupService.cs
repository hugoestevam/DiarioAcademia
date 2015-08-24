﻿using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface IGroupService : IService<Group>
    {
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

        public void Add(Dominio.Entities.Security.Group obj)
        {
            _repo.Add(obj);
            _uow.Commit();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
            _uow.Commit();
        }

        public void Update(Dominio.Entities.Security.Group obj)
        {
            _repo.Update(obj);
            _uow.Commit();
        }

        IList<Dominio.Entities.Security.Group> IService<Dominio.Entities.Security.Group>.GetAll()
        {
            return _repo.GetAllIncluding(g => g.Permissions);
        }

        Dominio.Entities.Security.Group IService<Dominio.Entities.Security.Group>.GetById(int id)
        {
            return _repo.GetByIdIncluding(id, g => g.Permissions);
        }
    }
}