using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations
{
    public class TurmaConfiguration : EntityTypeConfiguration<Turma>
    {
        public TurmaConfiguration()
        {
            ToTable("TBTurma");

            HasKey(t => t.Id);

            Property(t => t.Ano);
        }
    }
}