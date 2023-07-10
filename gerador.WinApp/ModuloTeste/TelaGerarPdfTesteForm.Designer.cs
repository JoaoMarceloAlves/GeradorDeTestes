namespace gerador.WinApp.ModuloTeste
{
    partial class TelaGerarPdfTesteForm
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
            btnCancelar = new Button();
            btnGravar = new Button();
            cmbTestes = new ComboBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 9);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 18;
            label2.Text = "Escolha uma opção:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(138, 77);
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
            btnGravar.Location = new Point(57, 77);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 41);
            btnGravar.TabIndex = 14;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // cmbTestes
            // 
            cmbTestes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTestes.FormattingEnabled = true;
            cmbTestes.Location = new Point(25, 37);
            cmbTestes.Name = "cmbTestes";
            cmbTestes.Size = new Size(181, 23);
            cmbTestes.TabIndex = 19;
            // 
            // TelaGerarPdfTesteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(225, 130);
            Controls.Add(cmbTestes);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaGerarPdfTesteForm";
            Text = "Gerador de PDF de Teste";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button btnCancelar;
        private Button btnGravar;
        private ComboBox cmbTestes;
    }
}