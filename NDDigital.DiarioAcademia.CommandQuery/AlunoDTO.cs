using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDDigital.DiarioAcademia.Dominio;

namespace NDDigital.DiarioAcademia.Aplicacao.DTOs
{
    public class AlunoDTO
    {
        public AlunoDTO()
        {
        }

        public AlunoDTO(Aluno aluno)
        {
            Id = aluno.Id;
            Descricao = aluno.ToString();
            TurmaId = aluno.Turma.Id;
            Uf = aluno.Endereco.Uf;
            Bairro = aluno.Endereco.Bairro;
            Localidade = aluno.Endereco.Localidade;
            Cep = aluno.Endereco.Cep;
        }

        public int Id { get; set; }

        public int TurmaId { get; set; }

        public string Descricao { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Localidade { get; set; }

        public string Uf { get; set; }

        public override string ToString()
        {
            return Descricao;
        }
    }
}