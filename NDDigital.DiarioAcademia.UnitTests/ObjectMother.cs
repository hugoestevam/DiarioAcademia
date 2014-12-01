using FizzWare.NBuilder;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
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
            return new Aula(DateTime.Now, new Turma(2014));
        }        

        public static ChamadaDTO CriaRegistraPresencaCommand(IEnumerable<int> ids)
        {
            var comando = Builder<ChamadaDTO>.CreateNew()
                .With(x => x.AnoTurma = 2014)
                .With(x => x.Data = new DateTime(2000, 10, 10))               
                .Build();

            foreach (var id in ids)
            {
                comando.Alunos.Add(new ChamadaAlunoDTO { AlunoId = id, Status = "C" });
            }

            return comando;
        }       

        internal static IEnumerable<Aluno> CriaListaAlunos(int qtdAlunos)
        {
            return Builder<Aluno>
                .CreateListOfSize(qtdAlunos)
                .All().With(
                    x => x.Presencas = new List<Presenca>())
                .Build();
        }
    }
}
