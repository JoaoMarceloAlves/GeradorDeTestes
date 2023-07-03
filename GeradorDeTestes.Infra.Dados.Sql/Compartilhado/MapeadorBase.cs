using Microsoft.Data.SqlClient;

namespace GeradorDeTestes.Infra.Dados.Sql.Compartilhado
{
    public abstract class MapeadorBase<TEntidade>
    {
        public abstract void ConfigurarParametros(SqlCommand comando, TEntidade registro);

        public abstract TEntidade ConverterRegistro(SqlDataReader leitorRegistros);
    }
}
