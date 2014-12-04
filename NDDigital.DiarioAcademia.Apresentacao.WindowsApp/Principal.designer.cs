namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alunosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turmasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aulasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.cmbTurmas = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRegistraPresenca = new System.Windows.Forms.ToolStripButton();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnRelatorio = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(741, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alunosMenuItem,
            this.turmasMenuItem,
            this.aulasMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // alunosMenuItem
            // 
            this.alunosMenuItem.Name = "alunosMenuItem";
            this.alunosMenuItem.Size = new System.Drawing.Size(114, 22);
            this.alunosMenuItem.Text = "Alunos";
            this.alunosMenuItem.Click += new System.EventHandler(this.alunosMenuItem_Click);
            // 
            // turmasMenuItem
            // 
            this.turmasMenuItem.Name = "turmasMenuItem";
            this.turmasMenuItem.Size = new System.Drawing.Size(114, 22);
            this.turmasMenuItem.Text = "Turmas";
            this.turmasMenuItem.Click += new System.EventHandler(this.turmasMenuItem_Click);
            // 
            // aulasMenuItem
            // 
            this.aulasMenuItem.Name = "aulasMenuItem";
            this.aulasMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aulasMenuItem.Text = "Aulas";
            this.aulasMenuItem.Click += new System.EventHandler(this.aulasMenuItem_Click);
            // 
            // toolbar
            // 
            this.toolbar.Enabled = false;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnRegistraPresenca,
            this.btnUpdate,
            this.btnDelete,
            this.btnRelatorio,
            this.toolStripSeparator1,
            this.labelTipoCadastro,
            this.cmbTurmas});
            this.toolbar.Location = new System.Drawing.Point(0, 24);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(741, 43);
            this.toolbar.TabIndex = 1;
            this.toolbar.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(176, 40);
            this.labelTipoCadastro.Text = " Cadastro selecionado: Nenhum";
            // 
            // cmbTurmas
            // 
            this.cmbTurmas.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbTurmas.AutoSize = false;
            this.cmbTurmas.Name = "cmbTurmas";
            this.cmbTurmas.Size = new System.Drawing.Size(250, 23);
            this.cmbTurmas.SelectedIndexChanged += new System.EventHandler(this.cmbTurmas_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusImage,
            this.statusMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 534);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(741, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusImage
            // 
            this.statusImage.Name = "statusImage";
            this.statusImage.Size = new System.Drawing.Size(10, 17);
            this.statusImage.Text = " ";
            // 
            // statusMessage
            // 
            this.statusMessage.Name = "statusMessage";
            this.statusMessage.Size = new System.Drawing.Size(74, 17);
            this.statusMessage.Text = "[mensagem]";
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 67);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(741, 467);
            this.panelPrincipal.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Properties.Resources.Symbol_Add;
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(6);
            this.btnAdd.Size = new System.Drawing.Size(40, 40);
            this.btnAdd.Text = "toolStripButton1";
            this.btnAdd.ToolTipText = " ";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRegistraPresenca
            // 
            this.btnRegistraPresenca.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRegistraPresenca.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistraPresenca.Image")));
            this.btnRegistraPresenca.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRegistraPresenca.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegistraPresenca.Name = "btnRegistraPresenca";
            this.btnRegistraPresenca.Padding = new System.Windows.Forms.Padding(6);
            this.btnRegistraPresenca.Size = new System.Drawing.Size(40, 40);
            this.btnRegistraPresenca.Text = "toolStripButton1";
            this.btnRegistraPresenca.ToolTipText = " ";
            this.btnRegistraPresenca.Click += new System.EventHandler(this.btnRegistraPresenca_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdate.Image = global::NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Properties.Resources.Symbol_Pencil;
            this.btnUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(6);
            this.btnUpdate.Size = new System.Drawing.Size(40, 40);
            this.btnUpdate.Text = "toolStripButton1";
            this.btnUpdate.ToolTipText = " ";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Properties.Resources.Symbol_Delete;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(6);
            this.btnDelete.Size = new System.Drawing.Size(40, 40);
            this.btnDelete.Text = "toolStripButton1";
            this.btnDelete.ToolTipText = " ";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRelatorio.Image = global::NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Properties.Resources.Symbol_PDF;
            this.btnRelatorio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRelatorio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Padding = new System.Windows.Forms.Padding(6);
            this.btnRelatorio.Size = new System.Drawing.Size(36, 40);
            this.btnRelatorio.Text = "toolStripButton1";
            this.btnRelatorio.ToolTipText = " ";
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 556);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.ShowIcon = false;
            this.Text = "Diario da Academia - O braço direito do prof. Panduio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alunosMenuItem;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnUpdate;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusMessage;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.ToolStripButton btnRegistraPresenca;
        private System.Windows.Forms.ToolStripMenuItem turmasMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusImage;
        private System.Windows.Forms.ToolStripComboBox cmbTurmas;
        private System.Windows.Forms.ToolStripMenuItem aulasMenuItem;
        private System.Windows.Forms.ToolStripButton btnRelatorio;
    }
}

