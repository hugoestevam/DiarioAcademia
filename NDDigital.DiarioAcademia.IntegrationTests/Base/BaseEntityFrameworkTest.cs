using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Aplicacao.Services.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.IntegrationTests.Common;
using Infrastructure.DAO.ORM.Common;

namespace NDDigital.DiarioAcademia.IntegrationTests.Base
{
    /// <summary>
    /// Summary description for BaseTest
    /// </summary>
    public class BaseEntityFrameworkTest:BaseTest
    {
        #region Constructor Utilities
        protected DatabaseFixture Fixture;
        protected EntityFrameworkFactory Factory;
        protected IdentityUserStore IdentityUserStore;

        protected IAuthorizationService AuthorizationService;

        #endregion



        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();

            Fixture = new DatabaseFixture();

            Factory = Fixture.Factory;

            var context = Factory.Get();

            IdentityUserStore = new IdentityUserStore(context);

            Uow = new EntityFrameworkUnitOfWork(Factory);

        }


    }
}
