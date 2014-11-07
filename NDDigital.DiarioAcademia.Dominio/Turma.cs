using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDDigital.DiarioAcademia.Dominio
{
    public class Turma
    {
        public int Ano { get; set; }

        public int Id { get; set; }
    }

    public interface ITurmaRepository : IRepository<Turma>
    {
    }
}
