using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.Dados.Sql.ModuloMateria
{
    public class RepositorioMateriaEmSql : RepositorioEmSqlBase<Materia, MapeadorMateria>, IRepositorioMateria
    {
        protected override string sqlInserir => @"INSERT INTO [TBMATERIA]
                                                       (
		                                                [NOME]
                                                       ,[DISCIPLINA_ID]
                                                       ,[SERIE]
		                                               )
                                                 VALUES
                                                       (
		                                                @NOME 
                                                       ,@DISCIPLINA_ID
                                                       ,@SERIE
		                                               )

                                     SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE [TBMATERIA]
                                                           SET 
                                                               [NOME] = @NOME
                                                              ,[DISCIPLINA_ID] = @DISCIPLINA_ID
                                                              ,[SERIE] = @SERIE
                                                                 WHERE 
                                                                 [ID] = @ID";

        protected override string sqlExcluir => @"DELETE FROM 
                                                        [TBMATERIA]
                                                    WHERE 
                                                         [ID] = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
                                                               A.[ID]                MATERIA_ID
                                                              ,A.[NOME]              MATERIA_NOME
                                                              ,A.[DISCIPLINA_ID]     MATERIA_DISCIPLINA_ID
                                                              ,A.[SERIE]             MATERIA_SERIE

	                                                          ,D.[ID]                DISCIPLINA_ID
	                                                          ,D.[NOME]              DISCIPLINA_NOME	  

                                                                  FROM 

                                                                  [TBMATERIA] AS A INNER JOIN [TBDISCIPLINA] AS D
                                                                  ON
                                                                  A.[DISCIPLINA_ID] = D.[ID]";

        protected override string sqlSelecionarPorId => @"SELECT 
                                                                   A.[ID]                MATERIA_ID
                                                                  ,A.[NOME]              MATERIA_NOME
                                                                  ,A.[DISCIPLINA_ID]     MATERIA_DISCIPLINA_ID
                                                                  ,A.[SERIE]             MATERIA_SERIE

	                                                              ,D.[ID]                DISCIPLINA_ID
	                                                              ,D.[NOME]              DISCIPLINA_NOME
																											
                                                                  FROM 
                                                                  [TBMATERIA] AS A INNER JOIN [TBDISCIPLINA] AS D
                                                                  ON
                                                                  A.[DISCIPLINA_ID] = D.[ID]
                                                                 
                                                                    WHERE
                                                                     A.[ID] = @ID";
    }
}
