using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{
    public interface IPermissionRepository : IRepository<Permission>
    {        
       // void GetByGroup(Group administrador);
    }

    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {

        public PermissionRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

        //public IList<Permission> GetByGroup(Group administrador)
        //{ 
        //    try
        //    {
        //         _context.Permissions.ToList().Where(c => c.);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}TODO: Implementar
    }
}