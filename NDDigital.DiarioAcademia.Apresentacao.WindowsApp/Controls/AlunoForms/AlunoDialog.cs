using Infrastructure.DAO.ORM.Common;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AlunoForms
{
    public partial class AlunoDialog : Form
    {
        private AlunoDTO _aluno;
        private IAlunoService _alunoService;

        public AlunoDialog(IEnumerable<TurmaDTO> turmas)
        {
            var unitOfWork = Injection.Get<IUnitOfWork>();

            var alunoRepository = Injection.Get<IAlunoRepository>();

            var turmaRepository = Injection.Get<ITurmaRepository>();

            _alunoService = new AlunoService(alunoRepository, turmaRepository, unitOfWork);

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

                txtCep.Text = _aluno.Cep;

                txtBairro.Text = _aluno.Bairro;

                txtLocalidade.Text = _aluno.Localidade;

                txtUf.Text = _aluno.Uf;

                cmbTurmas.SelectedItem = new TurmaDTO(_aluno.TurmaId);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                _aluno.Id = int.Parse(txtId.Text);

                _aluno.Descricao = txtNome.Text;

                _aluno.Cep = txtCep.Text;

                _aluno.Bairro = txtBairro.Text;

                _aluno.Localidade = txtLocalidade.Text;

                _aluno.Uf = txtUf.Text;

                _aluno.TurmaId = ((TurmaDTO)cmbTurmas.SelectedItem).Id;
            }
            catch (Exception exc)
            {
                Principal.Instance.ShowErrorInFooter(exc.Message);

                DialogResult = DialogResult.None;
            }
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {
            try
            {
                var endereco = _alunoService.BuscaEnderecoPorCep(txtCep.Text);

                txtBairro.Text = endereco.Bairro;
                txtLocalidade.Text = endereco.Localidade;
                txtUf.Text = endereco.Uf;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Serviço indisponível ou CEP incorreto!", "Atenção");
                Principal.Instance.ShowErrorInFooter(ex.Message);
            }
        }
    }
}