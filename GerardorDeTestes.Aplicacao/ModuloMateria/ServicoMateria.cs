using FluentResults;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GerardorDeTestes.Aplicacao.ModuloCompartilhado;
using Microsoft.Data.SqlClient;
using Serilog;

namespace GerardorDeMaterias.Aplicacao.ModuloMateria
{
    public class ServicoMateria : ServicoBase<Materia, IRepositorioMateria, ValidadorMateria> 
    {


        public ServicoMateria(IRepositorioMateria repositorioMateria): 
            base(repositorioMateria, new ValidadorMateria())
        {
        }

        public override Result Excluir(Materia materia)
        {

            Log.Debug("Tentando excluir Materia...{@m}", materia);

            try
            {
                repositorioBase.Excluir(materia);

                Log.Debug("Questão {materiaId} excluída com sucesso", materia.id);
            }
            catch (SqlException ex)
            {
                string mensagemErro = "Falha ao tentar excluir matéria";

                if (ex.Message.Contains("TbQuestao"))
                    mensagemErro = "Esta matéria está relacionada com uma questão e não pode ser excluída";

                Log.Error(ex, mensagemErro + "{m}", materia);

                return Result.Fail(mensagemErro);
            }

            return Result.Ok();
        }

        protected override List<string> ValidarRegistro(Materia materia)
        {
            List<string> erros = base.ValidarRegistro(materia);

            if (NomeDuplicado(materia))
                erros.Add("Não pode inserir matéria com mesmo nome");

            return erros;
        }

        private bool NomeDuplicado(Materia materia)
        {
            return repositorioBase.SelecionarTodos().
                FindAll(m => m.id != materia.id && m.Nome == materia.Nome).Count > 0;
        }
    }
}
