using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;
using Microsoft.Data.SqlClient;

namespace GeradorDeTestes.Infra.Dados.Sql.ModuloQuestao
{
    public class RepositorioQuestaoEmSql : RepositorioEmSqlBase<Questao, MapeadorQuestao>, IRepositorioQuestao
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBQUESTAO]
                (
                    [ENUNCIADO]
                    ,[RESPOSTA]
                    ,[ALTERNATIVA_A]
                    ,[ALTERNATIVA_B]
                    ,[ALTERNATIVA_C]
                    ,[ALTERNATIVA_D]
                    ,[MATERIA_ID]
                )
                VALUES
                (
                    @ENUNCIADO
                    ,@RESPOSTA
                    ,@ALTERNATIVA_A
                    ,@ALTERNATIVA_B
                    ,@ALTERNATIVA_C
                    ,@ALTERNATIVA_D
                    ,@MATERIA_ID
                )

            SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
          @"UPDATE [TBQUESTAO]
                SET 
                [ENUNCIADO]     = @ENUNCIADO
               ,[RESPOSTA]      = @RESPOSTA
               ,[ALTERNATIVA_A] = @ALTERNATIVA_A
               ,[ALTERNATIVA_B] = @ALTERNATIVA_B
               ,[ALTERNATIVA_C] = @ALTERNATIVA_C
               ,[ALTERNATIVA_D] = @ALTERNATIVA_D
               ,[MATERIA_ID]    = @MATERIA_ID

	            WHERE 
		            [ID] = @ID";

        protected override string sqlExcluir =>
          @"DELETE FROM [TBQUESTAO]
	            WHERE 
		            [ID] = @ID";

        protected override string sqlSelecionarPorId =>
           @"SELECT 
                Q.[ID]            QUESTAO_ID
	           ,Q.[ENUNCIADO]     QUESTAO_ENUNCIADO
               ,Q.[RESPOSTA]      QUESTAO_RESPOSTA
               ,Q.[ALTERNATIVA_A] QUESTAO_ALTERNATIVA_A
               ,Q.[ALTERNATIVA_B] QUESTAO_ALTERNATIVA_B
               ,Q.[ALTERNATIVA_C] QUESTAO_ALTERNATIVA_C
               ,Q.[ALTERNATIVA_D] QUESTAO_ALTERNATIVA_D

               ,M.[ID]            MATERIA_ID
               ,M.[NOME]          MATERIA_NOME
               ,M.[SERIE]         MATERIA_SERIE

               ,D.[ID]            DISCIPLINA_ID
               ,D.[NOME]          DISCIPLINA_NOME
            FROM
                [TBQUESTAO] AS Q INNER JOIN [TBMATERIA] AS M
            ON
              Q.[MATERIA_ID] = M.[ID]
            INNER JOIN [TBDISCIPLINA] AS D
            ON
              M.[DISCIPLINA_ID] = D.[ID]
            WHERE 
                Q.[ID] = @ID";

        protected override string sqlSelecionarTodos =>
          @"SELECT 
                Q.[ID]            QUESTAO_ID
	           ,Q.[ENUNCIADO]     QUESTAO_ENUNCIADO
               ,Q.[RESPOSTA]      QUESTAO_RESPOSTA
               ,Q.[ALTERNATIVA_A] QUESTAO_ALTERNATIVA_A
               ,Q.[ALTERNATIVA_B] QUESTAO_ALTERNATIVA_B
               ,Q.[ALTERNATIVA_C] QUESTAO_ALTERNATIVA_C
               ,Q.[ALTERNATIVA_D] QUESTAO_ALTERNATIVA_D

          
               ,M.[ID]            MATERIA_ID
               ,M.[NOME]          MATERIA_NOME
               ,M.[SERIE]         MATERIA_SERIE

               ,D.[ID]            DISCIPLINA_ID
               ,D.[NOME]          DISCIPLINA_NOME
           FROM
                [TBQUESTAO] AS Q INNER JOIN [TBMATERIA] AS M
           ON
              Q.[MATERIA_ID] = M.[ID]
           INNER JOIN [TBDISCIPLINA] AS D
           ON
              M.[DISCIPLINA_ID] = D.[ID]";

        private const string sqlSelecionarQuestoes =
       @"SELECT 
               Q.[ID]            QUESTAO_ID
	           ,Q.[ENUNCIADO]     QUESTAO_ENUNCIADO
               ,Q.[RESPOSTA]      QUESTAO_RESPOSTA
               ,Q.[ALTERNATIVA_A] QUESTAO_ALTERNATIVA_A
               ,Q.[ALTERNATIVA_B] QUESTAO_ALTERNATIVA_B
               ,Q.[ALTERNATIVA_C] QUESTAO_ALTERNATIVA_C
               ,Q.[ALTERNATIVA_D] QUESTAO_ALTERNATIVA_D

               ,M.[ID]            MATERIA_ID
               ,M.[NOME]          MATERIA_NOME
               ,M.[SERIE]         MATERIA_SERIE

               ,D.[ID]            DISCIPLINA_ID
               ,D.[NOME]          DISCIPLINA_NOME

               ,T.[ID]            TESTE_ID
            FROM
                [TBQUESTAO] AS Q INNER JOIN [TBMATERIA] AS M
            ON
              Q.[MATERIA_ID] = M.[ID]
            INNER JOIN [TBDISCIPLINA] AS D
            ON
              M.[DISCIPLINA_ID] = D.[ID]
            INNER JOIN [TBTESTE] AS T
            ON
                T.[DISCIPLINA_ID] = D.[ID]
            INNER JOIN [TBTESTE_TBQUESTAO] AS TQ 
            ON 
              TQ.[QUESTAO_ID] = @ID AND 
              TQ.[TESTE_ID] = T.[ID]";

        public List<Questao> SelecionarQuestoes(int id)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarQuestoes;
            comandoSelecionarTodos.Parameters.AddWithValue("ID", id);


            //executa o comando
            SqlDataReader leitorItens = comandoSelecionarTodos.ExecuteReader();

            List<Questao> registros = new List<Questao>();

            MapeadorQuestao mapeador = new MapeadorQuestao();

            while (leitorItens.Read())
            {
                Questao registro = mapeador.ConverterRegistro(leitorItens);

                registros.Add(registro);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return registros;
        }
    }
}
