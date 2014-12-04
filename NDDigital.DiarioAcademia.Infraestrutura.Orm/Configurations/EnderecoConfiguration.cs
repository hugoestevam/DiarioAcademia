using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDDigital.DiarioAcademia.Dominio;

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
