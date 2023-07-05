using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;
using GeradorDeTestes.Infra.Dados.Sql.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.Dados.Sql.ModuloDisciplina
{
    public class IRepositorioDisciplinaSql : RepositorioEmSqlBase<Disciplina, MapeadorDisciplina>, IRepositorioDisciplina
    {
        protected override string sqlInserir => @"INSERT INTO [TBDISCIPLINA]
                                                       (
                                                        [DISCIPLINA_ID]  
		                                                [NOME]
                                                       ,
                                                    
		                                               )
                                                 VALUES
                                                       (

                                                        @DISCIPLINA_ID
		                                                @NOME 
                                                       ,
                                                     
		                                               )

                                     SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE [TBDISCIPLINA]
                                                           SET 

                                                               [DISCIPLINA_ID] = @DISCIPLINA_ID
                                                               [NOME] = @NOME
                                                             
                                                            
                                                                 WHERE 
                                                                 [ID] = @ID";

        protected override string sqlExcluir => @"DELETE FROM 
                                                        [TBDISCIPLINA]
                                                    WHERE 
                                                         [ID] = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
                                                            
	                                                          ,D.[ID]                DISCIPLINA_ID
	                                                          ,D.[NOME]              DISCIPLINA_NOME	  

                                                                  FROM 

                                                                  [TBDISCIPLINA]";

        protected override string sqlSelecionarPorId => @"SELECT 
                                                                  
	                                                              ,D.[ID]                DISCIPLINA_ID
	                                                              ,D.[NOME]              DISCIPLINA_NOME
																											
                                                                  FROM 
                                                                  
                                                                  [TBDISCIPLINA]"";
                                                                 
                                                                    WHERE
                                                                     A.[ID] = @ID";
    }
}
