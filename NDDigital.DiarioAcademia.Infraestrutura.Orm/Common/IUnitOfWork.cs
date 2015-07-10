namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Common
{
    public interface IUnitOfWork
    {
        void Commit();

        void CommitAndRefreshChanges();
    }
}