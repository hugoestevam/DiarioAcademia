using NDDigital.DiarioAcademia.Dominio.Common;

namespace NDDigital.DiarioAcademia.Dominio
{
    public class Turma : Entity
    {
        private Turma()
        {
        }

        public Turma(int ano)
        {
            Ano = ano;
        }

        public int Ano { get; set; }
    }

    public interface ITurmaRepository : IRepository<Turma>
    {
    }
}