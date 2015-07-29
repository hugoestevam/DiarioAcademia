using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.IntegrationTests.SQLs
{
    [TestClass]
    public class AlunoRepositorySQLTest
    {
        public AlunoRepositorySql _repo = new AlunoRepositorySql();

        [TestMethod]
        [TestCategory("Camada de Infraestrutura SQL")]
        public void Deveria_gravar_aluno()
        {
            var aluno = new Aluno()
            {
                Nome = "Thiago Sartor",
                Endereco = new Endereco()
                {
                    Bairro = "Ferrovia",
                    Cep = "88509720",
                    Localidade = "Lages",
                    Uf = "SC"
                },

                Presencas = null,

                Turma = new Turma(2015)
            };

            var comando = _repo.Add(aluno);

            Assert.IsNotNull(comando);
        }

        [TestMethod]
        [TestCategory("Camada de Infraestrutura SQL")]
        public void Deveria_buscar_todas_as_alunos()
        {
            var alunos = _repo.GetAll();


            Assert.IsNotNull(alunos);
        }

        [TestMethod]
        [TestCategory("Camada de Infraestrutura SQL")]
        public void Deveria_buscar_aluno()
        {
            var aluno = _repo.GetById(1);
            Assert.IsNotNull(aluno);
        }

        [TestMethod]
        [TestCategory("Camada de Infraestrutura SQL")]
        public void Deveria_deletar_aluno()
        {
            var alunoDeletada = _repo.GetById(1);
            _repo.Delete(alunoDeletada);

            var lastOne = _repo.GetAll();

            var aluno = _repo.GetById(1);

            Assert.IsNotNull(aluno);
        }
    }
}
