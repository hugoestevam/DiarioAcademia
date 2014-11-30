using NDDigital.DiarioAcademia.Dominio.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDDigital.DiarioAcademia.Dominio
{
    public class Turma : Entity
    {
        private Turma()
        {

        }
        public Turma(int ano) 
        {
            Ano = ano;
        }

        public int Ano { get; set; }        
    }

    public interface ITurmaRepository : IRepository<Turma>
    {
    }
}
