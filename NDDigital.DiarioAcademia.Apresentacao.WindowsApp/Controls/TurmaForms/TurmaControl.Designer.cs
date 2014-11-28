namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.TurmaForms
{
    partial class TurmaControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listTurmas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listTurmas
            // 
            this.listTurmas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTurmas.FormattingEnabled = true;
            this.listTurmas.Location = new System.Drawing.Point(0, 0);
            this.listTurmas.Name = "listTurmas";
            this.listTurmas.Size = new System.Drawing.Size(150, 150);
            this.listTurmas.TabIndex = 0;
            // 
            // TurmaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listTurmas);
            this.Name = "TurmaControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listTurmas;
    }
}
