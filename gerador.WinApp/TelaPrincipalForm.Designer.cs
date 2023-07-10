namespace GeradorDeTestes.WinApp
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            cadastrosMenuItem = new ToolStripMenuItem();
            matériasToolStripMenuItem = new ToolStripMenuItem();
            btnQuestoes = new ToolStripMenuItem();
            btnDisciplinas = new ToolStripMenuItem();
            testesToolStripMenuItem = new ToolStripMenuItem();
            itensToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            labelRodape = new ToolStripStatusLabel();
            barraFerramentas = new ToolStrip();
            btnInserir = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnDuplicar = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnGerar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnVisualizarTestes = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            labelTipoCadastro = new ToolStripLabel();
            panelRegistros = new Panel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            barraFerramentas.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosMenuItem
            // 
            cadastrosMenuItem.DropDownItems.AddRange(new ToolStripItem[] { matériasToolStripMenuItem, btnQuestoes, btnDisciplinas, testesToolStripMenuItem });
            cadastrosMenuItem.Name = "cadastrosMenuItem";
            cadastrosMenuItem.Size = new Size(71, 20);
            cadastrosMenuItem.Text = "Cadastros";
            // 
            // matériasToolStripMenuItem
            // 
            matériasToolStripMenuItem.Name = "matériasToolStripMenuItem";
            matériasToolStripMenuItem.Size = new Size(180, 22);
            matériasToolStripMenuItem.Text = "Matérias";
            matériasToolStripMenuItem.Click += matériasToolStripMenuItem_Click;
            // 
            // btnQuestoes
            // 
            btnQuestoes.Name = "btnQuestoes";
            btnQuestoes.Size = new Size(180, 22);
            btnQuestoes.Text = "Questões";
            btnQuestoes.Click += btnQuestoes_Click;
            // 
            // btnDisciplinas
            // 
            btnDisciplinas.Name = "btnDisciplinas";
            btnDisciplinas.Size = new Size(180, 22);
            btnDisciplinas.Text = "Disciplinas";
            btnDisciplinas.Click += btnDisciplinas_Click;
            // 
            // testesToolStripMenuItem
            // 
            testesToolStripMenuItem.Name = "testesToolStripMenuItem";
            testesToolStripMenuItem.Size = new Size(180, 22);
            testesToolStripMenuItem.Text = "Testes";
            testesToolStripMenuItem.Click += testesToolStripMenuItem_Click;
            // 
            // itensToolStripMenuItem
            // 
            itensToolStripMenuItem.Name = "itensToolStripMenuItem";
            itensToolStripMenuItem.Size = new Size(180, 22);
            itensToolStripMenuItem.Text = "Itens";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { labelRodape });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            labelRodape.Name = "labelRodape";
            labelRodape.Size = new Size(0, 17);
            // 
            // barraFerramentas
            // 
            barraFerramentas.Enabled = false;
            barraFerramentas.ImageScalingSize = new Size(20, 20);
            barraFerramentas.Items.AddRange(new ToolStripItem[] { btnInserir, btnEditar, btnExcluir, toolStripSeparator2, btnDuplicar, toolStripSeparator3, btnGerar, toolStripSeparator1, btnVisualizarTestes, toolStripSeparator5, labelTipoCadastro });
            barraFerramentas.Location = new Point(0, 24);
            barraFerramentas.Name = "barraFerramentas";
            barraFerramentas.Size = new Size(800, 45);
            barraFerramentas.TabIndex = 2;
            barraFerramentas.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            btnInserir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnInserir.Image = gerador.WinApp.Properties.Resources.add_circle_FILL0_wght400_GRAD0_opsz24;
            btnInserir.ImageScaling = ToolStripItemImageScaling.None;
            btnInserir.ImageTransparentColor = Color.Magenta;
            btnInserir.Name = "btnInserir";
            btnInserir.Padding = new Padding(7);
            btnInserir.Size = new Size(42, 42);
            btnInserir.Click += btnInserir_Click;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEditar.Image = gerador.WinApp.Properties.Resources.edit_FILL0_wght400_GRAD0_opsz24;
            btnEditar.ImageScaling = ToolStripItemImageScaling.None;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Padding = new Padding(7);
            btnEditar.Size = new Size(42, 42);
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExcluir.Image = gerador.WinApp.Properties.Resources.delete_FILL0_wght400_GRAD0_opsz241;
            btnExcluir.ImageScaling = ToolStripItemImageScaling.None;
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Padding = new Padding(7);
            btnExcluir.Size = new Size(42, 42);
            btnExcluir.Click += btnExcluir_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 45);
            // 
            // btnDuplicar
            // 
            btnDuplicar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDuplicar.Image = gerador.WinApp.Properties.Resources.content_copy_FILL0_wght400_GRAD0_opsz24;
            btnDuplicar.ImageScaling = ToolStripItemImageScaling.None;
            btnDuplicar.ImageTransparentColor = Color.Magenta;
            btnDuplicar.Name = "btnDuplicar";
            btnDuplicar.Padding = new Padding(7);
            btnDuplicar.Size = new Size(42, 42);
            btnDuplicar.Click += btnDuplicar_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 45);
            // 
            // btnGerar
            // 
            btnGerar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnGerar.Image = gerador.WinApp.Properties.Resources.picture_as_pdf_FILL0_wght400_GRAD0_opsz24;
            btnGerar.ImageScaling = ToolStripItemImageScaling.None;
            btnGerar.ImageTransparentColor = Color.Magenta;
            btnGerar.Name = "btnGerar";
            btnGerar.Padding = new Padding(7);
            btnGerar.Size = new Size(42, 42);
            btnGerar.Click += btnGerar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 45);
            // 
            // btnVisualizarTestes
            // 
            btnVisualizarTestes.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnVisualizarTestes.Image = gerador.WinApp.Properties.Resources.key_visualizer_FILL0_wght400_GRAD0_opsz24;
            btnVisualizarTestes.ImageScaling = ToolStripItemImageScaling.None;
            btnVisualizarTestes.ImageTransparentColor = Color.Magenta;
            btnVisualizarTestes.Name = "btnVisualizarTestes";
            btnVisualizarTestes.Size = new Size(28, 42);
            btnVisualizarTestes.Click += btnVisualizarTestes_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 45);
            // 
            // labelTipoCadastro
            // 
            labelTipoCadastro.Name = "labelTipoCadastro";
            labelTipoCadastro.Size = new Size(0, 42);
            // 
            // panelRegistros
            // 
            panelRegistros.BorderStyle = BorderStyle.FixedSingle;
            panelRegistros.Dock = DockStyle.Fill;
            panelRegistros.Location = new Point(0, 69);
            panelRegistros.Name = "panelRegistros";
            panelRegistros.Size = new Size(800, 359);
            panelRegistros.TabIndex = 3;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelRegistros);
            Controls.Add(barraFerramentas);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "TelaPrincipalForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerador de Testes";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            barraFerramentas.ResumeLayout(false);
            barraFerramentas.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastrosMenuItem;
        private ToolStripMenuItem tarefasMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labelRodape;
        private ToolStrip barraFerramentas;
        private ToolStripButton btnInserir;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private Panel panelRegistros;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel labelTipoCadastro;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem itensToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem matériasToolStripMenuItem;
        private ToolStripMenuItem btnQuestoes;
        private ToolStripMenuItem btnDisciplinas;
        private ToolStripMenuItem testesToolStripMenuItem;
        private ToolStripButton btnDuplicar;
        private ToolStripButton btnGerar;
        private ToolStripButton btnVisualizarTestes;
    }
}