using FluentResults;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GerardorDeTestes.Aplicacao.ModuloCompartilhado;
using Microsoft.Data.SqlClient;

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

        public override Result Excluir(Questao questaoSelecionada)
        {
            List<string> erros = new List<string>();

            try
            {
                repositorioBase.Excluir(questaoSelecionada);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                if(ex.Message.Contains("TbTeste"))
                    erros.Add("Esta questao está relacionada com um teste e não pode ser excluída");

                return Result.Fail(erros);
            }
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
