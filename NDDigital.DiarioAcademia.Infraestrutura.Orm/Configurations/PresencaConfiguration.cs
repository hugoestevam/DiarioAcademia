using NDDigital.DiarioAcademia.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations
{

    public class PresencaConfiguration : EntityTypeConfiguration<Presenca>
    {
        public PresencaConfiguration()
        {
            ToTable("TBPresenca");

            HasKey(p => p.Id);

            HasRequired(p => p.Aluno); 

            HasRequired(p => p.Aula)
                .WithMany(a => a.Presencas)
                .WillCascadeOnDelete(true);

            Property(p => p.StatusPresenca);

        }
    }
}
