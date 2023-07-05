using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using static GeradorDeTestes.Dominio.ModuloMateria.Materia;

namespace GeradorDeTestes.WinApp.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        public List<Disciplina> disciplinas = new List<Disciplina>();
        public List<Materia> materias;

        public TelaMateriaForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            CarregarDisciplinas(disciplinas);

        }

        public Materia ObterMateria()
        {
            int id = Convert.ToInt32(txtId.Text);

            string nome = txtNome.Text;

            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;

            string serie = grpboxSerie.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;

            Materia materia = new Materia(nome, disciplina, serie);

            if (id > 0)
            {
                materia.id = id;
            }

            return materia;
        }

        private void CarregarDisciplinas(List<Disciplina> disciplinas)
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

            txtNome.Text = materia.nome;

            cmbDisciplina.SelectedItem = materia.disciplina;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Materia materia = ObterMateria();

            string[] erros = materia.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }

            int numero = materias.FindAll(m => m.nome == txtNome.Text && m.id != materia.id).Count();

            if (numero > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Nome da 'Matéria' já existe");

                DialogResult = DialogResult.None;
            }
        }
    }
}
