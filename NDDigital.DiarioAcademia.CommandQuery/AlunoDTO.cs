using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Aplicacao.DTOs
{
    public class AlunoDTO
    {
        public AlunoDTO()
        {
        }

        public AlunoDTO(Dominio.Aluno aluno)
        {
            Id = aluno.Id;
            Nome = aluno.Nome;
            TurmaId = aluno.Turma.Id;
        }

        public Guid Id { get; set; }

        public Guid TurmaId { get; set; }

        public string Nome { get; set; }


    }
}