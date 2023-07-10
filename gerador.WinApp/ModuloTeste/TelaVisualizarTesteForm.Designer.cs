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
            labelTitulo = new Label();
            labelDisciplina = new Label();
            labelMateria = new Label();
            listQuestoes = new ListBox();
            groupBox1 = new GroupBox();
            btnFechar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lbtitulo
            // 
            lbtitulo.AutoSize = true;
            lbtitulo.Location = new Point(54, 18);
            lbtitulo.Name = "lbtitulo";
            lbtitulo.Size = new Size(40, 15);
            lbtitulo.TabIndex = 0;
            lbtitulo.Text = "Título:";
            // 
            // lbMateria
            // 
            lbMateria.AutoSize = true;
            lbMateria.Location = new Point(44, 88);
            lbMateria.Name = "lbMateria";
            lbMateria.Size = new Size(50, 15);
            lbMateria.TabIndex = 1;
            lbMateria.Text = "Matéria:";
            // 
            // lbDisciplina
            // 
            lbDisciplina.AutoSize = true;
            lbDisciplina.Location = new Point(33, 53);
            lbDisciplina.Name = "lbDisciplina";
            lbDisciplina.Size = new Size(61, 15);
            lbDisciplina.TabIndex = 2;
            lbDisciplina.Text = "Disciplina:";
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Location = new Point(100, 18);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(52, 15);
            labelTitulo.TabIndex = 4;
            labelTitulo.Text = "---------";
            // 
            // labelDisciplina
            // 
            labelDisciplina.AutoSize = true;
            labelDisciplina.Location = new Point(100, 53);
            labelDisciplina.Name = "labelDisciplina";
            labelDisciplina.Size = new Size(52, 15);
            labelDisciplina.TabIndex = 5;
            labelDisciplina.Text = "---------";
            // 
            // labelMateria
            // 
            labelMateria.AutoSize = true;
            labelMateria.Location = new Point(100, 88);
            labelMateria.Name = "labelMateria";
            labelMateria.Size = new Size(52, 15);
            labelMateria.TabIndex = 6;
            labelMateria.Text = "---------";
            // 
            // listQuestoes
            // 
            listQuestoes.FormattingEnabled = true;
            listQuestoes.ItemHeight = 15;
            listQuestoes.Location = new Point(9, 22);
            listQuestoes.Name = "listQuestoes";
            listQuestoes.Size = new Size(416, 244);
            listQuestoes.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listQuestoes);
            groupBox1.Location = new Point(24, 122);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(431, 282);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lista De Questões:";
            // 
            // btnFechar
            // 
            btnFechar.DialogResult = DialogResult.Cancel;
            btnFechar.Location = new Point(343, 410);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(112, 40);
            btnFechar.TabIndex = 9;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            // 
            // TelaVisualizarTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 462);
            Controls.Add(btnFechar);
            Controls.Add(groupBox1);
            Controls.Add(labelMateria);
            Controls.Add(labelDisciplina);
            Controls.Add(labelTitulo);
            Controls.Add(lbDisciplina);
            Controls.Add(lbMateria);
            Controls.Add(lbtitulo);
            Name = "TelaVisualizarTesteForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Visualização de Testes";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbtitulo;
        private Label lbMateria;
        private Label lbDisciplina;
        private Label labelTitulo;
        private Label labelDisciplina;
        private Label labelMateria;
        private ListBox listQuestoes;
        private GroupBox groupBox1;
        private Button btnFechar;
    }
}