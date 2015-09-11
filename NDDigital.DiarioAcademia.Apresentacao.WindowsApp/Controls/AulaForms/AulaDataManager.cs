using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.Shared;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using System;
using System.Windows.Forms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AulaForms
{
    public class AulaDataManager : DataManager
    {
        private IAulaService _aulaService;

        private ITurmaService _turmaService;

        private AlunoService _alunoService;

        private AulaControl _control;

        public AulaDataManager()
        {
            var unitOfWork = Injection.Get<IUnitOfWork>(); 

            var aulaRepository = Injection.Get<IAulaRepository>();

            var alunoRepository = Injection.Get<IAlunoRepository>();

            var turmaRepository = Injection.Get<ITurmaRepository>();

            _aulaService = new AulaService(aulaRepository, alunoRepository, turmaRepository, unitOfWork);

            _alunoService = new AlunoService(alunoRepository, turmaRepository, unitOfWork);

            _turmaService = new TurmaService(turmaRepository, unitOfWork);

            _control = new AulaControl(_aulaService);
        }

        public override void AddData()
        {
            var turmas = _turmaService.GetAll();

            var dialog = new AulaDialog(turmas);

            dialog.Aula = new AulaDTO();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _aulaService.Add(dialog.Aula);

                _control.RefreshGrid();
            }
        }

        public override void UpdateData()
        {
            AulaDTO aulaSelecionada = _control.GetAulaSelecionada();

            if (aulaSelecionada == null)
            {
                MessageBox.Show("Nenhuma Aula selecionada. Selecionar uma Aula antes de solicitar a edição");
                return;
            }

            var turmas = _turmaService.GetAll();

            var dialog = new AulaDialog(turmas);

            dialog.Aula = aulaSelecionada;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _aulaService.Update(dialog.Aula);

                _control.RefreshGrid();
            }
        }

        public override void DeleteData()
        {
            AulaDTO aulaSelecionada = _control.GetAulaSelecionada();

            if (aulaSelecionada == null)
            {
                MessageBox.Show("Nenhuma Aula selecionada. Selecionar uma Aula antes de solicitar a exclusão");
                return;
            }

            if (MessageBox.Show("Deseja remover a Aula selecionada?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                try
                {
                    _aulaService.Delete(aulaSelecionada.Id);

                    _control.RefreshGrid();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public override void RealizaChamada()
        {
            AulaDTO aulaSelecionada = _control.GetAulaSelecionada();

            if (aulaSelecionada == null)
            {
                MessageBox.Show("Nenhuma Aula selecionada. Selecionar uma Aula antes para realizar a chamada dos alunos");
                return;
            }

            ChamadaDTO chamada = _aulaService.GetChamadaByAula(aulaSelecionada);

            ChamadaDialog dialog = new ChamadaDialog();

            dialog.Chamada = chamada;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _aulaService.RealizaChamada(chamada);
            }
        }

        public override UserControl GetControl()
        {
            //   _control?.RefreshGrid(); todo: c# 6
            if (_control != null)
                _control.RefreshGrid();

            return _control;
        }

        public override string GetDescription()
        {
            return "Cadastro de Aulas";
        }

        public override ToolTipMessage GetToolTipMessage()
        {
            return new ToolTipMessage
            {
                Add = "Adiciona uma nova Aula",
                Delete = "Exclui a Aula selecionada",
                Edit = "Atualiza a Aula selecionada",
                RegistraPresenca = "Registra presença dos alunos na aula selecionda"
            };
        }

        public override StateButtons GetStateButtons()
        {
            return new StateButtons
            {
                Add = true,
                Delete = true,
                Update = true,
                RegistraPresenca = true
            };
        }
    }
}