using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Entities;
using System;

namespace DiarioAcademia.UnitTests.Dominio
{
    [TestClass]
    public class AlunoTests
    {
        private Aluno aluno;
        private Turma turma;

        public AlunoTests()
        {
            turma = new Turma(2005);
            aluno = new Aluno("Rech", turma);
        }

        [TestMethod]
        [TestCategory("Camada de Domínio")]
        public void Quantidade_de_presencas_deveria_ser_0()
        {
            aluno.ObtemQuantidadePresencas().Should().Be(0);
        }

        [TestMethod]
        [TestCategory("Camada de Domínio")]
        public void Quantidade_de_ausências_deveria_ser_0()
        {
            aluno.ObtemQuantidadeAusencias().Should().Be(0);
        }

        [TestMethod]
        [TestCategory("Camada de Domínio")]
        public void Deveria_retornar_nome_qtd_prensenca_e_qtd_falta()
        {
            aluno.Nome = "Rech";

            Aula aula1 = new Aula(DateTime.Now.AddDays(-1), turma);
            aluno.RegistraPresenca(aula1, "C");

            Aula aula2 = new Aula(DateTime.Now, turma);
            aluno.RegistraPresenca(aula2, "F");

            aluno.ToString().Should().Be("Rech: Presenças: 1, Faltas: 1");
        }

        [TestMethod]
        [TestCategory("Camada de Domínio")]
        public void Deveria_registrar_uma_ausencia()
        {
            Aula aula = new Aula(DateTime.Now, turma);
            aluno.RegistraPresenca(aula, "F");

            aluno.ObtemQuantidadeAusencias().Should().Be(1);
        }

        [TestMethod]
        [TestCategory("Camada de Domínio")]
        public void Deveria_registrar_uma_presenca()
        {
            Aula aula = new Aula(DateTime.Now, turma);

            aluno.RegistraPresenca(aula, "C");

            aluno.ObtemQuantidadePresencas().Should().Be(1);
        }
    }
}