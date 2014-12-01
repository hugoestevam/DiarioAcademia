using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Aplicacao.DTOs
{
    public class ChamadaDTO
    {
        public ChamadaDTO()
        {
            Alunos = new List<ChamadaAlunoDTO>();
        }

        public int AnoTurma { get; set; }

        public DateTime Data { get; set; }

        public List<ChamadaAlunoDTO> Alunos { get; set; }
    }

    public class ChamadaAlunoDTO
    {
        public ChamadaAlunoDTO()
        {

        }

        public ChamadaAlunoDTO(int alunoId, string nome, string status)
        {
            AlunoId = alunoId;
            Nome = nome;
            Status = status;
        }

        public int AlunoId { get; set; }

        public string Nome { get; set; }

        public string Status { get; set; }


        public override string ToString()
        {
            return string.Format("{0}: {1}", Nome, Status == "F" ? "Faltou" : "Presente");
        }
    }
}