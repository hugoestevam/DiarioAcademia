using NDDigital.DiarioAcademia.Dominio.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDDigital.DiarioAcademia.Dominio
{
    public class Aluno : Entity
    {
        protected Aluno() {

            Presencas = new List<Presenca>();

            GenerateNewIdentity();
        }

        public Aluno(string nome, Turma turma) : this()
        {
            this.Nome = nome;
            this.Turma = turma;
        }        

        public string Nome { get; set; }

        public virtual Turma Turma { get; set; }

        public virtual List<Presenca> Presencas { get; set; }
        
        public int ObtemQuantidadePresencas()
        {
            return Presencas.Count(x => x.StatusPresenca == "C");
        }

        public int ObtemQuantidadeAusencias() 
        {
            return Presencas.Count(x => x.StatusPresenca == "F");
        }

        public void RegistraPresenca(Aula aula, string statusPresenca)
        {
            if (Presencas.Exists(x => x.Aula.Equals(aula)))
                throw new PresencaJaRegistradaException();

            Presenca presenca = new Presenca(aula, this, statusPresenca);

            if (Presencas == null)
                Presencas = new List<Presenca>();

            Presencas.Add(presenca);
        }

        public override string ToString()
        {
            return string.Format("{0}: Presenças: {1}, Faltas: {2}", Nome, ObtemQuantidadePresencas(), ObtemQuantidadeAusencias());
        }        
    }

    public interface IAlunoRepository : IRepository<Aluno>
    {
        IEnumerable<Aluno> GetAllByTurma(int ano);        
    }

    public interface IEnderecoRepository 
    {
        Endereco GetEnderecoByCep(string cep);
    }

    public class Endereco
    {
        public int Numero { get; set; }

        public string Rua { get; set; }

    }
}
