using NDDigital.DiarioAcademia.Dominio.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDDigital.DiarioAcademia.Dominio
{
    public class Aula : Entity
    {
        
        public DateTime Data { get; set; }            

        public Aula(DateTime dateTime)
        {            
            this.Data = dateTime;

            GenerateNewIdentity();
        }
        
    }

    public interface IAulaRepository : IRepository<Aula>
    {
        Aula GetByData(DateTime data);
    }
}
