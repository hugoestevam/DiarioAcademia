using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AulaForms
{
    public partial class AulaControl : UserControl
    {
        private IAulaService _aulaService;

        public AulaControl()
        {
            InitializeComponent();
        }

        public AulaControl(IAulaService aulaService) : this()
        {
            this._aulaService = aulaService;
        }

        internal void RefreshGrid()
        {
            int id = Principal.Instance.IdTurmaSelecionada;

            var aulas = _aulaService.GetAllByTurma(id);

            listAulas.Items.Clear();

            foreach (var aula in aulas)
            {
                listAulas.Items.Add(aula);
            }
        }

        internal Aplicacao.DTOs.AulaDTO GetAulaSelecionada()
        {
            AulaDTO aulaSelecionada = listAulas.SelectedItem as AulaDTO;

            return aulaSelecionada;
        }
    }
}
