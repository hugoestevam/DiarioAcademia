using NDDigital.DiarioAcademia.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations
{

    public class AulaConfiguration : EntityTypeConfiguration<Aula>
    {
        public AulaConfiguration()
        {
            ToTable("TBAula");            
            

            HasKey(x => x.Id);

            Property(x => x.Data);
        }
    }
}
