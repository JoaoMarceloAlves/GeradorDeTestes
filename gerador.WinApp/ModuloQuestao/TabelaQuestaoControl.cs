using GeradorDeTestes.Dominio.ModuloQuestao;

namespace GeradorDeTestes.WinApp.ModuloQuestao
{
    public partial class TabelaQuestaoControl : UserControl
    {
        public TabelaQuestaoControl()
        {
            InitializeComponent();
            ConfigurarColunas();

            gridQuestoes.ConfigurarGridZebrado();

            gridQuestoes.ConfigurarGridSomenteLeitura();
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
                    Name = "enunciado",
                    HeaderText = "Enunciado"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "resposta",
                    HeaderText = "Resposta"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "materia",
                    HeaderText = "Materia"
                }
            };

            gridQuestoes.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Questao> questoes)
        {
            gridQuestoes.Rows.Clear();

            foreach (Questao questao in questoes)
            {
                gridQuestoes.Rows.Add(
                    questao.id, questao.enunciado, questao.resposta.descricao, questao.materia.nome
                    );
            }
        }

        public int ObterIdSelecionado()
        {
            if (gridQuestoes.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(gridQuestoes.SelectedRows[0].Cells["id"].Value);

            return id;
        }
    }
}
