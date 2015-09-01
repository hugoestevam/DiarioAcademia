using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using Infrastructure.DAO.ORM.Common;

namespace NDDigital.DiarioAcademia.IntegrationTests.Base
{
    public class BaseSecurityTest: BaseEntityFrameworkTest
    {

        protected IPermissionRepository PermissionRepository;
        protected IGroupRepository GroupRepository;
        protected IAccountRepository AccountRepository;
        protected IUserRepository UserRepository;


        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();

            var context = Factory.Get();

            Uow = new EntityFrameworkUnitOfWork(Factory);

            PermissionRepository = new PermissionRepository(Factory);
            GroupRepository = new GroupRepository(Factory);
            AccountRepository = new AccountRepository(Factory);
            UserRepository = new UserRepository(IdentityUserStore, Factory);

            AuthorizationService = new AuthorizationService(GroupRepository,PermissionRepository,AccountRepository,Uow);

        }


    }
}
