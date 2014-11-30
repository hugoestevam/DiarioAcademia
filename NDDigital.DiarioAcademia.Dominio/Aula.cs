using NDDigital.DiarioAcademia.Dominio.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDDigital.DiarioAcademia.Dominio
{
    public class Aula : Entity
    {
        private Aula()
        {
        }

        public DateTime Data { get; set; }

        public virtual Turma Turma { get; set; }

        public Aula(DateTime dateTime, Turma turma) : this()
        {            
            this.Data = dateTime;
            this.Turma = turma;
        }

        public override bool Equals(object obj)
        {
            Aula aula = (Aula)obj;

            return this.Data.Equals(aula.Data);
        }
        
    }

    public interface IAulaRepository : IRepository<Aula>
    {
        Aula GetByData(DateTime data);
    }
}