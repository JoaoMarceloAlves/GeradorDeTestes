using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;
using Microsoft.Data.SqlClient;
using static GeradorDeTestes.Dominio.ModuloMateria.Materia;

namespace GeradorDeTestes.Infra.Dados.Sql.ModuloMateria
{
    public class MapeadorMateria : MapeadorBase<Materia>
    {
        public override void ConfigurarParametros(SqlCommand comando, Materia registro)
        {
            comando.Parameters.AddWithValue("ID", registro.id);

            comando.Parameters.AddWithValue("NOME", registro.nome);

            comando.Parameters.AddWithValue("DISCIPLINA_ID", registro.disciplina);

            comando.Parameters.AddWithValue("SERIE", registro.serie);
        }

        public override Materia ConverterRegistro(SqlDataReader leitorRegistros)
        {
            //Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitorRegistros);

            //int idDisciplina = Convert.ToInt32(leitorRegistros["DISCIPLINA_ID"]);

            //string nome = Convert.ToString(leitorRegistros["NOME"]);

            //string serie = Convert.ToString(leitorRegistros["SERIE"]);

            //Materia materia = new Materia(nome, disciplina, serie);

            //return materia;

            return null;
        }
    }
}
