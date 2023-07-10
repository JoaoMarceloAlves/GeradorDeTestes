using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Dominio.ModuloTeste;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gerador.WinApp.ModuloTeste
{
    public partial class TelaVisualizarTesteForm : Form
    {
        public TelaVisualizarTesteForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }

        public void AtualizarLista(List<Questao> questoes)
        {
            listQuestoes.Items.Clear();

            foreach (Questao questao in questoes)
            {
                listQuestoes.Items.Add(" * " + questao);
            }
        }

        public void CarregarLista(List<Questao> questoes)
        {
            AtualizarLista(questoes);
        }

        public void CarregarLabel(Teste testes)
        {
            labelTitulo.Text = testes.disciplina.ToString();
            labelDisciplina.Text = testes.titulo;
            labelMateria.Text = testes.materia.ToString();
        }

    }
}
