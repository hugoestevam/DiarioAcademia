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
        T Add(T dto);

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

        public TurmaDTO Add(TurmaDTO turmaDto)
        {
            throw new NotImplementedException();
        }

        public void Update(TurmaDTO turmaDto)
        {
            throw new NotImplementedException();
        }

        public void Delete(TurmaDTO turmaDto)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public TurmaDTO GetById(Guid id)
        {
            throw new NotImplementedException();
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
