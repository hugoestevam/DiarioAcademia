using NDDigital.DiarioAcademia.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations
{

    public class AlunoConfiguration : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfiguration()
        {
            ToTable("TBAluno");

            HasKey(a => a.Id);

            Property(a => a.Nome);

            HasRequired(a => a.Turma);

            HasMany(a => a.Presencas);
        }
    }

}
