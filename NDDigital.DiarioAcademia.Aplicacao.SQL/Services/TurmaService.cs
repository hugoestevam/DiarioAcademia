using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Aplicacao.ORM.Services
{
    public interface ITurmaService
    {
        void Add(TurmaDTO turmaDto);

        void Delete(int id);

        IEnumerable<TurmaDTO> GetAll();

        TurmaDTO GetById(int id);

        void Update(TurmaDTO turmaDto);
    }

    public class TurmaService : ITurmaService
    {
        private ITurmaRepository _turmaRepository;

        public TurmaService()
        {

        }

        public void Add(TurmaDTO turmaDto)
        {

        }

        public void Update(TurmaDTO turmaDto)
        {

        }

        public void Delete(int id)
        {

        }

        public TurmaDTO GetById(int id)
        {
            return null;
        }

        public IEnumerable<TurmaDTO> GetAll()
        {
            return null;
        }
    }
}