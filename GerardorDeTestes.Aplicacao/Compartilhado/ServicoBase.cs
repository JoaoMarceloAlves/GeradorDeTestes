using FluentResults;
using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloCompartilhado;

namespace GerardorDeTestes.Aplicacao.ModuloCompartilhado
{
    public abstract class ServicoBase<T, TRepositorio>
        where T : EntidadeBase<T>
        where TRepositorio : IRepositorioBase<T>
    {
        private TRepositorio repositorioBase;

        public ServicoBase(TRepositorio repositorioBase)
        {
            this.repositorioBase = repositorioBase;
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
            List<string> erros = new List<string>(registro.Validar());

            return erros;
        }
    }
}
