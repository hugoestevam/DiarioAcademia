using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contexts;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Common
{
    public class AuthFactory : UnitOfWorkFactory
    {
        private AuthContext dataContext;

        public void Dispose()
        {
            // dataContext?.Dispose(); todo: c# 6
            if (dataContext != null)
                dataContext.Dispose();
        }

        public override IUnitOfWork Create()
        {
            return new AuthUnitOfWork(null);
        }

        public AuthContext Get()
        {
            if (dataContext == null)
            {
                dataContext = new AuthContext();
            }
            return dataContext;
        }
    }
}