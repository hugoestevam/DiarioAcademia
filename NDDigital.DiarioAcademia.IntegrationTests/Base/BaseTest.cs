using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;

namespace NDDigital.DiarioAcademia.IntegrationTests.Base
{
    /// <summary>
    /// Summary description for BaseTest
    /// </summary>
    public class BaseTest
    {
        #region Protected Properties
        protected IUnitOfWork Uow;
        #endregion



        [TestInitialize]
        public virtual void Initialize()
        {
            Database.SetInitializer(new DatabaseTestInitializer());

            ObjectBuilder.Reset();
           
        }


    }
}
