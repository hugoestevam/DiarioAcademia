using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetByUserName(string username);
    }
}