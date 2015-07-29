using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.IntegrationTests.SQLs
{
    [TestClass]
    public class PresencaRepositorySQLTest
    {
        public PresencaRepositorySql _repo = new PresencaRepositorySql();
               

        [TestMethod]
        [TestCategory("Camada de Infraestrutura SQL")]
        public void Deveria_deletar_presenca()
        {
            var presencaDeletada = _repo.GetById(1);
            _repo.Delete(presencaDeletada);

            var presenca = _repo.GetById(1);

            Assert.IsNotNull(presenca);
        }
    }
}
