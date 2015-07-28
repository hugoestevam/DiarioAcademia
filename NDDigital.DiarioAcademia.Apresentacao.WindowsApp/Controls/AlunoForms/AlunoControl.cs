using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDDigital.DiarioAcademia.Aplicacao.ORM.Services;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AlunoForms
{
    public partial class AlunoControl : UserControl
    {

        private IAlunoService _alunoService;

        public AlunoControl()
        {
            InitializeComponent();
        }

        public AlunoControl(IAlunoService _service)
            : this()
        {
            this._alunoService = _service;
        }

        public AlunoDTO GetAluno()
        {
            AlunoDTO alunoSelecionado = listAlunos.SelectedItem as AlunoDTO;

             alunoSelecionado = _alunoService.GetById(alunoSelecionado.Id);

            return alunoSelecionado;
        }

        public void RefreshGrid()
        {
            int anoTurma = Principal.Instance.AnoTurmaSelecionado;

            var alunos = _alunoService.GetAllByTurma(anoTurma);

            listAlunos.Items.Clear();

            foreach (var aluno in alunos)
            {
                listAlunos.Items.Add(aluno);
            }
        }

    }
}
