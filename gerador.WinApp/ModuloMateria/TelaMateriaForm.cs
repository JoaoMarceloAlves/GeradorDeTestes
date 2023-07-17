using FluentResults;
using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using static GeradorDeTestes.Dominio.ModuloMateria.Materia;

namespace GeradorDeTestes.WinApp.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        public List<Disciplina> disciplinas;
        public List<Materia> materias = new List<Materia>();
        public GravarRegistroDelegate<Materia> onGravarRegistro;

        public TelaMateriaForm(List<Materia> materias)
        {
            InitializeComponent();

            this.ConfigurarDialog();
            this.materias = materias;
        }

        public Materia ObterMateria()
        {
            int id = Convert.ToInt32(txtId.Text);

            string nome = txtNome.Text;

            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;

            string serie = "";

            if (radiobtn1Serie.Checked == false && radiobtn2serie.Checked == false)
            {
                serie = "";
            }
            else
                serie = grpboxSerie.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;

            Materia materia = new Materia(nome, disciplina, serie);

            if (id > 0)
            {
                materia.id = id;
            }

            return materia;
        }

        public void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            this.disciplinas = disciplinas;

            foreach (Disciplina disciplina in disciplinas)
            {
                cmbDisciplina.Items.Add(disciplina);
            }
        }

        public void ConfigurarTela(Materia materia)
        {
            txtId.Text = materia.id.ToString();

            txtNome.Text = materia.Nome;

            cmbDisciplina.SelectedItem = materia.Disciplina;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Materia materia = ObterMateria();

            Result resultado = onGravarRegistro(materia);

            if (resultado.IsFailed)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(resultado.Errors[0].Message);

                DialogResult = DialogResult.None;
            }
        }

    }
}
