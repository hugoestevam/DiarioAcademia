using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
   public  interface IGroupService : IService<Group>
    {
    }


    public class GroupService :IGroupService
    {
        private UnitOfWork _uow;
        IGroupRepository _repo;


        public GroupService(IGroupRepository repo, UnitOfWork uow)
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
            _uow.Commit();
            _repo.Delete(id);
        }

        public void Update(Dominio.Entities.Security.Group obj)
        {
            _uow.Commit();
             _repo.Update(obj);
        }

        IList<Dominio.Entities.Security.Group> IService<Dominio.Entities.Security.Group>.GetAll()
        {
             return _repo.GetAll(); throw new NotImplementedException();
        }

        Dominio.Entities.Security.Group IService<Dominio.Entities.Security.Group>.GetById(int id)
        {
             return _repo.GetById(id);  throw new NotImplementedException();
        }
    }




}
