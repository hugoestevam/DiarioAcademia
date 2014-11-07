using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Common 
{
    public class UnitOfWork : IUnitOfWork
    {
        private DiarioAcademiaContext dbContext;
        private readonly IDatabaseFactory dbFactory;
        protected DiarioAcademiaContext DbContext
        {
            get
            {
                return dbContext ?? dbFactory.Get();
            }
        }

        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void Commit()
        {
            DbContext.SaveChanges();            
        }

        
    }
}