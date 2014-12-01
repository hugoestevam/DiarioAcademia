using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Aplicacao.DTOs
{
    public class AulaDTO
    {
        public AulaDTO(Dominio.Aula aula)
        {
            Data = aula.Data;
            Id = aula.Id;
            TurmaId = aula.Turma.Id;
        }

        public AulaDTO()
        {
            Data = DateTime.Now;
        }
        public DateTime Data { get; set; }

        public int Id { get; set; }

        public int TurmaId { get; set; }

        public override string ToString()
        {
            return Data.ToString("dd/MM/yyyy");
        }
    }
}
