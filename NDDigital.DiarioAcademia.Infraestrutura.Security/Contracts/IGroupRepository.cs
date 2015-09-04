using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts
{
    public interface IGroupRepository : IRepository<Group>
    {
        IList<Group> GetAllSpecific(int[] groups);
    }
}
