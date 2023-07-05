namespace GeradorDeTestes.WinApp.ModuloQuestao
{
    partial class TabelaQuestaoControl
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
            gridQuestoes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridQuestoes).BeginInit();
            SuspendLayout();
            // 
            // gridQuestoes
            // 
            gridQuestoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridQuestoes.Dock = DockStyle.Fill;
            gridQuestoes.Location = new Point(0, 0);
            gridQuestoes.Name = "gridQuestoes";
            gridQuestoes.RowTemplate.Height = 25;
            gridQuestoes.Size = new Size(150, 150);
            gridQuestoes.TabIndex = 0;
            // 
            // TabelaQuestaoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridQuestoes);
            Name = "TabelaQuestaoControl";
            ((System.ComponentModel.ISupportInitialize)gridQuestoes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridQuestoes;
    }
}
