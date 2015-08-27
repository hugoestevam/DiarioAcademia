using NDDigital.DiarioAcademia.Dominio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations
{
    public class EnderecoConfiguration : ComplexTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            Property(a => a.Bairro);
            Property(a => a.Cep);
            Property(a => a.Localidade);
            Property(a => a.Uf).HasMaxLength(2);
        }
    }
}