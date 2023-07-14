using FluentResults;
using FluentValidation;
using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloCompartilhado;

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
            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorioBase.Inserir(registro);

            return Result.Ok();
        }

        public virtual Result Editar(T registro)
        {
            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorioBase.Editar(registro.id, registro);

            return Result.Ok();
        }

        public virtual Result Excluir(T registroSelecionado)
        {
            List<string> erros = new List<string>();

            try
            {
                repositorioBase.Excluir(registroSelecionado);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                    erros.Add("O registro não pode ser excluído");

                return Result.Fail(erros);
            }
        }

        protected virtual List<string> ValidarRegistro(T registro)
        {
            List<string> erros = this.validadorBase.Validate(registro)
                .Errors.Select(x => x.ErrorMessage).ToList(); ;

            return erros;
        }
    }
}
