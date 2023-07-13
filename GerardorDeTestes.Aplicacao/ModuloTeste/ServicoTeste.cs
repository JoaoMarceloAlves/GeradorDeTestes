using FluentResults;
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

        public Result Excluir(Teste testeSelecionada)
        {
            List<string> erros = new List<string>();

            try
            {
                repositorioTeste.Excluir(testeSelecionada);

                return Result.Ok();
            }
            catch (SqlException ex)
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

            return erros;
        }

        private bool TituloDuplicado(Teste teste)
        {
            return repositorioTeste.SelecionarPorTitulo(teste).Count > 0;
        }
    }
}
