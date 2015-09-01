using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Aplicacao.Services.Security;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.IntegrationTests.Common;
using Infrastructure.DAO.ORM.Common;

namespace NDDigital.DiarioAcademia.IntegrationTests.Base
{
    /// <summary>
    /// Summary description for BaseTest
    /// </summary>
    public class BaseSecurityTest
    {

        protected IUnitOfWork Uow;

        protected IPermissionRepository PermissionRepository;
        protected IGroupRepository GroupRepository;
        protected IAccountRepository AccountRepository;
        protected IUserRepository UserRepository;

        protected IAuthorizationService AuthorizationService;


        [TestInitialize]
        public virtual void Initialize()
        {
            Database.SetInitializer(new BaseTestInitializer());

            ObjectBuilder.Reset();

            var fixture = new DatabaseFixture();

            var factory = fixture.Factory;

            var context = factory.Get();

            var store = new IdentityUserStore(context);

            Uow = new EntityFrameworkUnitOfWork(factory);

            PermissionRepository = new PermissionRepository(factory);
            GroupRepository = new GroupRepository(factory);
            AccountRepository = new AccountRepository(factory);
            UserRepository = new UserRepository(store,factory);

            AuthorizationService = new AuthorizationService(GroupRepository,PermissionRepository,AccountRepository,Uow);

        }


    }
}
