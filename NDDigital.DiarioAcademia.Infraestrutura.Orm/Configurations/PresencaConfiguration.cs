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

            HasKey(map => map.Id);

            HasRequired(map => map.Aluno);

            HasRequired(map => map.Aula);

            Property(map => map.StatusPresenca);

        }
    }
}
