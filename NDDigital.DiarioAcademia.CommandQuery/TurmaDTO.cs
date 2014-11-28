using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Aplicacao.DTOs
{
    public class TurmaDTO
    {
        public TurmaDTO(Guid id)
        {
            Id = id;
        }

        public TurmaDTO(Dominio.Turma turma)
        {
            // TODO: Complete member initialization
            Id = turma.Id;
            Descricao = "Turma de " + turma.Ano;
            Ano = turma.Ano;
        }

        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public override bool Equals(object obj)
        {
            var turma = (TurmaDTO)obj;

            return this.Id == turma.Id;
        }

        public int Ano { get; set; }
    }
}
