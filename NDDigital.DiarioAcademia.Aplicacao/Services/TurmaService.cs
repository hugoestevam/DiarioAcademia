using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface ITurmaService:IService<TurmaDTO>{}

    public class TurmaService : ITurmaService
    {
        private IUnitOfWork _unitOfWork;
        private ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository repoTurma, IUnitOfWork unitOfWork)
        {
            _turmaRepository = repoTurma;
            _unitOfWork = unitOfWork;
        }

        public void Add(TurmaDTO turmaDto)
        {
            Turma turma = new Turma(turmaDto.Ano);

            _turmaRepository.Add(turma);

            _unitOfWork.Commit();
        }

        public void Update(TurmaDTO turmaDto)
        {
            Turma turma = _turmaRepository.GetById(turmaDto.Id);

            turma.Ano = turmaDto.Ano;

            _turmaRepository.Update(turma);

            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _turmaRepository.Delete(id);

            _unitOfWork.Commit();
        }

        public TurmaDTO GetById(int id)
        {
            var turma = _turmaRepository.GetById(id);

            return new TurmaDTO
            {
                Id = turma.Id,
                Ano = turma.Ano
            };
        }

        public IList<TurmaDTO> GetAll()
        {
            return _turmaRepository
                .GetAll()
                .Select(turma => new TurmaDTO(turma))
                .ToList();
        }
    }
}