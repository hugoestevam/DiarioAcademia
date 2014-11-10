using iTextSharp.text;
using iTextSharp.text.pdf;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Aplicacao
{
    public interface IAlunoService
    {
        void Salvar(string nome, string cep);

        string GerarRelatorioAlunosFaltantes();
    }

    public class AlunoService : IAlunoService
    {
        private IAlunoRepository _alunoRepository;
        private IUnitOfWork _unitOfWork;
        private IEnderecoRepository _enderecoRepository;

        public AlunoService(IAlunoRepository repoAluno, IEnderecoRepository repoEndereco, IUnitOfWork unitOfWork)
        {
            _alunoRepository = repoAluno;
            _enderecoRepository = repoEndereco;
            _unitOfWork = unitOfWork;
        }

        public void Salvar(string nome, string cep)
        {
            Endereco endereco = _enderecoRepository.GetEnderecoByCep(cep);         

            Aluno aluno = new Aluno();
            aluno.Endereco = endereco;

            _alunoRepository.Add(aluno);

            _unitOfWork.Commit();
            
        }


        public string GerarRelatorioAlunosFaltantes()
        {
            var document = new Document(PageSize.A4, 50, 50, 25, 25);

            // Create a new PdfWriter object, specifying the output stream
            var output = new FileStream(("C:\temp\relatorio.pdf"), FileMode.Create);

            var writer = PdfWriter.GetInstance(document, output);

            //var alunos = _alunoRepository.GetAllFaltates();

            // Open the Document for writing
            document.Open();           

            // Close the Document - this saves the document contents to the output stream
            document.Close();

            return "C:\temp\relatorio.pdf";
        }
        
    }
}
