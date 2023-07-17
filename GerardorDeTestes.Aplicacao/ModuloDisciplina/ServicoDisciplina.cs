using FluentResults;
using GeradorDeTestes.Dominio.ModuloDisciplina;
using GerardorDeTestes.Aplicacao.ModuloCompartilhado;
using Microsoft.Data.SqlClient;
using Serilog;

namespace GerardorDeDisciplinas.Aplicacao.ModuloDisciplina
{
    public class ServicoDisciplina : ServicoBase<Disciplina, IRepositorioDisciplina, ValidadorDisciplina> 
    {
        public ServicoDisciplina(IRepositorioDisciplina repositorioDisciplina): 
            base(repositorioDisciplina, new ValidadorDisciplina())
        {
        }

        public override Result Excluir(Disciplina disciplina)
        {

            Log.Debug("Tentando excluir Disciplina...{@d}", disciplina);

            try
            {
                repositorioBase.Excluir(disciplina);

                Log.Debug("Disciplina {disciplinaId} excluída com sucesso", disciplina.id);
            }
            catch (SqlException ex)
            {
                string mensagemErro = "Falha ao tentar excluir matéria";

                if (ex.Message.Contains("TbMateria"))
                    mensagemErro = "Esta disciplina está relacionada com uma questão e não pode ser excluída";

                Log.Error(ex, mensagemErro + "{m}", disciplina);

                return Result.Fail(mensagemErro);
            }

            return Result.Ok();
        }

        protected override List<string> ValidarRegistro(Disciplina disciplina)
        {
            List<string> erros = base.ValidarRegistro(disciplina);

            if (NomeDuplicado(disciplina))
                erros.Add("Não pode inserir disciplina com mesmo nome");

            return erros;
        }

        private bool NomeDuplicado(Disciplina disciplina)
        {
            return repositorioBase.SelecionarTodos().
                FindAll(d => d.id != disciplina.id && d.nome == disciplina.nome).Count > 0;
        }
    }
}
