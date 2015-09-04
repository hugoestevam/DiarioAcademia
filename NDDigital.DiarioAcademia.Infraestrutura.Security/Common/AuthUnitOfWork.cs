using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Common
{
    public class AuthUnitOfWork : IAuthUnitOfWork
    {
        private AuthContext dbContext = null;

        private readonly AuthFactory dbFactory;

        protected AuthContext DbContext
        {
            get
            {
                return dbContext ?? dbFactory.Get() as AuthContext;
            }
        }

        public AuthUnitOfWork(AuthFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public void Rollback()
        {
            DbContext.Dispose();
        }
    }
}
