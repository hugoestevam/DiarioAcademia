using Infrasctructure.DAO.ORM.Contexts;
using NDDigital.DiarioAcademia.Dominio.Entities;

namespace NDDigital.DiarioAcademia.Apresentacao.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            EntityFrameworkContext context = new EntityFrameworkContext();

            context.Turmas.Add(new Turma(2100));

            context.SaveChanges();
        }
    }
}