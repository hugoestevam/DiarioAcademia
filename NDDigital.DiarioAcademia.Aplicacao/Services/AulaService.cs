using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface IAulaService 
    {
        void Add(AulaDTO aulaDto);

        void RegistraPresenca(RegistroPresencaDTO registroPresencaDto);


        void Update(AulaDTO aulaDto);

        void Delete(int id);

        AulaDTO GetById(int id);

        IEnumerable<AulaDTO> GetAllByTurma(int anoTurma);
    }

    public class AulaService : IAulaService
    {
        private IUnitOfWork _unitOfWork;
        private IAulaRepository _aulaRepository;
        private IAlunoRepository _alunoRepository;
        private ITurmaRepository _turmaRepository;

        private const string NENHUM_ALUNO_ENCOTRADO_PARA_TURMA = "Nenhum aluno encontrado para a turma de {0}";
        private const string NENHUMA_AULA_ENCOTRADA_NESTA_DATA = "Nenhuma aula encontrada para esta data {0}";


        public AulaService(IAulaRepository repoAula, IAlunoRepository repoAluno, ITurmaRepository repoTurma, IUnitOfWork unitOfWork)
        {
            _aulaRepository = repoAula;
            _alunoRepository = repoAluno;
            _turmaRepository = repoTurma;
            _unitOfWork = unitOfWork;
        }

        public void Add(AulaDTO aulaDto)
        {
            Turma turma = _turmaRepository.GetById(aulaDto.TurmaId);

            Aula aula = new Aula(aulaDto.Data, turma);

            _aulaRepository.Add(aula);

            _unitOfWork.Commit();
        }

        public void RegistraPresenca(RegistroPresencaDTO registroPresenca)
        {
            var alunos = _alunoRepository.GetAllByTurma(registroPresenca.AnoTurma);

            if (alunos == null || alunos.Any() == false)
                throw new AlunoNaoEncontrado(String.Format(NENHUM_ALUNO_ENCOTRADO_PARA_TURMA, registroPresenca.AnoTurma));

            var aula = _aulaRepository.GetByData(registroPresenca.DataAula);

            if (aula == null)
                throw new AulaNaoEncontrada(String.Format(NENHUMA_AULA_ENCOTRADA_NESTA_DATA, registroPresenca.DataAula));

            foreach (var item in registroPresenca.PresencaAlunos)
            {
                var aluno = alunos.First(x => x.Id == item.AlunoId);

                aluno.RegistraPresenca(aula, item.Status);

                _alunoRepository.Update(aluno);
            }

            _unitOfWork.Commit();
        }

        public void Update(AulaDTO aulaDto)
        {
            Aula aula = _aulaRepository.GetById(aulaDto.Id);

            aula.Data = aulaDto.Data;

            _aulaRepository.Update(aula);

            _unitOfWork.Commit();
        }      

        public void Delete(int id)
        {
            _aulaRepository.Delete(id);

            _unitOfWork.Commit();
        }

        public AulaDTO GetById(int id)
        {
            var aula = _aulaRepository.GetById(id);

            return new AulaDTO
            {
                Id = aula.Id,
                Data= aula.Data
            };
        }

        public IEnumerable<AulaDTO> GetAllByTurma(int ano)
        {
            return _aulaRepository
                .GetAllByTurma(ano)                
                .Select(aula => new AulaDTO(aula))
                .ToList();
        }
    }
}
