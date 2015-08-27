using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Dominio.Contracts
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetByUserName(string username);
    }
}