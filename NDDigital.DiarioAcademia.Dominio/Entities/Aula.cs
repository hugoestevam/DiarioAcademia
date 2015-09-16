using NDDigital.DiarioAcademia.Dominio.Common;
using System;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Dominio.Entities
{
    public class Aula : Entity
    {
        public Aula()
        {
            Presencas = new List<Presenca>();
            Turma = new Turma();
        }

        public bool ChamadaRealizada { get; set; }

        public DateTime Data { get; set; }

        public virtual Turma Turma { get; set; }

        public virtual IList<Presenca> Presencas { get; set; }

        public Aula(DateTime dateTime, Turma turma)
            : this()
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}