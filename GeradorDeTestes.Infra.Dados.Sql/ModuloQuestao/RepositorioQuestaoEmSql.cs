using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;

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
                )
                VALUES
                (
                    @ENUNCIADO
                    ,@RESPOSTA
                    ,@ALTERNATIVA_A
                    ,@ALTERNATIVA_B
                    ,@ALTERNATIVA_C
                    ,@ALTERNATIVA_D
                )

            SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
          @"UPDATE [TBQUESTAO]
                SET 
                [ENUNCIADO]     = @QUESTAO_ENUNCIADO
               ,[RESPOSTA]      = @RESPOSTA
               ,[ALTERNATIVA_A] = @ALTERNATIVA_A
               ,[ALTERNATIVA_B] = @ALTERNATIVA_B
               ,[ALTERNATIVA_C] = @ALTERNATIVA_C
               ,[ALTERNATIVA_D] = @ALTERNATIVA_D

	            WHERE 
		            [ID] = @ID";

        protected override string sqlExcluir =>
          @"DELETE FROM [TBQUESTAO]
	            WHERE 
		            [ID] = @ID";

        protected override string sqlSelecionarPorId =>
           @"SELECT 
                [ID]            QUESTAO_ID
	           ,[ENUNCIADO]     QUESTAO_ENUNCIADO
               ,[RESPOSTA]      QUESTA0_RESPOSTA
               ,[ALTERNATIVA_A] QUESTAO_ALTERNATIVA_A
               ,[ALTERNATIVA_B] QUESTAO_ALTERNATIVA_B
               ,[ALTERNATIVA_C] QUESTAO_ALTERNATIVA_C
               ,[ALTERNATIVA_D] QUESTAO_ALTERNATIVA_D
	  
            WHERE 
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
          @"SELECT 
                [ID]            QUESTAO_ID
	           ,[ENUNCIADO]     QUESTAO_ENUNCIADO
               ,[RESPOSTA]      QUESTA0_RESPOSTA
               ,[ALTERNATIVA_A] QUESTAO_ALTERNATIVA_A
               ,[ALTERNATIVA_B] QUESTAO_ALTERNATIVA_B
               ,[ALTERNATIVA_C] QUESTAO_ALTERNATIVA_C
               ,[ALTERNATIVA_D] QUESTAO_ALTERNATIVA_D";
    }
}
