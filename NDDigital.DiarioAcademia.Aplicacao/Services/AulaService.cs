using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface IAulaService 
    {
        void Add(AulaDTO aulaDto);

        void Update(AulaDTO aulaDto);

        void Delete(int id);

        AulaDTO GetById(int id);

        IEnumerable<AulaDTO> GetAllByTurma(int anoTurma);
    }

    public class AulaService : IAulaService
    {
        private IUnitOfWork _unitOfWork;
        private IAulaRepository _aulaRepository;
        private ITurmaRepository _turmaRepository;

        public AulaService(IAulaRepository repoAula, ITurmaRepository repoTurma, IUnitOfWork unitOfWork)
        {
            _aulaRepository = repoAula;
            _turmaRepository = repoTurma;
            _unitOfWork = unitOfWork;
        }

        public void Add(AulaDTO aulaDto)
        {
            Turma turma = _turmaRepository.GetById(aulaDto.TurmaId);

            Aula aula = new Aula(aulaDto.Data, turma);

            _aulaRepository.Add(aula);

            _unitOfWork.Commit();
        }

        public void Update(AulaDTO aulaDto)
        {
            Aula aula = _aulaRepository.GetById(aulaDto.Id);

            aula.Data = aulaDto.Data;

            _aulaRepository.Update(aula);

            _unitOfWork.Commit();
        }      

        public void Delete(int id)
        {
            _aulaRepository.Delete(id);

            _unitOfWork.Commit();
        }

        public AulaDTO GetById(int id)
        {
            var aula = _aulaRepository.GetById(id);

            return new AulaDTO
            {
                Id = aula.Id,
                Data= aula.Data
            };
        }

        public IEnumerable<AulaDTO> GetAllByTurma(int ano)
        {
            return _aulaRepository
                .GetAllByTurma(ano)
                .Select(aula => new AulaDTO(aula))
                .ToList();
        }
    }
}
