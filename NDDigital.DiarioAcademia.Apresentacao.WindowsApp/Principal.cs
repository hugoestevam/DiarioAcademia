using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.Shared;
using NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Properties;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AlunoForms;
using NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.TurmaForms;
using NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AulaForms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp
{
    public partial class Principal : Form
    {
        private static Principal _instance;
        private DataManager _dataManager;
        private UserControl _control;
       
        private ITurmaService _turmaService;

        private IEnumerable<TurmaDTO> turmas; 

        public Principal()
        {
            InitializeComponent();

            _instance = this;

            var factory = new DatabaseFactory();

            var unitOfWork = new UnitOfWork(factory);

            var turmaRepository = new TurmaRepository(factory);

            _turmaService = new TurmaService(turmaRepository, unitOfWork);

            AtualizaListaTurmas();

            SelecionaTurmaAnoAtual();
        }

        private void SelecionaTurmaAnoAtual()
        {
            TurmaDTO turmaSelecionada = turmas.FirstOrDefault(x => x.Ano == DateTime.Now.Year);

            if (turmaSelecionada != null)
                cmbTurmas.SelectedItem = turmaSelecionada;
        }       

        public static Principal Instance
        {
            get
            {
                return _instance;
            }
        }

        public int AnoTurmaSelecionado
        {
            get
            {
                var turmaSelecionada = cmbTurmas.SelectedItem as TurmaDTO;

                return turmaSelecionada.Ano;
            }
        }

        public void ShowErrorInFooter(string message)
        {
            statusMessage.Text = message;
            statusImage.Image = Resources.Symbol_Error_3;
        }

        public void ShowSucessInFooter(string message)
        {
            statusMessage.Text = message;
            statusImage.Image = Resources.Symbol_Check;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _dataManager.AddData();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _dataManager.DeleteData();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _dataManager.UpdateData();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnRegistraPresenca_Click(object sender, EventArgs e)
        {
            try
            {
                _dataManager.RegistraPresenca();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }


        /// <summary>
        /// O Método LoadDataManager() é responsável por definir o contexto de cadastro da tela principal,
        /// ou seja, quando o usuário seleciona uma opção da barra de menu, esta operação carrega o UserControl
        /// correspondente, atualiza o título da janela e também os Tooltips dos botões.
        /// </summary>
        /// <param name="manager"></param>
        private void LoadDataManager(DataManager manager)
        {
            try
            {
                if (_dataManager != null && _dataManager.GetType() == manager.GetType())
                    return;

                if (_control != null)
                {
                    panelPrincipal.Controls.Clear();
                }

                statusImage.Image = null;
                statusMessage.Text = "";

                _dataManager = manager;

                _control = _dataManager.GetControl();

                _control.Dock = DockStyle.Fill;

                panelPrincipal.Controls.Add(_control);

                labelTipoCadastro.Text = "Operação selecionada: " + _dataManager.GetDescription();

                
                btnAdd.ToolTipText = _dataManager.GetToolTipMessage().Add;
                btnRegistraPresenca.ToolTipText = _dataManager.GetToolTipMessage().RegistraPresenca;
                btnUpdate.ToolTipText = _dataManager.GetToolTipMessage().Edit;
                btnDelete.ToolTipText = _dataManager.GetToolTipMessage().Delete;                

                btnAdd.Enabled = _dataManager.GetStateButtons().Add;
                btnRegistraPresenca.Enabled = _dataManager.GetStateButtons().RegistraPresenca;
                btnUpdate.Enabled = _dataManager.GetStateButtons().Update;
                btnDelete.Enabled = _dataManager.GetStateButtons().Delete;


                toolbar.Enabled = _dataManager != null;
            }
            catch (Exception be)
            {
                MessageBox.Show(be.Message);
            }
        }

        private void alunosMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataManager(new AlunoDataManager());
        }

        private void turmasMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataManager(new TurmaDataManager());
        }
        private void aulasMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataManager(new AulaDataManager());
        }

        public void AtualizaListaTurmas()
        {
            turmas = _turmaService.GetAll();

            cmbTurmas.Items.Clear();

            foreach (var turma in turmas)
            {
                cmbTurmas.Items.Add(turma);
            }
        }

        private void cmbTurmas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_control == null)
            {
                return;
            }

            panelPrincipal.Controls.Clear();

            _control = _dataManager.GetControl();

            _control.Dock = DockStyle.Fill;

            panelPrincipal.Controls.Add(_control);
        }

        
        
    }
}
