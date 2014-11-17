using NDDigital.DiarioAcademia.CommandQuery;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Aplicacao
{
    public interface IPresencaService
    {
        void RegistraPresenca(RegistraPresencaCommand cmd);


        //void RegistraPresenca(int anoTurma, DateTime dataAula, int[]  );        
    }

    public class PresencaService : IPresencaService 
    {
        private IAlunoRepository _alunoRepository;
        private IAulaRepository _aulaRepository;
        private IUnitOfWork _unitOfWork;

        public PresencaService(IUnitOfWork unitOfWork, IAlunoRepository alunoRepositorio, IAulaRepository aulaRepository)
        {
            _alunoRepository = alunoRepositorio;
            _aulaRepository = aulaRepository;
            _unitOfWork = unitOfWork;
        }

        public void RegistraPresenca(RegistraPresencaCommand cmd)
        {
            var alunos = _alunoRepository.GetAllByTurma(cmd.AnoTurma);

            if (alunos == null || alunos.Any() == false)
                throw new AlunoNaoEncontrado();

            var aula = _aulaRepository.GetByData(cmd.DataAula);

            if (aula == null)
                throw new AulaNaoEncontrada();

            foreach (var item in cmd.PresencaAlunos)
            {
                var aluno = alunos.First(x => x.Id == item.AlunoId);

                aluno.RegistraPresenca(aula, item.Status);

                _alunoRepository.Update(aluno);
            }

            _unitOfWork.Commit();            
        }


    }
}
