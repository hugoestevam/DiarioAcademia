using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NDDigital.DiarioAcademia.Aplicacao.Testes.Traits
{
    public class AplicacaoTrait : TraitAttribute
    {
        public AplicacaoTrait(string value)
            : base("Camada de Aplicação", value)
        {

        }
    }
}
