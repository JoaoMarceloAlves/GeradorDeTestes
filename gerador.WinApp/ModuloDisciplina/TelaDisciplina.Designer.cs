namespace GeradorDeTestes.WinApp.ModuloDisciplina
{
    partial class TelaDisciplinaForm
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
            txt_Nome = new TextBox();
            btn_Gravar = new Button();
            button2 = new Button();
            txtNome = new Label();
            txtId = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // txt_Nome
            // 
            txt_Nome.Location = new Point(56, 70);
            txt_Nome.Name = "txt_Nome";
            txt_Nome.Size = new Size(255, 23);
            txt_Nome.TabIndex = 0;
            // 
            // btn_Gravar
            // 
            btn_Gravar.DialogResult = DialogResult.OK;
            btn_Gravar.Location = new Point(161, 112);
            btn_Gravar.Name = "btn_Gravar";
            btn_Gravar.Size = new Size(75, 39);
            btn_Gravar.TabIndex = 1;
            btn_Gravar.Text = "Gravar";
            btn_Gravar.UseVisualStyleBackColor = true;
            btn_Gravar.Click += btn_Gravar_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(250, 112);
            button2.Name = "button2";
            button2.Size = new Size(75, 39);
            button2.TabIndex = 2;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            txtNome.AutoSize = true;
            txtNome.Location = new Point(12, 73);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(43, 15);
            txtNome.TabIndex = 3;
            txtNome.Text = "Nome:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(56, 36);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 7;
            txtId.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 39);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 6;
            label1.Text = "Id:";
            // 
            // TelaDisciplinaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 154);
            Controls.Add(txtId);
            Controls.Add(label1);
            Controls.Add(txtNome);
            Controls.Add(button2);
            Controls.Add(btn_Gravar);
            Controls.Add(txt_Nome);
            Name = "TelaDisciplinaForm";
            Text = "Cadastro De Disciplinas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Nome;
        private Button btn_Gravar;
        private Button button2;
        private Label txtNome;
        private TextBox txtId;
        private Label label1;
    }
}