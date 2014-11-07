using NDDigital.DiarioAcademia.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations
{

    public class AlunoConfiguration : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfiguration()
        {
            ToTable("TBAluno");

            HasKey(map => map.Id);

            Property(map => map.Nome);

            HasRequired(map => map.Turma);

            HasMany(map => map.Presencas);                            
        }       
    }

}
