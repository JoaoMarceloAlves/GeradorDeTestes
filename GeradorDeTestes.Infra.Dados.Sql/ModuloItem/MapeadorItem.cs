using GeradorDeTestes.Dominio.ModuloItem;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;
using Microsoft.Data.SqlClient;

namespace GeradorDeTestes.Infra.Dados.Sql.ModuloItem
{
    public class MapeadorItem : MapeadorBase<Item>
    {
        public override void ConfigurarParametros(SqlCommand comando, Item registro)
        {
            comando.Parameters.AddWithValue("ID", registro.id);

            comando.Parameters.AddWithValue("DESCRICAO", registro.descricao);

            comando.Parameters.AddWithValue("VALOR", registro.valor);
        }

        public override Item ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["ITEM_ID"]);

            string descricao = Convert.ToString(leitorRegistros["ITEM_DESCRICAO"]);

            decimal valor = Convert.ToDecimal(leitorRegistros["ITEM_VALOR"]);

            return new Item(id, descricao, valor);
        }
    }
}
