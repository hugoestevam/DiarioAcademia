using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.CepServices;
using System.Collections.Generic;
using System.Linq;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Contracts;

namespace NDDigital.DiarioAcademia.Aplicacao.Services
{
    public interface IAlunoService:IService<AlunoDTO>
    {
        IList<AlunoDTO> GetAllByTurma(int ano);

        Endereco BuscaEnderecoPorCep(string cep);

        void GerarRelatorioAlunosPdf(int ano, string path);
    }

    public class AlunoService : IAlunoService
    {
        private IAlunoRepository _alunoRepository;
        private IUnitOfWork _unitOfWork;
        private ITurmaRepository _turmaRepository;
        private CepWebService _webService;

        public AlunoService(IAlunoRepository repoAluno, ITurmaRepository repoTurma, IUnitOfWork unitOfWork)
        {
            _alunoRepository = repoAluno;
            _turmaRepository = repoTurma;
            _unitOfWork = unitOfWork;
        }

        public void Add(AlunoDTO alunoDto)
        {
            Turma turma = _turmaRepository.GetById(alunoDto.TurmaId);

            Aluno aluno = new Aluno(alunoDto.Descricao.Split(':')[0], turma??new Turma(2007));//todo: turma vem null

            aluno.Endereco.Bairro = alunoDto.Bairro;
            aluno.Endereco.Cep = alunoDto.Cep;
            aluno.Endereco.Localidade = alunoDto.Localidade;
            aluno.Endereco.Uf = alunoDto.Uf;

            _alunoRepository.Add(aluno);

            _unitOfWork.Commit();
        }

        public void Update(AlunoDTO alunoDto)
        {
            Turma turma = _turmaRepository.GetById(alunoDto.TurmaId);

            Aluno aluno = _alunoRepository.GetById(alunoDto.Id);

            aluno.Nome = alunoDto.Descricao.Split(':')[0];
            aluno.Turma = turma;
            aluno.Endereco.Bairro = alunoDto.Bairro;
            aluno.Endereco.Cep = alunoDto.Cep;
            aluno.Endereco.Localidade = alunoDto.Localidade;
            aluno.Endereco.Uf = alunoDto.Uf;

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

            var alunoDto = new AlunoDTO
            {
                Id = aluno.Id,
                Descricao = aluno.Nome,
                TurmaId = aluno.Turma.Id,
                Cep = aluno.Endereco.Cep,
                Bairro = aluno.Endereco.Bairro,
                Localidade = aluno.Endereco.Localidade,
                Uf = aluno.Endereco.Uf
            };

            if (aluno.Turma != null)//todo: extraí turma pois este está vindo null em _alunoRepository.GetById
                alunoDto.TurmaId = aluno.Turma.Id;

            return alunoDto;
        }

        public IList<AlunoDTO> GetAll()
        {
            return _alunoRepository.GetAll()
                .Select(aluno => new AlunoDTO(aluno))
                .ToList();
        }

        public IList<AlunoDTO> GetAllByTurma(int ano)
        {
            return _alunoRepository.GetAllByTurma(ano)
              .Select(aluno => new AlunoDTO(aluno))
              .ToList();
        }

        public Endereco BuscaEnderecoPorCep(string cep)
        {
            _webService = new CepWebService();

            return _webService.PreencheEndereco(cep);
        }

        public void GerarRelatorioAlunosPdf(int ano, string path)
        {
            try
            {
                FileStream fs = new FileStream(path,
                           FileMode.Create, FileAccess.Write, FileShare.None);

                Document doc = new Document();

                PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                doc.Open();

                doc.Add(new Paragraph("Relatório de presenças - Academia do prgramador " + ano +":\n\n"));
                doc.Add(new Paragraph("Alunos/Presenças/Faltas:\n\n"));

                foreach (var listaAluno in GetAllByTurma(ano))
                {
                    doc.Add(new Paragraph(listaAluno.Descricao));
                }

                doc.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }     
          
        }
    }
}