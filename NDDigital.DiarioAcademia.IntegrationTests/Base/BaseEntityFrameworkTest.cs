using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Aplicacao.Services.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.IntegrationTests.Common;
using Infrastructure.DAO.ORM.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Repositories;

namespace NDDigital.DiarioAcademia.IntegrationTests.Base
{
    /// <summary>
    /// Summary description for BaseTest
    /// </summary>
    public class BaseEntityFrameworkTest:BaseTest
    {
        #region Constructor Utilities
        protected DatabaseEntityFrameworkFixture Fixture;
        protected EntityFrameworkFactory Factory;
        protected IdentityUserStore IdentityUserStore;

        protected IAuthorizationService AuthorizationService;

        #endregion



        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();

            Fixture = new DatabaseEntityFrameworkFixture();

            Factory = Fixture.Factory;

            var context = Factory.Get();

            Uow = new EntityFrameworkUnitOfWork(Factory);

        }


    }
}
