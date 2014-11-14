using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NDDigital.DiarioAcademia.Aplicacao.Testes.Traits
{
    public class RepositorioTrait : TraitAttribute
    {
        public RepositorioTrait(string name = "")
            : base("Camada de Infraestrutura de Dados", "")
        {

        }
    }
}
