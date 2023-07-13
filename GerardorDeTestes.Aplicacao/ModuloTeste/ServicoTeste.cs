using FluentResults;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Dominio.ModuloTeste;
using Microsoft.Data.SqlClient;

namespace GerardorDeTestes.Aplicacao.ModuloTeste
{
    public class ServicoTeste
    {
        private IRepositorioTeste repositorioTeste;

        public ServicoTeste(IRepositorioTeste repositorioTeste)
        {
            this.repositorioTeste = repositorioTeste;
        }

        public Result Inserir(Teste teste)
        {
            List<string> erros = ValidarTeste(teste);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorioTeste.Inserir(teste);

            return Result.Ok();
        }

        public Result Editar(Teste teste)
        {
            List<string> erros = new List<string>() {"Não é permitido editar testes"};
            
            return Result.Fail(erros);
        }

        public Result Excluir(Teste testeSelecionado)
        {
            List<string> erros = new List<string>();

            try
            {
                repositorioTeste.Excluir(testeSelecionado);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                erros.Add("Este teste não pode ser excluído");
                return Result.Fail(erros);
            }
        }

        private List<string> ValidarTeste(Teste teste)
        {
            List<string> erros = new List<string>(teste.Validar());

            if (TituloDuplicado(teste))
                erros.Add("Não pode inserir teste com mesmo título");

            if (QuestaoComTeste(teste))
                erros.Add("Não pode inserir questões que estão relacionadas a testes");

            return erros;
        }

        private bool TituloDuplicado(Teste teste)
        {
            return repositorioTeste.SelecionarPorTitulo(teste).Count > 0;
        }

        private bool QuestaoComTeste(Teste teste)
        {
            bool comTeste = false;
            List<Questao> questoes = repositorioTeste.SelecionarQuestoesSemTeste();
            foreach(Questao questao in teste.questoes)
            {
                comTeste = comTeste && (questoes.Find(q => q.id == questao.id) != null);
            }
            return comTeste;
        }
    }
}
