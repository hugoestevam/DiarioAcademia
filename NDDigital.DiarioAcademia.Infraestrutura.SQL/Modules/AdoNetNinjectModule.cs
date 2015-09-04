using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Repositories;
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

            Bind<IAdoNetUnitOfWork>().To<ADOUnitOfWork>().WithConstructorArgument("factory", factory);
            Bind<ITurmaRepository>().To<TurmaRepositorySql>().WithConstructorArgument("factory", factory);
            Bind<IAulaRepository>().To<AulaRepositorySql>().WithConstructorArgument("factory", factory);
            Bind<IAlunoRepository>().To<AlunoRepositorySql>().WithConstructorArgument("factory", factory);
            Bind<IPresencaRepository>().To<PresencaRepositorySql>().WithConstructorArgument("factory", factory);

            var authFactory = new AuthFactory();
            Bind<IAuthUnitOfWork>().To<AuthUnitOfWork>().WithConstructorArgument("factory", authFactory);
            //Bind<IUserStore<User>>().To<IdentityUserStore>().WithConstructorArgument("factory", authFactory);
            Bind<IAccountRepository>().To<AccountRepository>().WithConstructorArgument("factory", authFactory);
            Bind<IGroupRepository>().To<GroupRepository>().WithConstructorArgument("factory", authFactory);
            Bind<IPermissionRepository>().To<PermissionRepository>().WithConstructorArgument("factory", authFactory);

        }
    }
}