using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using System;

namespace NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys
{
    public abstract class UnitOfWorkFactory
    {
        public abstract IUnitOfWork Create();
    }
}