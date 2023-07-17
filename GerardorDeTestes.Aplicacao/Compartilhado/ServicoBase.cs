using FluentResults;
using FluentValidation;
using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloCompartilhado;
using GeradorDeTestes.Dominio.ModuloDisciplina;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using Serilog;

namespace GerardorDeTestes.Aplicacao.ModuloCompartilhado
{
    public abstract class ServicoBase<T, TRepositorio, TValidador>
        where T : EntidadeBase<T>
        where TRepositorio : IRepositorioBase<T>
        where TValidador : AbstractValidator<T>
    {
        protected TRepositorio repositorioBase;
        protected TValidador validadorBase;

        public ServicoBase(TRepositorio repositorioBase, TValidador validadorBase)
        {
            this.repositorioBase = repositorioBase;
            this.validadorBase = validadorBase;
        }

        public virtual Result Inserir(T registro)
        {
            Log.Debug("Tentando inserir registro...{@r}", registro);

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);
            try
            {
                repositorioBase.Inserir(registro);

                Log.Debug("Registro {registroId} inserido com sucesso", registro.id);
            }
            catch(SqlException ex) {
                string mensagemErro = "Falha ao tentar inserir registro";

                Log.Error(ex, mensagemErro + "{r}", registro);

                return Result.Fail(mensagemErro);
            }

            return Result.Ok();
        }

        public virtual Result Editar(T registro)
        {
            Log.Debug("Tentando editar registro...{@r}", registro);

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioBase.Editar(registro.id, registro);

                Log.Debug("Registro {registroId} editado com sucesso", registro.id);
            }
            catch (SqlException ex)
            {
                string mensagemErro = "Falha ao tentar editar registro";

                Log.Error(ex, mensagemErro + "{r}", registro);

                return Result.Fail(mensagemErro);
            }

            return Result.Ok();
        }

        public virtual Result Excluir(T registro)
        {
            Log.Debug("Tentando excluir registro...{@r}", registro);

            try
            {
                repositorioBase.Excluir(registro);

                Log.Debug("Registro {registroId} excluído com sucesso", registro.id);
            }
            catch (SqlException ex)
            {
                string mensagemErro = "Falha ao tentar excluir registro";

                Log.Error(ex, mensagemErro + "{r}", registro);

                return Result.Fail(mensagemErro);
            }

            return Result.Ok();
        }

        protected virtual List<string> ValidarRegistro(T registro)
        {
            List<string> erros = this.validadorBase.Validate(registro)
                .Errors.Select(x => x.ErrorMessage).ToList(); ;

            return erros;
        }
    }
}
