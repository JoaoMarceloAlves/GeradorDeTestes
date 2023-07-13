using FluentResults;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;

namespace GeradorDeTestes.WinApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        private List<Alternativa> alternativas;
        private Alternativa resposta;
        private List<Materia> materias;

        public event GravarRegistroDelegate<Questao> onGravarRegistro;
        public event GravarRegistroDelegate<Alternativa> onAdicionarAlternativa;
        public TelaQuestaoForm(List<Materia> materias)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            this.alternativas = new List<Alternativa>();
            this.materias = materias;
            CarregarMaterias();
        }

        private void CarregarMaterias()
        {
            foreach (Materia materia in this.materias)
            {
                cmbMateria.Items.Add(materia.Nome);
            }
            cmbMateria.SelectedIndex = 0;
        }

        public Questao ObterQuestao()
        {
            int id = Convert.ToInt32(txtId.Text);

            string enunciado = txtEnunciado.Text;

            Alternativa resposta = txtAlternativas.CheckedItems.Count == 0 ? null :
                new Alternativa((string)txtAlternativas.CheckedItems[0]);

            Materia materia = materias.Find(m => m.Nome == (string)cmbMateria.SelectedItem);

            Questao questao = new Questao(enunciado, resposta, this.alternativas, materia);

            if (id > 0)
                questao.id = id;

            return questao;
        }

        private Alternativa ObterAlternativa()
        {
            string descricao = txtResposta.Text;

            return new Alternativa(descricao);
        }

        public void ConfigurarTela(Questao questao)
        {
            txtId.Text = questao.id.ToString();

            txtEnunciado.Text = questao.enunciado;

            this.resposta = questao.resposta;

            this.alternativas = questao.alternativas;

            cmbMateria.SelectedItem = questao.materia.Nome;

            CarregarLista();
        }

        private void CarregarLista()
        {
            foreach (Alternativa alternativa in this.alternativas)
            {
                txtAlternativas.Items.Add(alternativa.descricao);
            }

            int index = txtAlternativas.Items.IndexOf(this.resposta.descricao);
            txtAlternativas.SetItemChecked(index, true);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Alternativa alternativa = ObterAlternativa();

            Result resultado = onAdicionarAlternativa(alternativa);

            if (resultado.IsFailed)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(resultado.Errors[0].Message);

                return;
            }

            this.alternativas.Add(alternativa);
            txtAlternativas.Items.Add(alternativa.descricao);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            this.alternativas = new List<Alternativa>();
            txtAlternativas.Items.Clear();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Questao questao = ObterQuestao();

            Result resultado = onGravarRegistro(questao);

            if (resultado.IsFailed)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(resultado.Errors[0].Message);

                DialogResult = DialogResult.None;
            }

        }

        private void txtAlternativas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue != CheckState.Checked || txtAlternativas.CheckedItems.Count < 1)
                return;

            int[] indices = txtAlternativas.CheckedIndices.Cast<int>().ToArray<int>();
            foreach (int i in indices)
            {
                txtAlternativas.SetItemChecked(i, false);
            }
        }
    }
}
