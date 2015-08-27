using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Common;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories;
using Ninject.Modules;

namespace NDDigital.DiarioAcademia.Infraestrutura.SQL.Modules
{
    public class AdoNetNinjectModule : NinjectModule
    {
        public override void Load()
        {
            var factory = new AdoNetFactory();

            Bind<IUnitOfWork>().To<ADOUnitOfWork>().WithConstructorArgument("factory", factory);
            Bind<ITurmaRepository>().To<TurmaRepositorySql>().WithConstructorArgument("factory", factory);
            Bind<IAulaRepository>().To<AulaRepositorySql>().WithConstructorArgument("factory", factory);
            Bind<IAlunoRepository>().To<AlunoRepositorySql>().WithConstructorArgument("factory", factory);
            Bind<IPresencaRepository>().To<PresencaRepositorySql>().WithConstructorArgument("factory", factory);
        }
    }
}