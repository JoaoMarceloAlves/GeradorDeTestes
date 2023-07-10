using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Dominio.ModuloTeste;
using GeradorDeTestes.WinApp;

namespace gerador.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private TabelaTesteControl tabelaTeste;
        private IRepositorioTeste repositorioTeste;
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;
        private IRepositorioQuestao repositorioQuestao;

        public ControladorTeste(IRepositorioTeste repositorioTeste, 
            IRepositorioDisciplina repositorioDisciplina,
            IRepositorioMateria repositorioMateria,
            IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            this.repositorioQuestao = repositorioQuestao;
        }

        public override string ToolTipInserir { get { return "Inserir novo Teste"; } }

        public override string ToolTipEditar { get { return "Não é possível editar testes"; } }

        public override string ToolTipExcluir { get { return "Excluir Teste Existente"; } }

        public override string ToolTipDuplicar { get { return "Duplicar Teste Existente"; } }

        public override string ToolTipGerarPdf { get { return "Gerar PDF de Teste Existente"; } }

        public override bool EditarHabilitado { get { return false; } }
        public override bool DuplicarHabilitado { get { return false; } }
        public override bool GerarPdfHabilitado { get { return false; } }
        
        public override void Inserir()
        {
            if (repositorioQuestao.SelecionarTodos().Count == 0)
            {
                MessageBox.Show($"Não há questões cadastradas!",
                   "Adição de Testes",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);

                return;
            }

            TelaTesteForm telaTeste = new TelaTesteForm(
                repositorioMateria.SelecionarTodos(),
                repositorioDisciplina.SelecionarTodosCarregados(),
                repositorioQuestao.SelecionarTodos(),
                repositorioTeste.SelecionarTodos());

            DialogResult opcaoEscolhida = telaTeste.ShowDialog();

            if(opcaoEscolhida == DialogResult.OK)
            {
                Teste teste = telaTeste.ObterTeste();

                repositorioTeste.Inserir(teste);
            }
            CarregarTestes();           
        }

        public override void Duplicar()
        {
            Teste teste = ObterTesteSelecionado();

            if (teste == null)
            {
                MessageBox.Show($"Selecione um teste primeiro!",
                    "Exclusão de Testes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaTesteForm telaTeste = new TelaTesteForm(
                repositorioMateria.SelecionarTodos(),
                repositorioDisciplina.SelecionarTodosCarregados(),
                repositorioQuestao.SelecionarTodos(),
                repositorioTeste.SelecionarTodos());

            telaTeste.ConfigurarTela(teste);

            DialogResult opcaoEscolhida = telaTeste.ShowDialog();

            if(opcaoEscolhida == DialogResult.OK)
            {
                Teste novoTeste = telaTeste.ObterTeste();

                repositorioTeste.Inserir(novoTeste);
            }
            CarregarTestes();        
        }

        public override void GerarPdf()
        {
            Teste teste = ObterTesteSelecionado();

            if (teste == null)
            {
                MessageBox.Show($"Selecione um teste primeiro!",
                    "Exclusão de Testes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaGerarPdfTesteForm telaTeste = new TelaGerarPdfTesteForm();

            DialogResult opcaoEscolhida = telaTeste.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                bool ehGabarito = telaTeste.ObterTipoTeste() == TipoTesteEnum.Gabarito;
                GeradorProvasPdf.GerarProva(teste, ehGabarito);
            }
            CarregarTestes();
        }

        public override void Editar()
        {
            MessageBox.Show($"Não é possível editar testes!",
                   "Edição de Testes",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
        }

        public override void Excluir()
        {
            Teste teste = ObterTesteSelecionado();

            if (teste == null)
            {
                MessageBox.Show($"Selecione um teste primeiro!",
                    "Exclusão de Testes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o Teste {teste.titulo}?"
                , "Exclusão de Questões",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioTeste.Excluir(teste);
            }
            CarregarTestes();
        }
   
        public override UserControl ObterListagem()
        {
            if(tabelaTeste == null)
            {
                tabelaTeste = new TabelaTesteControl();  
            }

            CarregarTestes();

            return tabelaTeste;
        }

        private Teste ObterTesteSelecionado()
        {
            int id = tabelaTeste.ObterIdSelecionado();

            return repositorioTeste.SelecionarPorId(id);
        }

        private void CarregarTestes()
        {
            List<Teste> testes = repositorioTeste.SelecionarTodos();

            tabelaTeste.AtualizarRegistros(testes);

            TelaPrincipalForm.Instancia.AtualizarRodape(
                $"Visualizando {testes.Count} Testes"
                );
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Testes";
        }
    }
}
