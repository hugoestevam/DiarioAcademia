using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.IntegrationTests.SQL
{
    [TestClass]
    public class TurmaRepositorySQLTest
    {
        public TurmaRepositoryImpl _repo = new TurmaRepositoryImpl();

        [TestMethod]
        [TestCategory("Camada de Infraestrutura SQL")]
        public void Deveria_gravar_turma()
        {
            var turma = new Turma() { Ano = 2015 };

            var comando = _repo.Add(turma);

            Assert.IsNotNull(comando);
        }

        [TestMethod]
        [TestCategory("Camada de Infraestrutura SQL")]
        public void Deveria_buscar_todas_as_turmas()
        {
            var turmas = _repo.GetAll();


            Assert.IsNotNull(turmas);
        }

        [TestMethod]
        [TestCategory("Camada de Infraestrutura SQL")]
        public void Deveria_buscar_turma()
        {
            var turma = _repo.GetById(1);
            Assert.IsNotNull(turma);
        }

        [TestMethod]
        [TestCategory("Camada de Infraestrutura SQL")]
        public void Deveria_deletar_turma()
        {
            var turmaDeletada = _repo.GetById(1);
            _repo.Delete(turmaDeletada);

            var lastOne = _repo.GetAll();

            var turma = _repo.GetById(1);

            Assert.IsNotNull(turma);
        }
    }
}
