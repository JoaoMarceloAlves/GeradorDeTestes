using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Dominio.ModuloTeste;
using GeradorDeTestes.WinApp;
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
    public partial class TelaTesteForm : Form
    {
        public List<Teste> testes;
        public List<Materia> materias;
        public List<Disciplina> disciplinas;
        public List<Questao> questoes;
        public List<Questao> questoesAleatorias;

        public TelaTesteForm(List<Materia> materias,
            List<Disciplina> disciplinas,
            List<Questao> questoes,
            List<Teste> testes)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.materias = materias;
            this.disciplinas = disciplinas;
            this.questoes = questoes;
            this.testes = testes;

            CarregarComboBoxes(disciplinas, materias);
        }

        public void AtualizarMaterias(Disciplina disciplina)
        {
            questoesAleatorias = new List<Questao>();
            listboxQuestoes.Items.Clear();

            cmbMateria.Items.Clear();
            foreach (Materia materia in disciplina.materias)
            {
                cmbMateria.Items.Add(materia);
            }
            cmbMateria.SelectedIndex = 0;
        }

        public Teste ObterTeste()
        {
            string titulo = txtTitulo.Text;

            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;

            Materia materia = (Materia)cmbMateria.SelectedItem;

            bool ehRecuperacao = checkProva.Checked;

            int quantidadeDeQuestoes = (int)numericQtdQuestoes.Value;

            Teste teste = new Teste(titulo, ehRecuperacao, quantidadeDeQuestoes, disciplina, materia);

            teste.questoes = questoesAleatorias;

            return teste;
        }

        public void ConfigurarTela(Teste teste)
        {
            txtTitulo.Text = teste.titulo;

            cmbDisciplina.SelectedItem = disciplinas.Find(d =>d.id == teste.disciplina.id);

            AtualizarMaterias((Disciplina)cmbDisciplina.SelectedItem);

            cmbMateria.SelectedItem = teste.materia;

            checkProva.Checked = teste.ehRecuperacao;

            numericQtdQuestoes.Value = teste.quantidadeQuestoes;
        }

        public List<Questao> EmbaralharQuestoes(List<Questao> questoes, int numeroQuestoes)
        {
            Random random = new Random();

            questoes.Sort((a, b) => random.Next().CompareTo(random.Next()));

            List<Questao> questoesAleatorias = new List<Questao>();
            for (int i = 0; i < numeroQuestoes; i++)
            {
                questoesAleatorias.Add(questoes[i]);
            }
            return questoesAleatorias;
        }

        private void CarregarComboBoxes(List<Disciplina> disciplinas, List<Materia> materias)
        {
            foreach (Disciplina disciplina in disciplinas)
            {
                cmbDisciplina.Items.Add(disciplina);
            }

            if (cmbDisciplina.Items.Count > 0)
                cmbDisciplina.SelectedIndex = 0;

            foreach (Materia materia in materias)
            {
                cmbMateria.Items.Add(materia);
            }
            if (cmbMateria.Items.Count > 0)
                cmbMateria.SelectedIndex = 0;

            AtualizarMaterias(disciplinas[0]);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Teste teste = ObterTeste();

            string[] erros = teste.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }

            int numero = testes.FindAll(t => t.titulo == txtTitulo.Text && t.id != teste.id).Count();

            if (numero > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Título de 'Teste' já existente");

                DialogResult = DialogResult.None;
            }
        }
        private void btnSortear_Click(object sender, EventArgs e)
        {
            int qtdQuestoes = (int)numericQtdQuestoes.Value;

            Materia materia = (Materia)cmbMateria.SelectedItem;

            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;

            List<Questao> materiaQuestoes = new List<Questao>();

            if (checkProva.Checked)
            {
                foreach (Materia materiaDisciplina in disciplina.materias)
                {
                    materiaQuestoes.AddRange(
                        questoes.FindAll(q => materia.id == q.materia.id));
                }
            }
            else
                materiaQuestoes = questoes.FindAll(q => materia.id == q.materia.id);


            if (qtdQuestoes > materiaQuestoes.Count)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Escolhar um número menor de questões");
                return;
            }

            this.questoesAleatorias = EmbaralharQuestoes(materiaQuestoes, qtdQuestoes);

            listboxQuestoes.Items.Clear();
            foreach (Questao questao in questoesAleatorias)
            {
                listboxQuestoes.Items.Add(questao);
            }
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarMaterias((Disciplina)cmbDisciplina.SelectedItem);
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkProva.Checked)
                return;

            questoesAleatorias = new List<Questao>();

            listboxQuestoes.Items.Clear();
        }
    }
}
