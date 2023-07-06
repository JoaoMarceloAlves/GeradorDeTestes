using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;
using GeradorDeTestes.Infra.Dados.Sql.ModuloMateria;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.Dados.Sql.ModuloDisciplina
{
    public class RepositorioDisciplinaSql : RepositorioEmSqlBase<Disciplina, MapeadorDisciplina>, IRepositorioDisciplina
    {
        protected override string sqlInserir => @"INSERT INTO [TBDISCIPLINA]
                                                       (
                                                        
		                                                [NOME]
                                                       
                                                    
		                                               )
                                                 VALUES
                                                       (

                                                       
		                                                @NOME 
                                                       
                                                     
		                                               )

                                     SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE [TBDISCIPLINA]
                                                           SET 

                                                              
                                                               [NOME] = @NOME
                                                             
                                                            
                                                                 WHERE 
                                                                 [ID] = @ID";

        protected override string sqlExcluir => @"DELETE FROM 
                                                        [TBDISCIPLINA]
                                                    WHERE 
                                                         [ID] = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
                                                            
	                                                           D.[ID]                DISCIPLINA_ID
	                                                          ,D.[NOME]              DISCIPLINA_NOME	  

                                                                  FROM 

                                                                  [TBDISCIPLINA] AS D";

        protected override string sqlSelecionarPorId => @"SELECT 
                                                                  
	                                                              D.[ID]                DISCIPLINA_ID
	                                                              ,D.[NOME]              DISCIPLINA_NOME
																											
                                                                  FROM 
                                                                  
                                                                  [TBDISCIPLINA] AS D
                                                                 
                                                                    WHERE
                                                                     D.[ID] = @ID";
        protected  string sqlSelecionarMaterias => @"SELECT 
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
                                                                     D.[ID] = A.[DISCIPLINA_ID] AND D.[ID] = @ID ";

        public  List<Materia> SelecionarMaterias(int Id)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarMaterias;
            comandoSelecionarTodos.Parameters.AddWithValue("ID", Id);
            //executa o comando
            SqlDataReader leitorItens = comandoSelecionarTodos.ExecuteReader();

            List<Materia> registros = new List<Materia>();

           MapeadorMateria mapeador = new MapeadorMateria();

            while (leitorItens.Read())
            {
                Materia registro = mapeador.ConverterRegistro(leitorItens);

                registros.Add(registro);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return registros;
        }

        public override Disciplina SelecionarPorId(int id)
        {

            Disciplina disciplina = base.SelecionarPorId (id);

            disciplina.materias = SelecionarMaterias(id);

            return disciplina;

        }
    }
}
