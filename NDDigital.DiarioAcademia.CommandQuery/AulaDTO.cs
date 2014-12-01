using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Aplicacao.DTOs
{
    public class AulaDTO
    {
        public AulaDTO()
        {
            Data = DateTime.Now;
        }

        public AulaDTO(Dominio.Aula aula)
        {
            Data = aula.Data;
            Id = aula.Id;
            AnoTurma = aula.Turma.Ano;
        }

        public int Id { get; set; }

        public DateTime Data { get; set; }

        public int AnoTurma { get; set; }

        public override string ToString()
        {
            return Data.ToString("dd/MM/yyyy");
        }        

    }    
}
