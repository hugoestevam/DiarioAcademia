using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using System.Collections.Generic;
using System.Linq;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories;

namespace NDDigital.DiarioAcademia.Aplicacao.SQL.Services
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
        private TurmaRepositorySql turmaRepository;

        public TurmaService()
        {

        }

        public TurmaService(TurmaRepositorySql turmaRepository)
        {
            this.turmaRepository = turmaRepository;
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