using Infrasctructure.DAO.ORM.Contexts;
using Infrastructure.DAO.ORM.Common;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using System;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Common
{
    public class EntityFrameworkFactory : UnitOfWorkFactory, IDisposable
    {
        private EntityFrameworkContext dataContext;

        public override IUnitOfWork Create()
        {
            return new EntityFrameworkUnitOfWork(null);
        }

        public EntityFrameworkContext Get()
        {
            return dataContext ?? (dataContext = new EntityFrameworkContext());
        }

        public void Dispose()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}