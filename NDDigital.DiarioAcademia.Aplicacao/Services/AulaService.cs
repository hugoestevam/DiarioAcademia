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
    public interface IAulaService : IService<AulaDTO>
    {

    }

    public class AulaService : IAulaService
    {
        private IUnitOfWork _unitOfWork;
        private IAulaRepository _aulaRepository;

        public AulaService(IAulaRepository repoAula, IUnitOfWork unitOfWork)
        {
            _aulaRepository = repoAula;
            _unitOfWork = unitOfWork;
        }

        public void Add(AulaDTO aulaDto)
        {
            Aula Aula = new Aula(aulaDto.Data);

            _aulaRepository.Add(Aula);

            _unitOfWork.Commit();
        }

        public void Update(AulaDTO aulaDto)
        {
            Aula aula = _aulaRepository.GetById(aulaDto.Id);

            aula.Data = aulaDto.Data;

            _aulaRepository.Update(aula);

            _unitOfWork.Commit();
        }      

        public void Delete(Guid id)
        {
            _aulaRepository.Delete(id);

            _unitOfWork.Commit();
        }

        public AulaDTO GetById(Guid id)
        {
            var aula = _aulaRepository.GetById(id);

            return new AulaDTO
            {
                Id = aula.Id,
                Data= aula.Data
            };
        }

        public IEnumerable<AulaDTO> GetAll()
        {
            return _aulaRepository
                .GetAll()
                .Select(aula => new AulaDTO(aula))
                .ToList();
        }
    }
}
