using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Dominio.ModuloTeste;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;
using GeradorDeTestes.Infra.Dados.Sql.ModuloMateria;
using GeradorDeTestes.Infra.Dados.Sql.ModuloQuestao;
using Microsoft.Data.SqlClient;

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
                    ,[MATERIA_ID]
                    ,[DISCIPLINA_ID]
                   
                )
                VALUES
                (
                    @TITULO
                    ,@RECUPERACAO
                    ,@QUANTIDADE_QUESTOES
                    ,@MATERIA_ID
                    ,@DISCIPLINA_ID
                )

            SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
          @"UPDATE [TBTESTE]
                SET 
                     [TITULO]              = @TITULO
                    ,[RECUPERACAO]         = @RECUPERACAO
                    ,[QUANTIDADE_QUESTOES] = @QUANTIDADE_QUESTOES
                    ,[MATERIA_ID]          = @MATERIA_ID
                    ,[DISCIPLINA_ID]       = @DISCIPLINA_ID

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
                ,T.[DISCIPLINA_ID]       TESTE_DISCIPLINA_ID

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
            FROM
                [TBQUESTAO] AS Q INNER JOIN [TBMATERIA] AS M
            ON
              Q.[MATERIA_ID] = M.[ID]
            INNER JOIN [TBDISCIPLINA] AS D
            ON
              M.[DISCIPLINA_ID] = D.[ID]
            INNER JOIN [TBTESTE_TBQUESTAO] AS TQ 
            ON 
              Q.[ID] = TQ.[QUESTAO_ID] AND 
              TQ.[TESTE_ID] = @ID";

        private const string sqlAdicionarQuestao =
          @"INSERT INTO [TBTeste_TBQuestao]
                (
                    [Teste_Id]
                   ,[Questao_Id])
            VALUES
                (
                    @Teste_Id
                   ,@Questao_Id
                )";

        private const string sqlRemoverQuestao =
           @"DELETE FROM TBTESTE_TBQUESTAO 
                WHERE TESTE_ID = @Teste_Id AND Questao_Id = @Questao_Id";

        public override void Inserir(Teste teste)
        {
            base.Inserir(teste);
            foreach(Questao questao in teste.questoes)
            {
                InserirQuestao(teste.id, questao.id);
            }
        }

        public override void Excluir(Teste teste)
        {
            foreach (Questao questao in teste.questoes)
            {
                ExcluirQuestao(teste.id,questao.id);
            }
            base.Excluir(teste);
        }

        public override List<Teste> SelecionarTodos()
        {
            List<Teste> testes = base.SelecionarTodos();
            foreach(Teste teste in testes)
            {
                teste.questoes = SelecionarQuestoes(teste.id);
            }
            return testes;
        }

        public override Teste SelecionarPorId(int id)
        {
            Teste teste = base.SelecionarPorId(id);

            teste.questoes = SelecionarQuestoes(id);

            return teste;
        }

        public void InserirQuestao(int testeId, int questaoId)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlAdicionarQuestao;

            //adiciona os parâmetros no comando
            comandoInserir.Parameters.AddWithValue("Teste_ID", testeId);
            comandoInserir.Parameters.AddWithValue("Questao_ID", questaoId);

            //executa o comando
            comandoInserir.ExecuteNonQuery();

            //encerra a conexão
            conexaoComBanco.Close();
        }

        public void ExcluirQuestao(int testeId, int questaoId)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoExcluir = conexaoComBanco.CreateCommand();
            comandoExcluir.CommandText = sqlRemoverQuestao;

            //adiciona os parâmetros no comando
            comandoExcluir.Parameters.AddWithValue("Teste_ID", testeId);
            comandoExcluir.Parameters.AddWithValue("Questao_ID", questaoId);

            //executa o comando
            comandoExcluir.ExecuteNonQuery();

            //encerra a conexão
            conexaoComBanco.Close();
        }

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

        public List<Teste> SelecionarPorTitulo(Teste teste)
        {
            return SelecionarTodos().FindAll(
                t => t.id != teste.id && t.titulo == teste.titulo);
        }
    }
}
