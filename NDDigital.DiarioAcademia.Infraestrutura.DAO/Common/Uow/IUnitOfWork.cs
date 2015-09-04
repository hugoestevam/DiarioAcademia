using System;

namespace NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Rollback();
    }
    public interface IEntityFrameworkUnitOfWork : IUnitOfWork    {    }
    public interface IAuthUnitOfWork : IUnitOfWork    {    }
    public interface IAdoNetUnitOfWork : IUnitOfWork { }
}