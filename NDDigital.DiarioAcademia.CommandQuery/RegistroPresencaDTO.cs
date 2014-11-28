using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Aplicacao.DTOs
{
    public class RegistroPresencaDTO
    {
        public RegistroPresencaDTO()
        {
            PresencaAlunos = new List<PresencaAlunoDTO>();
        }

        public int AnoTurma { get; set; }

        public DateTime DataAula { get; set; }

        public List<PresencaAlunoDTO> PresencaAlunos { get; set; }
    }

    public class PresencaAlunoDTO
    {
        public Guid AlunoId { get; set; }

        public string Status { get; set; }

    }
}