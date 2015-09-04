using Infrastructure.DAO.ORM.Common;
using Microsoft.AspNet.Identity;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Modules;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Repositories;
using Ninject.Modules;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Modules
{
    public class EntityFrameworkNinjectModule : NinjectModule
    {
        public override void Load()
        {

            var entityFrameworkFactory = new EntityFrameworkFactory();

            Bind<IEntityFrameworkUnitOfWork>().To<EntityFrameworkUnitOfWork>().WithConstructorArgument("factory", entityFrameworkFactory);
            Bind<ITurmaRepository>().To<TurmaRepositoryEF>().WithConstructorArgument("factory", entityFrameworkFactory);
            Bind<IAulaRepository>().To<AulaRepositoryEF>().WithConstructorArgument("factory", entityFrameworkFactory);
            Bind<IAlunoRepository>().To<AlunoRepositoryEF>().WithConstructorArgument("factory", entityFrameworkFactory);
            Bind<IPresencaRepository>().To<PresencaRepositoryEF>().WithConstructorArgument("factory", entityFrameworkFactory);


            //todo: new AuthNinjectModule().Load();

            var authFactory = new AuthFactory();
          
            Bind<IAuthUnitOfWork>().To<AuthUnitOfWork>().WithConstructorArgument("factory", authFactory);
            Bind<IUserStore<User>>().To<IdentityUserStore>().WithConstructorArgument("factory", authFactory);
            Bind<IAccountRepository>().To<AccountRepository>().WithConstructorArgument("factory", authFactory);
            Bind<IGroupRepository>().To<GroupRepository>().WithConstructorArgument("factory", authFactory);
            Bind<IPermissionRepository>().To<PermissionRepository>().WithConstructorArgument("factory", authFactory);

        }
    }
}