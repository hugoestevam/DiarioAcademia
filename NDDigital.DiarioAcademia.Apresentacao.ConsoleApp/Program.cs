using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Apresentacao.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DiarioAcademiaContext context = new DiarioAcademiaContext();

            context.Turmas.Add(new Turma(2100));

            context.SaveChanges();

        }
    }
}