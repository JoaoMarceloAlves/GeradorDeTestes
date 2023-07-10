using GeradorDeTestes.Dominio.ModuloMateria;
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

            Alternativa resposta = new Alternativa((string)txtAlternativas.CheckedItems[0]);

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

            string[] erros = alternativa.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                return;
            }

            if (this.alternativas.Count > 3)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(
                    "Número máximo de alternativas é 4"
                    );

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
            string[] errosTela = Validar();
            if (errosTela.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(errosTela[0]);

                DialogResult = DialogResult.None;

                return;
            }
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
            List<string> erros = new List<string>();

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

        private void txtAlternativas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue != CheckState.Checked || txtAlternativas.CheckedItems.Count < 1)
                return;

            int[] indices = txtAlternativas.CheckedIndices.Cast<int>().ToArray<int>();
            foreach(int i in indices)
            {
                txtAlternativas.SetItemChecked(i, false);
            }
        }
    }
}
