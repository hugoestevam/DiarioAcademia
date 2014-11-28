using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{

    public interface IService<T> where T : class
    {
        void Add(T dto);

        void Update(T dto);        

        void Delete(Guid id);

        T GetById(Guid id);

        IEnumerable<T> GetAll();
    }


    public interface ITurmaService : IService<TurmaDTO>
    {

    }

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

        public void Delete(Guid id)
        {
            _turmaRepository.Delete(id);

            _unitOfWork.Commit();
        }

        public TurmaDTO GetById(Guid id)
        {
            var turma = _turmaRepository.GetById(id);

            return new TurmaDTO
            {
                Id = turma.Id,
                Ano= turma.Ano
            };
        }

        public IEnumerable<TurmaDTO> GetAll()
        {
            return _turmaRepository
                .GetAll()
                .Select(turma => new TurmaDTO(turma))
                .ToList();
        }
    }
}
