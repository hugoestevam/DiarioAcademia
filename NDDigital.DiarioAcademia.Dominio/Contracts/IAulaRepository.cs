using NDDigital.DiarioAcademia.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Dominio.Contracts
{
    public interface IAulaRepository : IRepository<Aula>
    {
        Aula GetByData(DateTime data);

        IEnumerable<Aula> GetAllByTurma(int ano);
    }
}
