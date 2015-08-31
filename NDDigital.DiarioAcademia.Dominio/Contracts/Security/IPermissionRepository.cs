using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Dominio.Contracts
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        IList<Permission> GetByGroup(int groupId);

        IList<Permission> GetAllSpecific(string[] permissions);

        Permission GetByPermissionId(string v);
  
    }
}