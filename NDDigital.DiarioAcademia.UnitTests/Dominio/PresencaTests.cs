using NDDigital.DiarioAcademia.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using NDDigital.DiarioAcademia.Traits;

namespace NDDigital.DiarioAcademia.UnitTests.Dominio
{
    [DominioTrait("")]
    public class PresencaTests
    {
        private Presenca presenca;

        public PresencaTests()
        {
            Aula aula = ObjectMother.CreateAula();
            aula.Data = new DateTime(2000, 10, 5);

            presenca = new Presenca(aula, new Aluno("Marco Antônio"), "F"); 
        }

        [Fact(DisplayName = "Deveria retornar a data, nome do aluno e status da presença")]
        public void Test_1()
        {                        
            presenca.ToString().Should().Contain("05/10/2000: Marco Antônio -> Faltou");
        }
    }
}
