using FluentResults;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GerardorDeTestes.Aplicacao.ModuloCompartilhado;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using Serilog;

namespace GerardorDeTestes.Aplicacao.ModuloQuestao
{
    public class ServicoQuestao : ServicoBase<Questao, IRepositorioQuestao, ValidadorQuestao>
    {
        ValidadorAlternativa validadorAlternativa;
        public ServicoQuestao(IRepositorioQuestao repositorioQuestao) : 
            base(repositorioQuestao, new ValidadorQuestao())
        {
            this.validadorAlternativa = new ValidadorAlternativa();
        } 

        public override Result Excluir(Questao questao)
        {

            Log.Debug("Tentando excluir questão...{@q}", questao);

            try
            {
                repositorioBase.Excluir(questao);

                Log.Debug("Questão {questaoId} excluída com sucesso", questao.id);
            }
            catch (SqlException ex)
            {
                string mensagemErro = "Falha ao tentar excluir questão";

                if (ex.Message.Contains("TbTeste"))
                    mensagemErro = "Esta questao está relacionada com um teste e não pode ser excluída";

                Log.Error(ex, mensagemErro + "{r}", questao);

                return Result.Fail(mensagemErro);
            }

            return Result.Ok();
        }

        public Result AdicionarAlternativa(Alternativa alternativa)
        {
            List<string> erros = ValidarAlternativa(alternativa);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            return Result.Ok();
        }

        private List<string> ValidarAlternativa(Alternativa alternativa)
        {
            List<string> erros = validadorAlternativa.Validate(alternativa)
                .Errors.Select(e => e.ErrorMessage).ToList();

            return erros;
        }
    }
}
