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

        public ControladorTeste(IRepositorioTeste repositorioTeste, 
            IRepositorioDisciplina repositorioDisciplina,
            IRepositorioMateria repositorioMateria)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
        }

        public override string ToolTipInserir { get { return "Inserir novo Teste"; } }

        public override string ToolTipEditar { get { return "Editar Teste Existente"; } }

        public override string ToolTipExcluir { get { return "Excluir Teste Existente"; } }

        public override void Inserir()
        {
            TelaTesteForm telaTeste = new TelaTesteForm(repositorioMateria.SelecionarTodos(),repositorioDisciplina.SelecionarTodos());

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
    }
}
