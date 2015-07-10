using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Common
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DiarioAcademiaContext dataContext;

        public DiarioAcademiaContext Get()
        {
            return dataContext ?? (dataContext = new DiarioAcademiaContext());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}