namespace gerador.WinApp.ModuloTeste
{
    partial class TelaVisualizarTesteForm
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
            lbtitulo = new Label();
            lbMateria = new Label();
            lbDisciplina = new Label();
            listQuestoes = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // lbtitulo
            // 
            lbtitulo.AutoSize = true;
            lbtitulo.Location = new Point(113, 32);
            lbtitulo.Name = "lbtitulo";
            lbtitulo.Size = new Size(40, 15);
            lbtitulo.TabIndex = 0;
            lbtitulo.Text = "Título:";
            // 
            // lbMateria
            // 
            lbMateria.AutoSize = true;
            lbMateria.Location = new Point(103, 102);
            lbMateria.Name = "lbMateria";
            lbMateria.Size = new Size(50, 15);
            lbMateria.TabIndex = 1;
            lbMateria.Text = "Matéria:";
            // 
            // lbDisciplina
            // 
            lbDisciplina.AutoSize = true;
            lbDisciplina.Location = new Point(92, 64);
            lbDisciplina.Name = "lbDisciplina";
            lbDisciplina.Size = new Size(61, 15);
            lbDisciplina.TabIndex = 2;
            lbDisciplina.Text = "Disciplina:";
            // 
            // listQuestoes
            // 
            listQuestoes.FormattingEnabled = true;
            listQuestoes.ItemHeight = 15;
            listQuestoes.Location = new Point(113, 193);
            listQuestoes.Name = "listQuestoes";
            listQuestoes.Size = new Size(252, 304);
            listQuestoes.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(172, 32);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 64);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(172, 102);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 6;
            label3.Text = "label3";
            // 
            // TelaVisualizarTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 550);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listQuestoes);
            Controls.Add(lbDisciplina);
            Controls.Add(lbMateria);
            Controls.Add(lbtitulo);
            Name = "TelaVisualizarTesteForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Visualização de Testes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbtitulo;
        private Label lbMateria;
        private Label lbDisciplina;
        private ListBox listQuestoes;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}