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
            Presencas = new List<Presenca>();
        }

        public bool ChamadaRealizada { get; set; }

        public DateTime Data { get; set; }

        public virtual Turma Turma { get; set; }

        public virtual List<Presenca> Presencas { get; set; }

        public Aula(DateTime dateTime, Turma turma) : this()
        {            
            this.Data = dateTime;
            this.Turma = turma;
        }

        public void ExcluiPresencas()
        {            
            //Presencas.Remove
            Presencas = null;
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

        IEnumerable<Aula> GetAllByTurma(int ano);        
    }
}