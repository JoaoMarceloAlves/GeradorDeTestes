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
using gerador.WinApp.ModuloTeste;
using GerardorDeTestes.Aplicacao.ModuloQuestao;
using GerardorDeTestes.Aplicacao.ModuloTeste;
using GerardorDeMaterias.Aplicacao.ModuloMateria;
using GerardorDeDisciplinas.Aplicacao.ModuloDisciplina;

namespace GeradorDeTestes.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;

        private IRepositorioMateria repositorioMateria = new RepositorioMateriaEmSql();
        private IRepositorioQuestao repositorioQuestao = new RepositorioQuestaoEmSql();
        private IRepositorioDisciplina repositorioDisciplina = new RepositorioDisciplinaSql();
        private IRepositorioTeste repositorioTeste = new RepositorioTesteEmSql();

        private ServicoQuestao servicoQuestao;
        private ServicoTeste servicoTeste;
        private ServicoMateria servicoMateria;
        private ServicoDisciplina servicoDisciplina;

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
            btnDuplicar.ToolTipText = controlador.ToolTipDuplicar;
            btnGerar.ToolTipText = controlador.ToolTipGerarPdf;
            btnVisualizarTestes.ToolTipText = controlador.ToolTipVisualizarTestes;
        }

        private void ConfigurarEstados(ControladorBase controlador)
        {
            btnInserir.Enabled = controlador.InserirHabilitado;
            btnEditar.Enabled = controlador.EditarHabilitado;
            btnExcluir.Enabled = controlador.ExcluirHabilitado;
            btnDuplicar.Enabled = controlador.DuplicarHabilitado;
            btnGerar.Enabled = controlador.GerarPdfHabilitado;
            btnVisualizarTestes.Enabled = controlador.VisualizarTestesHabilitado;
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

        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            controlador.Duplicar();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            controlador.GerarPdf();
        }

        private void matériasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (servicoMateria == null)
                servicoMateria = new ServicoMateria(repositorioMateria);

            controlador = new ControladorMateria(repositorioMateria, 
                repositorioDisciplina, 
                repositorioQuestao, servicoMateria);

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnQuestoes_Click(object sender, EventArgs e)
        {
            if(servicoQuestao == null)
                servicoQuestao = new ServicoQuestao(repositorioQuestao);

            controlador = new ControladorQuestao(repositorioQuestao, 
                repositorioMateria, 
                servicoQuestao);

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnDisciplinas_Click(object sender, EventArgs e)
        {
            if(servicoDisciplina == null)
                servicoDisciplina = new ServicoDisciplina(repositorioDisciplina);

            controlador = new ControladorDisciplina(repositorioDisciplina, 
                repositorioMateria, 
                repositorioTeste,
                servicoDisciplina);

            ConfigurarTelaPrincipal(controlador);
        }

        private void testesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (servicoTeste == null)
                servicoTeste = new ServicoTeste(repositorioTeste);

            controlador = new ControladorTeste(repositorioTeste, 
                repositorioDisciplina, 
                repositorioMateria, 
                repositorioQuestao, 
                servicoTeste);

            ConfigurarTelaPrincipal(controlador);
        }

        private void btnVisualizarTestes_Click(object sender, EventArgs e)
        {
            controlador.VisualizarDetalhesTeste();
        }
    }
}