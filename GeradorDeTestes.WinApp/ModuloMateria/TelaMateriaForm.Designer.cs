namespace GeradorDeTestes.WinApp.ModuloMateria
{
    partial class TelaMateriaForm
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
            lbId = new Label();
            lbnome = new Label();
            lbdisciplina = new Label();
            lbserie = new Label();
            txtId = new TextBox();
            txtNome = new TextBox();
            cmbDisciplina = new ComboBox();
            btnGravar = new Button();
            btnCancelar = new Button();
            radiobtn1Serie = new RadioButton();
            radiobtn2serie = new RadioButton();
            SuspendLayout();
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(65, 34);
            lbId.Name = "lbId";
            lbId.Size = new Size(20, 15);
            lbId.TabIndex = 0;
            lbId.Text = "Id:";
            // 
            // lbnome
            // 
            lbnome.AutoSize = true;
            lbnome.Location = new Point(42, 63);
            lbnome.Name = "lbnome";
            lbnome.Size = new Size(43, 15);
            lbnome.TabIndex = 1;
            lbnome.Text = "Nome:";
            // 
            // lbdisciplina
            // 
            lbdisciplina.AutoSize = true;
            lbdisciplina.Location = new Point(24, 102);
            lbdisciplina.Name = "lbdisciplina";
            lbdisciplina.Size = new Size(61, 15);
            lbdisciplina.TabIndex = 2;
            lbdisciplina.Text = "Disciplina:";
            // 
            // lbserie
            // 
            lbserie.AutoSize = true;
            lbserie.Location = new Point(42, 139);
            lbserie.Name = "lbserie";
            lbserie.Size = new Size(35, 15);
            lbserie.TabIndex = 3;
            lbserie.Text = "Série:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(96, 26);
            txtId.Name = "txtId";
            txtId.Size = new Size(52, 23);
            txtId.TabIndex = 4;
            txtId.Text = "0";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(96, 55);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(295, 23);
            txtNome.TabIndex = 5;
            // 
            // cmbDisciplina
            // 
            cmbDisciplina.FormattingEnabled = true;
            cmbDisciplina.Location = new Point(96, 94);
            cmbDisciplina.Name = "cmbDisciplina";
            cmbDisciplina.Size = new Size(100, 23);
            cmbDisciplina.TabIndex = 6;
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(281, 187);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(97, 40);
            btnGravar.TabIndex = 7;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(397, 187);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(97, 40);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // radiobtn1Serie
            // 
            radiobtn1Serie.AutoSize = true;
            radiobtn1Serie.Location = new Point(96, 139);
            radiobtn1Serie.Name = "radiobtn1Serie";
            radiobtn1Serie.Size = new Size(36, 19);
            radiobtn1Serie.TabIndex = 9;
            radiobtn1Serie.TabStop = true;
            radiobtn1Serie.Text = "1ª";
            radiobtn1Serie.UseVisualStyleBackColor = true;
            // 
            // radiobtn2serie
            // 
            radiobtn2serie.AutoSize = true;
            radiobtn2serie.Location = new Point(160, 139);
            radiobtn2serie.Name = "radiobtn2serie";
            radiobtn2serie.Size = new Size(36, 19);
            radiobtn2serie.TabIndex = 10;
            radiobtn2serie.TabStop = true;
            radiobtn2serie.Text = "2ª";
            radiobtn2serie.UseVisualStyleBackColor = true;
            // 
            // TelaMateriaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 246);
            Controls.Add(radiobtn2serie);
            Controls.Add(radiobtn1Serie);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(cmbDisciplina);
            Controls.Add(txtNome);
            Controls.Add(txtId);
            Controls.Add(lbserie);
            Controls.Add(lbdisciplina);
            Controls.Add(lbnome);
            Controls.Add(lbId);
            Name = "TelaMateriaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Matérias";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbId;
        private Label lbnome;
        private Label lbdisciplina;
        private Label lbserie;
        private TextBox txtId;
        private TextBox txtNome;
        private ComboBox cmbDisciplina;
        private Button btnGravar;
        private Button btnCancelar;
        private RadioButton radiobtn1Serie;
        private RadioButton radiobtn2serie;
    }
}