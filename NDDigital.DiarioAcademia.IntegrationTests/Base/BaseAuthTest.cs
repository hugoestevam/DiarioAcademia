using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Aplicacao.Services.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.IntegrationTests.Common;
using Infrastructure.DAO.ORM.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Repositories;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Common;

namespace NDDigital.DiarioAcademia.IntegrationTests.Base
{
    /// <summary>
    /// Summary description for BaseTest
    /// </summary>
    public class BaseAuthTest:BaseTest
    {
        #region Constructor Utilities
        protected DatabaseAuthFixture Fixture;
        protected AuthFactory Factory;
        protected IdentityUserStore IdentityUserStore;

        protected IAuthorizationService AuthorizationService;

        #endregion



        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();

            Fixture = new DatabaseAuthFixture();

            Factory = Fixture.Factory;

            var context = Factory.Get();

            IdentityUserStore = new IdentityUserStore(context);

            Uow = new AuthUnitOfWork(Factory);

        }


    }
}
