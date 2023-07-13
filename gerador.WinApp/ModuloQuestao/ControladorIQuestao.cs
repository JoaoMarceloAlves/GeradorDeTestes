using FluentResults;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GerardorDeTestes.Aplicacao.ModuloQuestao;

namespace GeradorDeTestes.WinApp.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        private TabelaQuestaoControl tabelaQuestao;
        private readonly IRepositorioQuestao repositorioQuestao;
        private readonly IRepositorioMateria repositorioMateria;
        private readonly ServicoQuestao servicoQuestao;

        public ControladorQuestao(IRepositorioQuestao repositorioQuestao, IRepositorioMateria repositorioMateria, ServicoQuestao servicoQuestao)
        {
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioMateria = repositorioMateria;
            this.servicoQuestao = servicoQuestao;
        }

        public override string ToolTipInserir { get { return "Inserir nova Questão"; } }

        public override string ToolTipEditar { get { return "Editar Questão existente"; } }

        public override string ToolTipExcluir { get { return "Excluir Questão existente"; } }

        public override void Inserir()
        {
            if (repositorioMateria.SelecionarTodos().Count == 0)
            {
                MessageBox.Show($"Não há matérias cadastradas!",
                   "Adição de Questões",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);

                return;
            }

            TelaQuestaoForm telaQuestao = new TelaQuestaoForm(repositorioMateria.SelecionarTodos());
            telaQuestao.onGravarRegistro += servicoQuestao.Inserir;
            telaQuestao.onAdicionarAlternativa += servicoQuestao.AdicionarAlternativa;

            telaQuestao.ShowDialog();

            CarregarQuestoes();
        }

        public override void Editar()
        {
            Questao questao = ObterQuestaoSelecionada();

            if (questao == null)
            {
                MessageBox.Show($"Selecione uma questão primeiro!",
                    "Edição de Questões",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaQuestaoForm telaQuestao = new TelaQuestaoForm(repositorioMateria.SelecionarTodos());
            telaQuestao.ConfigurarTela(questao);
            telaQuestao.onGravarRegistro += servicoQuestao.Editar;
            telaQuestao.onAdicionarAlternativa += servicoQuestao.AdicionarAlternativa;

            telaQuestao.ShowDialog();

            CarregarQuestoes();
        }

        private Questao ObterQuestaoSelecionada()
        {
            int id = tabelaQuestao.ObterIdSelecionado();

            if (id == -1)
                return null;

            return repositorioQuestao.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            Questao questao = ObterQuestaoSelecionada();

            if (questao == null)
            {
                MessageBox.Show($"Selecione uma questão primeiro!",
                    "Exclusão de Questões",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }


            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a Questão {questao.enunciado}?"
                , "Exclusão de Questões",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoQuestao.Excluir(questao);
                if(resultado.IsFailed)
                {
                    MessageBox.Show($"{resultado.Errors[0].Message}",
                   "Exclusão de Questões",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            CarregarQuestoes();
        }

        private void CarregarQuestoes()
        {
            List<Questao> questoes = repositorioQuestao.SelecionarTodos();

            tabelaQuestao.AtualizarRegistros(questoes);

            TelaPrincipalForm.Instancia.AtualizarRodape(
                $"Visualizando {questoes.Count} questões"
                );
        }

        public override UserControl ObterListagem()
        {
            if (tabelaQuestao == null)
                tabelaQuestao = new TabelaQuestaoControl();

            CarregarQuestoes();

            return tabelaQuestao;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Questões";
        }
    }
}
