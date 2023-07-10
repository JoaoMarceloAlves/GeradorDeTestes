namespace GeradorDeTestes.WinApp.ModuloQuestao
{
    partial class TelaQuestaoForm
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
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            txtEnunciado = new RichTextBox();
            txtResposta = new RichTextBox();
            label3 = new Label();
            btnAdicionar = new Button();
            groupBox1 = new GroupBox();
            txtAlternativas = new CheckedListBox();
            btnRemover = new Button();
            label4 = new Label();
            cmbMateria = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 89);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 18;
            label2.Text = "Enunciado:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(86, 22);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 17;
            txtId.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 25);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 16;
            label1.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(411, 424);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 41);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(330, 424);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 41);
            btnGravar.TabIndex = 14;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtEnunciado
            // 
            txtEnunciado.Location = new Point(86, 86);
            txtEnunciado.Name = "txtEnunciado";
            txtEnunciado.Size = new Size(400, 53);
            txtEnunciado.TabIndex = 20;
            txtEnunciado.Text = "";
            // 
            // txtResposta
            // 
            txtResposta.Location = new Point(86, 145);
            txtResposta.Name = "txtResposta";
            txtResposta.Size = new Size(241, 39);
            txtResposta.TabIndex = 22;
            txtResposta.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 145);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 21;
            label3.Text = "Resposta:";
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(354, 145);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(99, 39);
            btnAdicionar.TabIndex = 23;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtAlternativas);
            groupBox1.Controls.Add(btnRemover);
            groupBox1.Location = new Point(14, 203);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(472, 194);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Alternativas";
            // 
            // txtAlternativas
            // 
            txtAlternativas.FormattingEnabled = true;
            txtAlternativas.Location = new Point(9, 60);
            txtAlternativas.Name = "txtAlternativas";
            txtAlternativas.Size = new Size(457, 112);
            txtAlternativas.TabIndex = 26;
            txtAlternativas.ItemCheck += txtAlternativas_ItemCheck;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(9, 22);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(98, 32);
            btnRemover.TabIndex = 25;
            btnRemover.Text = "Remover Todas";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += btnRemover_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 56);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 25;
            label4.Text = "Matéria:";
            // 
            // cmbMateria
            // 
            cmbMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMateria.FormattingEnabled = true;
            cmbMateria.Location = new Point(86, 53);
            cmbMateria.Name = "cmbMateria";
            cmbMateria.Size = new Size(241, 23);
            cmbMateria.TabIndex = 26;
            // 
            // TelaQuestaoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 477);
            Controls.Add(cmbMateria);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(btnAdicionar);
            Controls.Add(txtResposta);
            Controls.Add(label3);
            Controls.Add(txtEnunciado);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaQuestaoForm";
            Text = "Cadastro de Questões";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private Button btnCancelar;
        private Button btnGravar;
        private RichTextBox txtEnunciado;
        private RichTextBox txtResposta;
        private Label label3;
        private Button btnAdicionar;
        private GroupBox groupBox1;
        private CheckedListBox txtAlternativas;
        private Button btnRemover;
        private Label label4;
        private ComboBox cmbMateria;
    }
}