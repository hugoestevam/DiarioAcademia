using Infrastructure.DAO.ORM.Common;
using Microsoft.AspNet.Identity;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using Ninject.Modules;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Modules
{
    public class EntityFrameworkNinjectModule : NinjectModule
    {
        public override void Load()
        {

            var factory = new EntityFrameworkFactory();

            Bind<IUnitOfWork>().To<EntityFrameworkUnitOfWork>().WithConstructorArgument("factory", factory);
            Bind<ITurmaRepository>().To<TurmaRepositoryEF>().WithConstructorArgument("factory", factory);
            Bind<IAulaRepository>().To<AulaRepositoryEF>().WithConstructorArgument("factory", factory);
            Bind<IAlunoRepository>().To<AlunoRepositoryEF>().WithConstructorArgument("factory", factory);
            Bind<IPresencaRepository>().To<PresencaRepositoryEF>().WithConstructorArgument("factory", factory);

            Bind<IUserStore<User>>().To<MyUserStore>().WithConstructorArgument("factory", factory);
            Bind<IAccountRepository>().To<AccountRepository>().WithConstructorArgument("factory", factory);
            Bind<IGroupRepository>().To<GroupRepository>().WithConstructorArgument("factory", factory);
            Bind<IPermissionRepository>().To<PermissionRepository>().WithConstructorArgument("factory", factory);

        }
    }
}