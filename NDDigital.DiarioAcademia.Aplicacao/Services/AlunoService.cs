using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{    
    public interface IAlunoService 
    {
        void Add(AlunoDTO alunoDto);

        void Update(AlunoDTO alunoDto);

        void Delete(int id);

        AlunoDTO GetById(int id);

        IEnumerable<AlunoDTO> GetAll();

        IEnumerable<AlunoDTO> GetAllByTurma(int ano);       
    }

    public class AlunoService : IAlunoService
    {
        private IAlunoRepository _alunoRepository;
        private IUnitOfWork _unitOfWork;
        private ITurmaRepository _turmaRepository;

        public AlunoService(IAlunoRepository repoAluno, ITurmaRepository repoTurma, IUnitOfWork unitOfWork)
        {
            _alunoRepository = repoAluno;
            _turmaRepository = repoTurma;
            _unitOfWork = unitOfWork;
        }

        public void Add(AlunoDTO alunoDto)
        {
            Turma turma = _turmaRepository.GetById(alunoDto.TurmaId);

            Aluno aluno = new Aluno(alunoDto.Nome, turma);

            _alunoRepository.Add(aluno);

            _unitOfWork.Commit();
        }


        public void Update(AlunoDTO alunoDto)
        {
            Turma turma = _turmaRepository.GetById(alunoDto.TurmaId);

            Aluno aluno = _alunoRepository.GetById(alunoDto.Id);

            aluno.Nome = alunoDto.Nome;
            aluno.Turma = turma;

            _alunoRepository.Update(aluno);

            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _alunoRepository.Delete(id);

            _unitOfWork.Commit();
        }

        public AlunoDTO GetById(int id)
        {
            var aluno = _alunoRepository.GetById(id);

            return new AlunoDTO
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                TurmaId = aluno.Turma.Id
            };
        }

        public IEnumerable<AlunoDTO> GetAll()
        {
            return _alunoRepository.GetAll()
                .Select(aluno => new AlunoDTO(aluno))
                .ToList(); 
        }

        public IEnumerable<AlunoDTO> GetAllByTurma(int ano)
        {
            return _alunoRepository.GetAllByTurma(ano)
              .Select(aluno => new AlunoDTO(aluno))
              .ToList(); 
        }
    }
}