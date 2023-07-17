using FluentResults;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Dominio.ModuloTeste;
using GerardorDeTestes.Aplicacao.ModuloCompartilhado;
using Microsoft.Data.SqlClient;

namespace GerardorDeTestes.Aplicacao.ModuloTeste
{
    public class ServicoTeste : ServicoBase<Teste, IRepositorioTeste, ValidadorTeste> 
    {


        public ServicoTeste(IRepositorioTeste repositorioTeste): 
            base(repositorioTeste, new ValidadorTeste())
        {
        } 

        public override Result Editar(Teste teste)
        {
            List<string> erros = new List<string>() {"Não é permitido editar testes"};
            
            return Result.Fail(erros);
        }

        protected override List<string> ValidarRegistro(Teste teste)
        {
            List<string> erros = base.ValidarRegistro(teste);

            if (TituloDuplicado(teste))
                erros.Add("Não pode inserir teste com mesmo título");

            if (QuestaoComTeste(teste))
                erros.Add("Não pode inserir questões que estão relacionadas a testes");

            return erros;
        }

        private bool TituloDuplicado(Teste teste)
        {
            return repositorioBase.SelecionarPorTitulo(teste).Count > 0;
        }

        private bool QuestaoComTeste(Teste teste)
        {
            bool comTeste = false;
            List<Questao> questoes = repositorioBase.SelecionarQuestoesComTeste();
            foreach(Questao questao in teste.questoes)
            {
                comTeste = comTeste && (questoes.Find(q => q.id == questao.id) != null);
            }
            return comTeste;
        }
    }
}
