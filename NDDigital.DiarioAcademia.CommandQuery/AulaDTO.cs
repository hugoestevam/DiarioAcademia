using NDDigital.DiarioAcademia.Dominio.Entities;
using System;

namespace NDDigital.DiarioAcademia.Aplicacao.DTOs
{
    public class AulaDTO
    {
        public AulaDTO()
        {
        }

        public AulaDTO(Aula aula)
        {
            Id = aula.Id;
            DataAula = aula.Data;
            TurmaId = aula.Turma.Id;
            AnoTurma = aula.Turma.Ano;
        }

        public int Id { get; set; }

        public DateTime DataAula { get; set; }

        public int AnoTurma { get; set; }

        public int TurmaId { get; set; }

        public override string ToString()
        {
            return DataAula.ToString("dd/MM/yyyy");
        }
    }
}