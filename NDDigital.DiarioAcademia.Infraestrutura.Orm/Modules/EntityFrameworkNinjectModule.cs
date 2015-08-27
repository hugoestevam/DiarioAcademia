using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using Ninject.Modules;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Modules
{
    public class EntityFrameworkNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITurmaRepository>().To<TurmaRepositoryEF>();
            Bind<IAulaRepository>().To<AulaRepositoryEF>();
            Bind<IAlunoRepository>().To<AlunoRepositoryEF>();
            Bind<IPresencaRepository>().To<PresencaRepositoryEF>();

            Bind<IAccountRepository>()
              .To<AccountRepository>();
            Bind<IGroupRepository>()
              .To<GroupRepository>();
            Bind<IPermissionRepository>()
              .To<PermissionRepository>();
          


        }
    }
}