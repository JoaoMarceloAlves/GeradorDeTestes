using GeradorDeTestes.Dominio.ModuloTeste;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;

namespace GeradorDeTestes.Infra.Dados.Sql.ModuloTeste
{
    public class RepositorioTesteEmSql : RepositorioEmSqlBase<Teste, MapeadorTeste>, IRepositorioTeste
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBTESTE]
                (
                    [TITULO]
                    ,[RECUPERACAO]
                    ,[QUANTIDADE_QUESTOES]
                    ,[DISCIPLINA_ID]
                    ,[MATERIA_ID]
                )
                VALUES
                (
                    @TITULO
                    ,@RECUPERACAO
                    ,@QUANTIDADE_QUESTOES
                    ,@DISPCIPLINA_ID
                    ,@MATERIA_ID
                )

            SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
          @"UPDATE [TBTESTE]
                SET 
                     [TITULO]              = @TITULO
                    ,[RECUPERACAO]         = @RECUPERACAO
                    ,[QUANTIDADE_QUESTOES] = @QUANTIDADE_QUESTOES
                    ,[DISCIPLINA_ID]       = @DISCIPLINA_ID
                    ,[MATERIA_ID]          = @MATERIA_ID

	            WHERE 
		            [ID] = @ID";

        protected override string sqlExcluir =>
          @"DELETE FROM [TBTESTE]
	            WHERE 
		            [ID] = @ID";

        protected override string sqlSelecionarPorId =>
           @"SELECT 
                T.[ID]                   TESTE_ID
                ,T.[TITULO]              TESTE_TITULO
                ,T.[RECUPERACAO]         TESTE_RECUPERACAO
                ,T.[QUANTIDADE_QUESTOES] TESTE_QUANTIDADE_QUESTOES

               ,M.[ID]                   MATERIA_ID
               ,M.[NOME]                 MATERIA_NOME
               ,M.[SERIE]                MATERIA_SERIE

               ,D.[ID]                   DISCIPLINA_ID
               ,D.[NOME]                 DISCIPLINA_NOME
            FROM
                [TBTESTE] AS T INNER JOIN [TBMATERIA] AS M
            ON
              T.[MATERIA_ID] = M.[ID]
            INNER JOIN [TBDISCIPLINA] AS D
            ON
              M.[DISCIPLINA_ID] = D.[ID]
            WHERE 
                T.[ID] = @ID";

        protected override string sqlSelecionarTodos =>
          @"SELECT 
                T.[ID]                   TESTE_ID
                ,T.[TITULO]              TESTE_TITULO
                ,T.[RECUPERACAO]         TESTE_RECUPERACAO
                ,T.[QUANTIDADE_QUESTOES] TESTE_QUANTIDADE_QUESTOES

               ,M.[ID]                   MATERIA_ID
               ,M.[NOME]                 MATERIA_NOME
               ,M.[SERIE]                MATERIA_SERIE

               ,D.[ID]                   DISCIPLINA_ID
               ,D.[NOME]                 DISCIPLINA_NOME
            FROM
                [TBTESTE] AS T INNER JOIN [TBMATERIA] AS M
            ON
              T.[MATERIA_ID] = M.[ID]
            INNER JOIN [TBDISCIPLINA] AS D
            ON
              M.[DISCIPLINA_ID] = D.[ID]";

    }
}
