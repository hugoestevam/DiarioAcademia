using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AulaForms
{
    public partial class AulaControl : UserControl
    {
        private Aplicacao.Services.IAulaService _aulaService;

        public AulaControl()
        {
            InitializeComponent();
        }

        public AulaControl(Aplicacao.Services.IAulaService _aulaService) : this()
        {
            // TODO: Complete member initialization
            this._aulaService = _aulaService;
        }

        internal void RefreshGrid()
        {
            throw new NotImplementedException();
        }

        internal Aplicacao.DTOs.AulaDTO GetAulaSelecionada()
        {
            throw new NotImplementedException();
        }
    }
}
