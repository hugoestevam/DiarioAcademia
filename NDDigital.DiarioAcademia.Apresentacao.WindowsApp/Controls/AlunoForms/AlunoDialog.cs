using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AlunoForms
{
    public partial class AlunoDialog : Form
    {
        private AlunoDTO _aluno;

        public AlunoDialog(IEnumerable<TurmaDTO> turmas)
        {
            InitializeComponent();

            cmbTurmas.Items.Clear();

            foreach (var turma in turmas)
            {
                cmbTurmas.Items.Add(turma);
            }
        }

        public AlunoDTO Aluno
        {
            get
            {
                return _aluno;
            }
            set
            {
                _aluno = value;

                txtId.Text = _aluno.Id.ToString();

                txtNome.Text = _aluno.Descricao;

                cmbTurmas.SelectedItem = new TurmaDTO(_aluno.TurmaId);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                _aluno.Id = int.Parse(txtId.Text);

                _aluno.Descricao = txtNome.Text;

                _aluno.TurmaId = ((TurmaDTO)cmbTurmas.SelectedItem).Id;
            }
            catch (Exception exc)
            {
                Principal.Instance.ShowErrorInFooter(exc.Message);

                DialogResult = DialogResult.None;
            }
        }

    }
}