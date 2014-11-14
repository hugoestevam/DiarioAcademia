using NDDigital.DiarioAcademia.Dominio.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDDigital.DiarioAcademia.Dominio
{
    public class Aula : Entity
    {
        protected Aula()
        {
            GenerateNewIdentity();
        }

        public DateTime Data { get; set; }

        public virtual List<Presenca> Presencas { get; set; }

        public Aula(DateTime dateTime) : this()
        {            
            this.Data = dateTime;            
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
