using GeradorDeTestes.Dominio.ModuloTeste;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;
using GeradorDeTestes.Infra.Dados.Sql.ModuloMateria;
using Microsoft.Data.SqlClient;
using GeradorDeTestes.Infra.Dados.Sql.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloDisciplina;

namespace GeradorDeTestes.Infra.Dados.Sql.ModuloTeste
{
    public class MapeadorTeste : MapeadorBase<Teste>
    {
        public override void ConfigurarParametros(SqlCommand comando, Teste registro)
        {
            comando.Parameters.AddWithValue("ID", registro.id);

            comando.Parameters.AddWithValue("TITULO", registro.titulo);

            comando.Parameters.AddWithValue("RECUPERACAO", registro.ehRecuperacao);

            comando.Parameters.AddWithValue("QUANTIDADE_QUESTOES", registro.quantidadeQuestoes);

            comando.Parameters.AddWithValue("DISCIPLINA_ID", registro.disciplina);

            comando.Parameters.AddWithValue("MATERIA_ID", registro.materia.id);
        }

        public override Teste ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["TESTE_ID"]);

            string titulo = Convert.ToString(leitorRegistros["TESTE_TITULO"]);

            bool ehRecuperacao = Convert.ToBoolean(leitorRegistros["TESTE_RECUPERACAO"]);

            int quantidadeQuestoes = Convert.ToInt32(leitorRegistros["TESTE_QUANTIDADE_QUESTOES"]);

            List<Questao> questoes = new List<Questao>();

            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitorRegistros);

            Materia materia = new MapeadorMateria().ConverterRegistro(leitorRegistros);
    
            return new Teste(id, titulo, ehRecuperacao, quantidadeQuestoes, disciplina, materia, questoes);
        }
    }
}
