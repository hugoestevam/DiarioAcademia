using NDDigital.DiarioAcademia.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations
{
    public class AulaConfiguration : EntityTypeConfiguration<Aula>
    {
        public AulaConfiguration()
        {
            ToTable("TBAula");

            HasKey(a => a.Id);

            HasRequired(a => a.Turma)
                .WithMany()
                .WillCascadeOnDelete(false);

            HasMany(a => a.Presencas);

            Property(a => a.Data)
                .HasColumnType("Date");
        }
    }
}