using NDDigital.DiarioAcademia.Dominio.Entities;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Dominio.Contracts
{
    public interface IPresencaRepository : IRepository<Presenca>
    {
        List<Presenca> GetAllByAluno(int idAluno);

        List<Presenca> GetAllByAula(int idAula);
    }
}