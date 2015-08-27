using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Entities;
using System;

namespace NDDigital.DiarioAcademia.UnitTests.Dominio
{
    [TestClass]
    public class PresencaTests
    {
        private Presenca presenca;

        public PresencaTests()
        {
            Aula aula = ObjectBuilder.CriaUmaAula();
            aula.Data = new DateTime(2000, 10, 5);

            Turma turma = new Turma(2012);

            presenca = new Presenca(aula, new Aluno("Marco Antônio", turma), "F");
        }

        [TestMethod]
        [TestCategory("Camada de Domínio")]
        public void Deveria_retornar_a_data_nome_do_aluno_e_status_da_presenca()
        {
            presenca.ToString().Should().Contain("05/10/2000: Marco Antônio -> Faltou");
        }
    }
}