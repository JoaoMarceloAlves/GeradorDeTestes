using GeradorDeTestes.Dominio.ModuloQuestao;

namespace GeradorDeTestes.WinApp.ModuloQuestao
{
    public partial class TelaQuestaoForm : Form
    {
        private List<Alternativa> alternativas;
        private Alternativa resposta;
        private List<Materia> materias;
        public TelaQuestaoForm(List<Materia> materias)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            this.alternativas = new List<Alternativa>();
            this.materias = materias;
        }

        private void CarregarMaterias()
        {
            foreach(Materia materia in this.materias)
            {
                cmbMateria.Items.Add(materia.nome);
            }
            cmbMateria.SelectedIndex = 0;
        }

        public Questao ObterQuestao()
        {
            int id = Convert.ToInt32(txtId.Text);

            string enunciado = txtEnunciado.Text;

            Alternativa resposta = new Alternativa((string)txtAlternativas.CheckedItems[0]);

            Materia materia = materias.Find(m => m.nome == (string)cmbMaterias.SelectedItem);

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

            cmbMateria.SelectedItem = questao.materia.nome;

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

            string[] erros = alternativa.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

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

            string[] erros = questao.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }

        public string[] Validar()
        {
            List<String> erros = new List<String>();

            if (txtAlternativas.CheckedItems.Count == 0)
            {
                erros.Add("É obrigatório marcar uma resposta");
            }

            if (txtAlternativas.CheckedItems.Count > 1)
            {
                erros.Add("Não é permitido marcar mais de uma resposta");
            }

            return erros.ToArray();
        }
    }
}
