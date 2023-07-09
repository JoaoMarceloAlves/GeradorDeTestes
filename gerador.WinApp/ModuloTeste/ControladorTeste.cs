using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Dominio.ModuloTeste;
using GeradorDeTestes.WinApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override string ToolTipEditar { get { return "Editar Teste Existente"; } }

        public override string ToolTipExcluir { get { return "Excluir Teste Existente"; } }

        public override string ToolTipVisualizarTestes { get { return "Visualizar Detalhes do Teste"; } }

        public override bool VisualizarTestesHabilitado { get { return true; } }

        public override void Inserir()
        {
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

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
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

        public override void VisualizarDetalhesTeste()
        {
            Teste teste = ObterTesteSelecionado();

            TelaVisualizarTesteForm telaListagem = new TelaVisualizarTesteForm();

            if (teste == null)
            {
                ApresentarMensagem("Selecione um teste primeiro!", "Listagem de teste");
                return;
            }

            telaListagem.CarregarLabel(teste);

            telaListagem.CarregarLista(teste.ListQuestoes);

            telaListagem.ShowDialog();
        }
       

    }
}
