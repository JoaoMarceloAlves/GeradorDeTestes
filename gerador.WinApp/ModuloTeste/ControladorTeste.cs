using FluentResults;
using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Dominio.ModuloTeste;
using GeradorDeTestes.WinApp;
using GerardorDeTestes.Aplicacao.ModuloTeste;

namespace gerador.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private TabelaTesteControl tabelaTeste;
        private IRepositorioTeste repositorioTeste;
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;
        private IRepositorioQuestao repositorioQuestao;
        private ServicoTeste servicoTeste;

        public ControladorTeste(IRepositorioTeste repositorioTeste, 
            IRepositorioDisciplina repositorioDisciplina,
            IRepositorioMateria repositorioMateria,
            IRepositorioQuestao repositorioQuestao,
            ServicoTeste servicoTeste)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            this.repositorioQuestao = repositorioQuestao;
            this.servicoTeste = servicoTeste;
        }

        public override string ToolTipInserir { get { return "Inserir novo Teste"; } }

        public override string ToolTipEditar { get { return "Não é possível editar testes"; } }

        public override string ToolTipExcluir { get { return "Excluir Teste Existente"; } }

        public override string ToolTipDuplicar { get { return "Duplicar Teste Existente"; } }

        public override string ToolTipGerarPdf { get { return "Gerar PDF de Teste Existente"; } }
        
        public override string ToolTipVisualizarTestes { get { return "Visualizar Detalhes do Teste"; } }

        public override bool VisualizarTestesHabilitado { get { return true; } }
        public override bool EditarHabilitado { get { return false; } }
        public override bool DuplicarHabilitado { get { return true; } }
        public override bool GerarPdfHabilitado { get { return true; } }
        
        public override void Inserir()
        {
            if (repositorioTeste.SelecionarQuestoesSemTeste().Count == 0)
            {
                MessageBox.Show($"Não há questões válidas cadastradas!",
                   "Adição de Testes",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);

                return;
            }

            TelaTesteForm telaTeste = new TelaTesteForm(
                repositorioMateria.SelecionarTodos(),
                repositorioDisciplina.SelecionarTodosCarregados(),
                repositorioTeste.SelecionarQuestoesSemTeste(),
                repositorioTeste.SelecionarTodos());

            telaTeste.ShowDialog();
            telaTeste.onGravarRegistro = servicoTeste.Inserir;

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
                repositorioTeste.SelecionarQuestoesSemTeste(),
                repositorioTeste.SelecionarTodos());

            telaTeste.ConfigurarTela(teste);
            telaTeste.onGravarRegistro = servicoTeste.Inserir;

            telaTeste.ShowDialog();

            CarregarTestes();        
        }

        public override void GerarPdf()
        {
            Teste teste = ObterTesteSelecionado();

            if (teste == null)
            {
                MessageBox.Show($"Selecione um teste primeiro!",
                    "Geração de Pdf de Testes",
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

                MessageBox.Show($"Arquivo gravado em :\nGeradorDeTestes\\gerador.WinApp\\bin\\Debug\\net6.0 - windows\\ArquivosPdf",
                   "Geração de Pdf de Testes",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
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
                Result resultado = servicoTeste.Excluir(teste);
                if (resultado.IsFailed)
                {
                   MessageBox.Show($"{resultado.Errors[0].Message}",
                   "Exclusão de Testes",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
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

            if (id == -1)
                return null;

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

        public override void VisualizarDetalhesTeste()
        {
            Teste teste = ObterTesteSelecionado();

            if (teste == null)
            {
                MessageBox.Show($"Selecione um Teste Primeiro!",
                   "Visualição de Testes",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);

                return;
            }

            TelaVisualizarTesteForm telaListagem = new TelaVisualizarTesteForm();
          
            telaListagem.CarregarLabel(teste);

            telaListagem.CarregarLista(teste.questoes);

            telaListagem.ShowDialog();
        }
       

    }
}
