using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories;
using System;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.IntegrationTests.SQLs
{
    [TestClass]
    public class AulaRepositorySQLTest
    {
        public AulaRepositorySql _repoAula;
        public AlunoRepositorySql _repoAluno;
        public TurmaRepositorySql _repoTurma;
        public Turma _turma;
        public Aula _aula;
        public Aluno _aluno;
        public Presenca _presenca;

        public AulaRepositorySQLTest()
        {
            _repoAula = new AulaRepositorySql();
            _repoAluno = new AlunoRepositorySql();
            _repoTurma = new TurmaRepositorySql();

            _turma = new Turma(2015);

            _aluno = new Aluno("Thiago", _turma);

            _aula = new Aula(DateTime.Now, _turma);
            _aula.ChamadaRealizada = false;
            
            _presenca = new Presenca(_aula, _aluno, "C");
        }


        [TestMethod]
        [TestCategory("Camada de Infraestrutura SQL")]
        public void Deveria_gravar_aula()
        {
            //arrange
            //InsertTestData(TBTurma);

            var turma = _repoTurma.GetById(5);

            var aula = new Aula(DateTime.Now, turma);

            //action
            _repoAula.Add(aula);

            //assert
            var aulaEncontrada = _repoAula.GetById(aula.Id);

            aulaEncontrada.Should().NotBeNull();
        }


        [TestMethod]
        [TestCategory("Camada de Infraestrutura SQL")]
        public void Deveria_excluir_aula_e_presencas_relacionadas()
        {
            //arrange
            //InsertTestData(TBAula, TBPresenca, TBAluno, TBTurma);

           // Aula aula = aulaRepository.GetByIdIncluding(AULA_ID, x => x.Presencas);

            //act
            _repoAula.Delete(_aula);


            //assert
            //aulaRepository.GetById(AULA_ID).Should().BeNull();

            //presencaRepository.GetById(PRESENCA_ID).Should().BeNull();
        }


        [TestMethod]
        [TestCategory("Camada de Infraestrutura SQL")]
        public void Deveria_atualizar_aula()
        {
            //arrange
            //InsertTestData(TBAula, TBTurma, TBPresenca);

           // Aula aula = aulaRepository.GetById(AULA_ID);

            _aula.Data = DateTime.Now;

            //act
            _repoAula.Update(_aula);


            //assert
            var aulaEncontrada = _repoAula.GetById(_aula.Id);

            aulaEncontrada.ShouldBeEquivalentTo(_aula);
        }

        [TestMethod]
        [TestCategory("Camada de Infraestrutura SQL")]
        public void Deveria_buscar_todas_aula()
        {
            //arrange
            //InsertTestData(TBAula);

            //action
            var aulas = _repoAula.GetAll();

            //assert
            aulas.Should().HaveCount(2);
        }

        [TestMethod]
        [TestCategory("Camada de Infraestrutura SQL")]
        public void Deveria_buscar_aulas_por_data()
        {
            //arrange
            //InsertTestData(TBAula);

            //action
            var aula = _repoAula.GetByData(DateTime.Now);

            //assert
            aula.Should().BeNull();
        }
    }
}
