
using GeradorDeTestes.Dominio.ModuloItem;



using GeradorDeTestes.WinApp.ModuloItem;


using GeradorDeTestes.Infra.Dados.Sql.ModuloItem;
using GeradorDeTestes.WinApp.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Infra.Dados.Sql.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Infra.Dados.Sql.ModuloQuestao;
using GeradorDeTestes.WinApp.ModuloQuestao;
using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Infra.Dados.Sql.ModuloDisciplina;
using GeradorDeTestes.WinApp.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloTeste;
using GeradorDeTestes.Infra.Dados.Sql.ModuloTeste;

namespace GeradorDeTestes.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;

        private IRepositorioItem repositorioItem = new RepositorioItemEmSql();
        private IRepositorioMateria repositorioMateria = new RepositorioMateriaEmSql();
        private IRepositorioQuestao repositorioQuestao = new RepositorioQuestaoEmSql();
        private IRepositorioDisciplina repositorioDisciplina = new RepositorioDisciplinaSql();
        private IRepositorioTeste repositorioTeste = new RepositorioTesteEmSql();


        private static TelaPrincipalForm telaPrincipal;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            telaPrincipal = this;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        public static TelaPrincipalForm Instancia
        {
            get
            {
                if (telaPrincipal == null)
                    telaPrincipal = new TelaPrincipalForm();

                return telaPrincipal;
            }
        }


        private void ConfigurarTelaPrincipal(ControladorBase controladorBase)
        {
            labelTipoCadastro.Text = controladorBase.ObterTipoCadastro();

            ConfigurarBarraFerramentas(controlador);

            ConfigurarListagem(controlador);
        }

        private void ConfigurarBarraFerramentas(ControladorBase controlador)
        {
            barraFerramentas.Enabled = true;

            ConfigurarToolTips(controlador);

            ConfigurarEstados(controlador);
        }

        private void ConfigurarListagem(ControladorBase controladorBase)
        {
            UserControl listagem = controladorBase.ObterListagem();

            listagem.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(listagem);
        }

        private void ConfigurarToolTips(ControladorBase controlador)
        {
            btnInserir.ToolTipText = controlador.ToolTipInserir;
            btnEditar.ToolTipText = controlador.ToolTipEditar;
            btnExcluir.ToolTipText = controlador.ToolTipExcluir;
        }

        private void ConfigurarEstados(ControladorBase controlador)
        {
            btnInserir.Enabled = controlador.InserirHabilitado;
            btnEditar.Enabled = controlador.EditarHabilitado;
            btnExcluir.Enabled = controlador.ExcluirHabilitado;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            controlador.Filtrar();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            controlador.Adicionar();
        }

        private void temasMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorItem(repositorioItem);

            ConfigurarTelaPrincipal(controlador);
        }

        private void mat�riasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorMateria(repositorioMateria,repositorioDisciplina);

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnQuestoes_Click(object sender, EventArgs e)
        {
            controlador = new ControladorQuestao(repositorioQuestao, repositorioMateria);

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnDisciplinas_Click(object sender, EventArgs e)
        {
            controlador = new ControladorDisciplina(repositorioDisciplina,repositorioMateria,repositorioTeste);

            ConfigurarTelaPrincipal(controlador);
        }
    }
}