using NDDigital.DiarioAcademia.Dominio;
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
            DataAula = aula.Data;
            Id = aula.Id;
            AnoTurma = aula.Turma.Ano;
            TurmaId = aula.Turma.Id;
        }

        public int Id { get; set; }

        public DateTime DataAula { get; set; }

        public int AnoTurma { get; set; } //TODO: REVER ISSO AQUI

        public int TurmaId { get; set; }  //TODO: THIAGO SARTOR 

        public override string ToString()
        {
            return DataAula.ToString("dd/MM/yyyy");
        }
    }
}