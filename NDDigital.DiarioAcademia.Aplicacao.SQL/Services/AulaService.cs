using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Aplicacao.ORM.Services
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

        public void Add(AulaDTO aulaDto)
        {

        }

        public void RealizaChamada(ChamadaDTO registroPresenca)
        {

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