using Infrastructure.DAO.ORM.Common.Base;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System.Collections.Generic;
using System.Linq;
using System;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{


    public class AccountRepository : RepositoryBaseEF<Account>, IAccountRepository
    {
        private IUnitOfWork uow;

        public AccountRepository(EntityFrameworkFactory dbFactory)
         : base(dbFactory)
        {
        }

        public Account GetByUserName(string username)
        {
            return (from c in DataContext.Accounts where c.Username == username select c).FirstOrDefault();
        }
    }
}