using NDDigital.DiarioAcademia.Dominio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations
{
    public class PresencaConfiguration : EntityTypeConfiguration<Presenca>
    {
        public PresencaConfiguration()
        {
            ToTable("TBPresenca");

            HasKey(p => p.Id);

            HasRequired(p => p.Aluno);

            HasRequired(p => p.Aula);

            Property(p => p.StatusPresenca);
        }
    }
}