using FizzWare.NBuilder;
using NDDigital.DiarioAcademia.CommandQuery;
using NDDigital.DiarioAcademia.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.UnitTests
{
    public class ObjectMother
    {
        public static Aula CriaUmaAula()
        {
            return new Aula(DateTime.Now);
        }        

        public static RegistraPresencaCommand CriaRegistraPresencaCommand(IEnumerable<Guid> ids)
        {
            var comando = Builder<RegistraPresencaCommand>.CreateNew()
                .With(x => x.AnoTurma = 2014)
                .With(x => x.DataAula = new DateTime(2000, 10, 10))               
                .Build();

            foreach (var id in ids)
            {
                comando.PresencaAlunos.Add(new PresencaAlunosCommand { AlunoId = id, Status = "C" });
            }

            return comando;
        }

        internal static IEnumerable<Aluno> CriaListaAlunos(int qtdAlunos)
        {
            return Builder<Aluno>
                .CreateListOfSize(qtdAlunos)
                .Build();
        }
    }
}
