using FluentResults;
using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.WinApp.Compartilhado;

namespace GeradorDeTestes.WinApp.ModuloDisciplina
{
    public partial class TelaDisciplinaForm : Form
    {
        List<Disciplina> disciplinas = new List<Disciplina>();
        public GravarRegistroDelegate<Disciplina> onGravarRegistro;

        public TelaDisciplinaForm(List<Disciplina> disciplinaa)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            this.disciplinas = disciplinaa;

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

            Result resultado = onGravarRegistro(Disciplina);

            if (resultado.IsFailed)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(resultado.Errors[0].Message);

                DialogResult = DialogResult.None;
            }
        }
    }
}
