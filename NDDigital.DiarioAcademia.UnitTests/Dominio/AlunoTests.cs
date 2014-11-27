using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Traits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using FizzWare.NBuilder;
using NDDigital.DiarioAcademia.UnitTests;


namespace DiarioAcademia.UnitTests.Dominio
{
    [DominioTrait("")]    
    public class AlunoTests
    {
        private Aluno aluno;
        private Turma turma;
        public AlunoTests()
        {
            turma = new Turma(2005);
            aluno = new Aluno("Rech",turma);
        }

        [Fact(DisplayName = "Quantidade de presencas deveria ser 0")]
        public void Test_1()
        {
            aluno.ObtemQuantidadePresencas().Should().Be(0);
        }

        [Fact(DisplayName = "Quantidade de ausências deveria ser 0")]
        public void Test_2()
        {
            aluno.ObtemQuantidadeAusencias().Should().Be(0);
        }

        [Fact(DisplayName = "Deveria retornar nome, qtd prensença e qtd falta")]
        public void Test_3()
        {
            aluno.Nome = "Rech";

            Aula aula1 = new Aula(DateTime.Now.AddDays(-1));
            aluno.RegistraPresenca(aula1, "C");

            Aula aula2 = new Aula(DateTime.Now);
            aluno.RegistraPresenca(aula2, "F");

            aluno.ToString().Should().Be("Rech: Presenças: 1, Faltas: 1");
        }

        [Fact(DisplayName = "Deveria registrar uma ausência")]
        public void Test_4()
        {
            Aula aula = new Aula(DateTime.Now);
            aluno.RegistraPresenca(aula, "F");

            aluno.ObtemQuantidadeAusencias().Should().Be(1);
        }

        [Fact(DisplayName = "Deveria registrar uma presença")]
        public void Test_5()
        {
            Aula aula = new Aula(DateTime.Now);

            aluno.RegistraPresenca(aula, "C");

            aluno.ObtemQuantidadePresencas().Should().Be(1);
        }

        [Fact(DisplayName = "Não deveria registrar duas presenças na mesma aula")]
        public void Test_6()
        {
            Aula aula = new Aula(DateTime.Now);

            aluno.RegistraPresenca(aula, "C");
            
            Assert.Throws<PresencaJaRegistradaException>(() => aluno.RegistraPresenca(aula, "C"));
        }       
    
        
    }

   
}