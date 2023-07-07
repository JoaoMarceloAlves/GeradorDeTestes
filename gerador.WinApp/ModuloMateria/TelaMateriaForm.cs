using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using static GeradorDeTestes.Dominio.ModuloMateria.Materia;

namespace GeradorDeTestes.WinApp.ModuloMateria
{
    public partial class TelaMateriaForm : Form
    {
        public List<Disciplina> disciplinas;
        public List<Materia> materias = new List<Materia>();

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

            string serie = grpboxSerie.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;

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
            if (radiobtn1Serie.Checked == false && radiobtn2serie.Checked == false)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Obrigatório selecionar uma Série");
                DialogResult = DialogResult.None;
                return;
            }

            Materia materia = ObterMateria();

            string[] erros = materia.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }

            int numero = materias.FindAll(m => m.Nome.ToLower() == txtNome.Text.ToLower() && m.id != materia.id).Count();

            if (numero > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Nome da 'Matéria' já existe");

                DialogResult = DialogResult.None;
            }

            string[] outrosErros = ValidarOutros();

            if (outrosErros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(outrosErros[0]);

                DialogResult = DialogResult.None;
            }
        }

        public string[] ValidarOutros()
        {
            List<string> erros = new List<string>();

            if (grpboxSerie.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text == null)
            {
                erros.Add("Obrigatório selecionar uma Série");
            }
            if (cmbDisciplina.SelectedItem == null)
            {
                erros.Add("Obrigatório selecionar uma Disciplina");
            }

            return erros.ToArray();
        }
    }
}
