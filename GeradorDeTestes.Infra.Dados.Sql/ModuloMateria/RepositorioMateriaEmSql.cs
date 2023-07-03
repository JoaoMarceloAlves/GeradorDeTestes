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

        protected override string sqlSelecionarTodos => @"SELECT M.[ID]
                                                                  ,M.[NOME]
                                                                  ,M.[DISCIPLINA_ID]
                                                                  ,M.[SERIE]
                                                         FROM
                                                          [TBMATERIA] AS M
                                                          INNER JOIN
                                                          [TBDISCIPLINA] AS D 
                                                          ON M.DISCIPLINA_ID = D.ID";

        protected override string sqlSelecionarPorId => @"SELECT M.[ID]
                                                          ,M.[NOME]
                                                          ,M.[DISCIPLINA_ID]
                                                          ,M.[SERIE]
                                                     FROM
                                                      [TBMATERIA] AS M
                                                   INNER JOIN
                                                      [TBDISCIPLINA] AS D 
                                                      ON 
                                                      M.DISCIPLINA_ID = D.ID

                                                      WHERE M.[ID] = @ID";
    }
}
