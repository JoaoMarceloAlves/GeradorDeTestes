using FluentResults;
using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Dominio.ModuloTeste;
using GerardorDeDisciplinas.Aplicacao.ModuloDisciplina;
using GerardorDeTestes.Aplicacao.ModuloQuestao;

namespace GeradorDeTestes.WinApp.ModuloDisciplina
{
    internal class ControladorDisciplina : ControladorBase
    {
        private TabelaDisciplinaControl tabelaDisciplina;
        private readonly IRepositorioDisciplina repositorioDisciplina;
        private readonly IRepositorioMateria repositorioMateria;
        private readonly IRepositorioTeste repositorioTeste;

        private readonly ServicoDisciplina servicoDisciplina;
        public ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina, 
            IRepositorioMateria repositorioMateria, 
            IRepositorioTeste repositorioTeste,
            ServicoDisciplina servicoDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            this.repositorioTeste = repositorioTeste;
            this.servicoDisciplina = servicoDisciplina;
        }

        public override string ToolTipInserir { get { return "Inserir nova Disciplina"; } }

        public override string ToolTipEditar { get { return "Editar Disciplina Existentes"; } }

        public override string ToolTipExcluir { get { return "Excluir Disciplina Existentes"; } }

        public override void Inserir()
        {
            TelaDisciplinaForm telaDisciplina = new TelaDisciplinaForm(repositorioDisciplina.SelecionarTodos()) ;

            telaDisciplina.onGravarDisciplina = servicoDisciplina.Inserir;

            telaDisciplina.ShowDialog();

            CarregarDisciplinas();
        }

        public override void Editar()
        {
            Disciplina Disciplina = ObterDisciplinaSelecionada();

            if (Disciplina == null)
            {
                MessageBox.Show($"Selecione uma Disciplina primeiro!",
                    "Edição de Matérias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }


            TelaDisciplinaForm telaDisciplina = new TelaDisciplinaForm(repositorioDisciplina.SelecionarTodos());
            telaDisciplina.ConfigurarTela(Disciplina);

            telaDisciplina.onGravardisciplina = servicoDisciplina.Editar;

            DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

            CarregarDisciplinas();
        }

        private Disciplina ObterDisciplinaSelecionada()
        {
            int id = tabelaDisciplina.ObterIdSelecionado();

            if (id == -1)
                return null;

            return repositorioDisciplina.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            Disciplina Disciplina = ObterDisciplinaSelecionada();

            if (Disciplina == null)
            {
                MessageBox.Show($"Selecione uma Disciplina primeiro!",
                    "Exclusão de Disciplinas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a Disciplina {Disciplina.nome}?", "Exclusão de Matérias",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoDisciplina.Excluir(Disciplina);
                if (resultado.IsFailed)
                {
                    MessageBox.Show($"{resultado.Errors[0].Message}",
                   "Exclusão de Disciplinas",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }

            CarregarDisciplinas();
        }


        public override UserControl ObterListagem()
        {
            if (tabelaDisciplina == null)
                tabelaDisciplina = new TabelaDisciplinaControl();

            CarregarDisciplinas();


            return tabelaDisciplina;

        }
        private void CarregarDisciplinas()
        {
            List<Disciplina> Disciplinas = repositorioDisciplina.SelecionarTodos();

            tabelaDisciplina.AtualizarRegistros(Disciplinas);
           
            TelaPrincipalForm.Instancia.AtualizarRodape("Visualizando" + " "+  Disciplinas.Count + " " + "Disciplinas");
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Disciplinas";
        }
    }
}
