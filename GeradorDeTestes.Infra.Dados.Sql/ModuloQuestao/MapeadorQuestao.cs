using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;
using GeradorDeTestes.Infra.Dados.Sql.ModuloMateria;
using Microsoft.Data.SqlClient;

namespace GeradorDeTestes.Infra.Dados.Sql.ModuloQuestao
{
    public class MapeadorQuestao : MapeadorBase<Questao>
    {
        public override void ConfigurarParametros(SqlCommand comando, Questao registro)
        {
            comando.Parameters.AddWithValue("ID", registro.id);

            comando.Parameters.AddWithValue("ENUNCIADO", registro.enunciado);

            comando.Parameters.AddWithValue("RESPOSTA", registro.resposta.descricao);

            comando.Parameters.AddWithValue("ALTERNATIVA_A", registro.alternativas[0].descricao);

            comando.Parameters.AddWithValue("ALTERNATIVA_B", registro.alternativas[1].descricao);

            if (registro.alternativas.Count > 2)
                comando.Parameters.AddWithValue("ALTERNATIVA_C", registro.alternativas[2].descricao);

            else
                comando.Parameters.AddWithValue("ALTERNATIVA_C", DBNull.Value);

            if (registro.alternativas.Count > 3)
                comando.Parameters.AddWithValue("ALTERNATIVA_D", registro.alternativas[3].descricao);

            else
                comando.Parameters.AddWithValue("ALTERNATIVA_D", DBNull.Value);

            comando.Parameters.AddWithValue("MATERIA_ID", registro.materia.id);
        }

        public override Questao ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["QUESTAO_ID"]);

            string enunciado = Convert.ToString(leitorRegistros["QUESTAO_ENUNCIADO"]);

            Alternativa resposta = ConverterAlternativa(leitorRegistros);

            List<Alternativa> alternativas = CarregarAlternativas(leitorRegistros);

            Materia materia = new MapeadorMateria().ConverterRegistro(leitorRegistros);

            return new Questao(id, enunciado, resposta, alternativas, materia);
        }

        public Alternativa ConverterAlternativa(SqlDataReader leitorRegistros)
        {
            string descricao = Convert.ToString(leitorRegistros["QUESTAO_RESPOSTA"]);

            return new Alternativa(descricao);
        }

        public List<Alternativa> CarregarAlternativas(SqlDataReader leitorRegistros)
        {
            List<Alternativa> alternativas = new List<Alternativa>();

            alternativas.Add(
             new Alternativa(Convert.ToString(leitorRegistros["QUESTAO_ALTERNATIVA_A"])
             ));

            alternativas.Add(
             new Alternativa(Convert.ToString(leitorRegistros["QUESTAO_ALTERNATIVA_B"])
             ));

            if (leitorRegistros["QUESTAO_ALTERNATIVA_C"] != DBNull.Value)
                alternativas.Add(
                new Alternativa(Convert.ToString(leitorRegistros["QUESTAO_ALTERNATIVA_C"])
                ));

            if (leitorRegistros["QUESTAO_ALTERNATIVA_D"] != DBNull.Value)
                alternativas.Add(
                new Alternativa(Convert.ToString(leitorRegistros["QUESTAO_ALTERNATIVA_D"])
                ));

            return alternativas;
        }
    }
}
