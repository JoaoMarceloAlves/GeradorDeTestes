using GeradorDeTestes.Dominio.ModuloTeste;

namespace gerador.WinApp.ModuloTeste
{
    public partial class TabelaTesteControl : UserControl
    {
        public TabelaTesteControl()
        {
            InitializeComponent();

            ConfigurarColunas();

            gridTeste.ConfigurarGridSomenteLeitura();

            gridTeste.ConfigurarGridZebrado();
        }

        private void ConfigurarColunas()
        {
            DataGridViewColumn[] colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    Name = "id",
                    HeaderText = "Id"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "titulo",
                    HeaderText = "Título"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "recuperacao",
                    HeaderText = "Recuperação"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "disciplina",
                    HeaderText = "Disciplina"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "materia",
                    HeaderText = "Matéria"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "quantidade de questoes",
                    HeaderText = "Quantidade de Questões"
                }
            };

            gridTeste.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Teste> testes)
        {
            gridTeste.Rows.Clear();

            foreach (Teste teste in testes)
            {
                gridTeste.Rows.Add(
                    teste.id, 
                    teste.titulo, 
                    teste.ehRecuperacao ? "Sim" : "Não", 
                    teste.disciplina.nome, 
                    teste.materia.Nome,
                    teste.questoes.Count);
            }
        }

        public int ObterIdSelecionado()
        {
            if (gridTeste.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(gridTeste.SelectedRows[0].Cells["id"].Value);

            return id;
        }
    }
}
