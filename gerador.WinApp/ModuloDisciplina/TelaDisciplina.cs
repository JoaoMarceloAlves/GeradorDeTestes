using GeradorDeTestes.Dominio.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.WinApp.ModuloDisciplina
{
    public partial class TelaDisciplinaForm : Form
    {
        public TelaDisciplinaForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();

        }

        public Disciplina ObterDisciplina()
        {
            int id = Convert.ToInt32(txtId.Text);

            string nome = txt_Nome.Text;



            Disciplina Disciplina = new Disciplina(nome);

            if (id > 0)
                Disciplina.id = id;

            return Disciplina;
        }

        public void ConfigurarTela(Disciplina Disciplina)
        {
            txtId.Text = Disciplina.id.ToString();

            txt_Nome.Text = Disciplina.nome;


        }



        private void btn_Gravar_Click(object sender, EventArgs e)
        {
            Disciplina Disciplina = ObterDisciplina();

            string[] erros = Disciplina.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
    }
}
