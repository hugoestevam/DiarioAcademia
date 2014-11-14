using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System.Data.Entity;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;
using NDbUnit.Core;
using System.Configuration;
using NDbUnit.Core.SqlClient;
using System.IO;

namespace NDDigital.DiarioAcademia.IntegrationTests
{
    public class DatabaseFixture : IDisposable
    {
       

        public DatabaseFactory Factory
        {
            get;
            private set;
        }

        public UnitOfWork UnitOfWork
        {
            get;
            private set;
        }

        public DatabaseFixture()
        {
            Factory = new DatabaseFactory();

            UnitOfWork = new UnitOfWork(Factory);                  

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DiarioAcademiaContext>());          
        }

      

        public virtual void Dispose()
        {
            Factory.Dispose();
        }
    }  
}
