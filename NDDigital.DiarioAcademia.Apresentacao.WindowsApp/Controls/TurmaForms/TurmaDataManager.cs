using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.Shared;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using System;
using System.Windows.Forms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.TurmaForms
{
    public class TurmaDataManager : DataManager
    {
        private ITurmaService _turmaService;

        private TurmaControl _control;

        public TurmaDataManager()
        {
            var _factory = Container.Get<UnitOfWorkFactory>();

            var unitOfWork = Container.Get<IUnitOfWork>();

            var turmaRepository = Container.Get<ITurmaRepository>();

            _turmaService = new TurmaService(turmaRepository, unitOfWork);

            _control = new TurmaControl(_turmaService);
        }

        public override void AddData()
        {
            var dialog = new TurmaDialog();

            dialog.Turma = new TurmaDTO();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _turmaService.Add(dialog.Turma);

                _control.RefreshGrid();

                Principal.Instance.AtualizaListaTurmas();
            }
        }

        public override void UpdateData()
        {
            TurmaDTO turmaSelecionada = _control.GetTurma();

            if (turmaSelecionada == null)
            {
                MessageBox.Show("Nenhuma Turma selecionada. Selecionar uma Turma antes de solicitar a edição");
                return;
            }

            var dialog = new TurmaDialog();

            dialog.Turma = turmaSelecionada;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _turmaService.Update(dialog.Turma);

                _control.RefreshGrid();

                Principal.Instance.AtualizaListaTurmas();
            }
        }

        public override void DeleteData()
        {
            TurmaDTO turmaSelecionada = _control.GetTurma();

            if (turmaSelecionada == null)
            {
                MessageBox.Show("Nenhuma Turma selecionada. Selecionar uma Turma antes de solicitar a exclusão");
                return;
            }

            if (MessageBox.Show("Deseja remover a Turma selecionada?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                try
                {
                    _turmaService.Delete(turmaSelecionada.Id);

                    _control.RefreshGrid();

                    Principal.Instance.AtualizaListaTurmas();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public override UserControl GetControl()
        {
            if (_control != null)
                _control.RefreshGrid();

            return _control;
        }

        public override string GetDescription()
        {
            return "Cadastro de Turmas";
        }

        public override ToolTipMessage GetToolTipMessage()
        {
            return new ToolTipMessage
            {
                Add = "Adiciona uma nova Turma",
                Delete = "Exclui a Turma selecionada",
                Edit = "Atualiza a Turma selecionada"
            };
        }

        public override StateButtons GetStateButtons()
        {
            return new StateButtons
            {
                Add = true,
                Delete = true,
                Update = true
            };
        }
    }
}