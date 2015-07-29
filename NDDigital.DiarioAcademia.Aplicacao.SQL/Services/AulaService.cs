using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Aplicacao.SQL.Services
{
    public interface IAulaService
    {
        void Add(AulaDTO aulaDto);

        void RealizaChamada(ChamadaDTO registroPresencaDto);

        ChamadaDTO GetChamadaByAula(AulaDTO aula);

        void Update(AulaDTO aulaDto);

        void Delete(int id);

        AulaDTO GetById(int id);

        IEnumerable<AulaDTO> GetAllByTurma(int anoTurma);
    }

    public class AulaService : IAulaService
    {

        private IAulaRepository _aulaRepository;
        private IAlunoRepository _alunoRepository;
        private ITurmaRepository _turmaRepository;

        private const string NENHUM_ALUNO_ENCOTRADO_PARA_TURMA = "Nenhum aluno encontrado para a turma de {0}";
        private const string NENHUMA_AULA_ENCOTRADA_NESTA_DATA = "Nenhuma aula encontrada para esta data {0}";

        public AulaService()
        {

        }

        public AulaService(IAulaRepository aulaRepository, IAlunoRepository alunoRepository, ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
            _alunoRepository = alunoRepository;
            _aulaRepository = aulaRepository;
        }

        public void Add(AulaDTO aulaDto)
        {

        }

        public void RealizaChamada(ChamadaDTO registroPresenca)
        {
            var alunos = _alunoRepository.GetAllByTurmaId(registroPresenca.TurmaId);

            if (alunos == null || alunos.Any() == false)
                throw new AlunoNaoEncontrado(String.Format(NENHUM_ALUNO_ENCOTRADO_PARA_TURMA, registroPresenca.AnoTurma));
                      
            var aula = _aulaRepository.GetById(registroPresenca.AulaId);

            if (aula == null)
                throw new AulaNaoEncontrada(String.Format(NENHUMA_AULA_ENCOTRADA_NESTA_DATA, registroPresenca.Data));

            foreach (var item in registroPresenca.Alunos)
            {
                var aluno = alunos.First(x => x.Id == item.AlunoId);

                aluno.RegistraPresenca(aula, item.Status);

                _alunoRepository.Update(aluno);
            }

            aula.ChamadaRealizada = true;

            _aulaRepository.Update(aula);
        }

        public void Update(AulaDTO aulaDto)
        {

        }

        public void Delete(int id)
        {

        }

        public AulaDTO GetById(int id)
        {
            return null;
        }

        public IEnumerable<AulaDTO> GetAllByTurma(int ano)
        {
            return null;
        }

        public ChamadaDTO GetChamadaByAula(AulaDTO aulaDTO)
        {
            return null;
        }

        public ChamadaDTO GetChamadaByAula(int id)//todo: coloquei essa sobrecarga aqui
        {
            return null;
        }

        public IEnumerable<AulaDTO> GetAll()
        {
            return null;
        }
    }
}