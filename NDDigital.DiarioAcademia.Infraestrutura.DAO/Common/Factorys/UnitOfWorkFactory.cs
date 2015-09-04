using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;

namespace NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys
{
    public abstract class UnitOfWorkFactory 
    {
        public abstract IUnitOfWork Create();
    }
}