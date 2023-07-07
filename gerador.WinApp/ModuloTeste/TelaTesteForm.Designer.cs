namespace gerador.WinApp.ModuloTeste
{
    partial class TelaTesteForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTitulo = new TextBox();
            label5 = new Label();
            checkProva = new CheckBox();
            cmbMateria = new ComboBox();
            cmbDisciplina = new ComboBox();
            numericQtdQuestoes = new NumericUpDown();
            btnGravar = new Button();
            btnCancelar = new Button();
            groupBox1 = new GroupBox();
            listboxQuestoes = new ListBox();
            btnSortear = new Button();
            ((System.ComponentModel.ISupportInitialize)numericQtdQuestoes).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 32);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Título:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 119);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 1;
            label2.Text = "Matéria:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 76);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 2;
            label3.Text = "Disciplina:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(315, 76);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 3;
            label4.Text = "Qtd. Questões:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(111, 24);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(359, 23);
            txtTitulo.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(345, 119);
            label5.Name = "label5";
            label5.Size = new Size(125, 15);
            label5.TabIndex = 5;
            label5.Text = "Prova De Recuperação";
            // 
            // checkProva
            // 
            checkProva.AutoSize = true;
            checkProva.Location = new Point(324, 120);
            checkProva.Name = "checkProva";
            checkProva.Size = new Size(15, 14);
            checkProva.TabIndex = 6;
            checkProva.UseVisualStyleBackColor = true;
            // 
            // cmbMateria
            // 
            cmbMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMateria.FormattingEnabled = true;
            cmbMateria.Location = new Point(112, 113);
            cmbMateria.Name = "cmbMateria";
            cmbMateria.Size = new Size(185, 23);
            cmbMateria.TabIndex = 7;
            // 
            // cmbDisciplina
            // 
            cmbDisciplina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDisciplina.FormattingEnabled = true;
            cmbDisciplina.Location = new Point(112, 69);
            cmbDisciplina.Name = "cmbDisciplina";
            cmbDisciplina.Size = new Size(184, 23);
            cmbDisciplina.TabIndex = 8;
            // 
            // numericQtdQuestoes
            // 
            numericQtdQuestoes.Location = new Point(408, 69);
            numericQtdQuestoes.Name = "numericQtdQuestoes";
            numericQtdQuestoes.Size = new Size(62, 23);
            numericQtdQuestoes.TabIndex = 9;
            numericQtdQuestoes.ThousandsSeparator = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(282, 495);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(101, 44);
            btnGravar.TabIndex = 10;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(389, 495);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 44);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listboxQuestoes);
            groupBox1.Controls.Add(btnSortear);
            groupBox1.Location = new Point(44, 158);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(426, 331);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Questões Selecionadas:";
            // 
            // listboxQuestoes
            // 
            listboxQuestoes.FormattingEnabled = true;
            listboxQuestoes.ItemHeight = 15;
            listboxQuestoes.Location = new Point(21, 72);
            listboxQuestoes.Name = "listboxQuestoes";
            listboxQuestoes.Size = new Size(386, 229);
            listboxQuestoes.TabIndex = 1;
            // 
            // btnSortear
            // 
            btnSortear.Location = new Point(21, 22);
            btnSortear.Name = "btnSortear";
            btnSortear.Size = new Size(108, 33);
            btnSortear.TabIndex = 0;
            btnSortear.Text = "Sortear Questões";
            btnSortear.UseVisualStyleBackColor = true;
            btnSortear.Click += btnSortear_Click;
            // 
            // TelaTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 551);
            Controls.Add(groupBox1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(numericQtdQuestoes);
            Controls.Add(cmbDisciplina);
            Controls.Add(cmbMateria);
            Controls.Add(checkProva);
            Controls.Add(label5);
            Controls.Add(txtTitulo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaTesteForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Testes";
            ((System.ComponentModel.ISupportInitialize)numericQtdQuestoes).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTitulo;
        private Label label5;
        private CheckBox checkProva;
        private ComboBox cmbMateria;
        private ComboBox cmbDisciplina;
        private NumericUpDown numericQtdQuestoes;
        private Button btnGravar;
        private Button btnCancelar;
        private GroupBox groupBox1;
        private ListBox listboxQuestoes;
        private Button btnSortear;
    }
}