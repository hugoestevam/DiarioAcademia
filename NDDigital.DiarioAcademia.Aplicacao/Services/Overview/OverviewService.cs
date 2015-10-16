using NDDigital.DiarioAcademia.Aplicacao.DTOs.Overview;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Aplicacao.Services.Overview
{
    public interface IOverviewService
    {
        CountersDTO GetCounters();
    }
    public class OverviewService : IOverviewService
    {
        private IAlunoRepository _alunoRepository;
        private ITurmaRepository _turmaRepository ;
        private IAulaRepository _aulaRepository  ;


        public OverviewService(
            IAlunoRepository alunoRepository,
            ITurmaRepository turmaRepository ,
            IAulaRepository aulaRepository
            )
        {
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;
            _aulaRepository = aulaRepository;


        }


        public CountersDTO GetCounters()
        {
            return new CountersDTO
            {
                TotalAlunos = _alunoRepository.GetCount(),
                TotalAulas = _aulaRepository.GetCount(),
                TotalTurmas = _turmaRepository.GetCount(),
            };
        }
    }
}
