using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.WinApp.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.WinApp.ModuloDisciplina
{
    internal class ControladorDisciplina : ControladorBase
    {
        private TabelaDisciplinaControl tabelaDisciplina;
        private readonly IRepositorioDisciplina repositorioDisciplina;

        public ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override string ToolTipInserir { get { return "Inserir nova Matéria"; } }

        public override string ToolTipEditar { get { return "Editar Matérias Existentes"; } }

        public override string ToolTipExcluir { get { return "Excluir Matérias Existentes"; } }

        public override void Inserir()
        {
            TelaDisciplinaForm telaDisciplina = new TelaDisciplinaForm(repositorioDisciplina.SelecionarTodos()) ;

            DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Disciplina Disciplina = telaDisciplina.ObterDisciplina();

                repositorioDisciplina.Inserir(Disciplina);
            }

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

            DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Disciplina DisciplinaAtualizada = telaDisciplina.ObterDisciplina();

                repositorioDisciplina.Editar(DisciplinaAtualizada.id, DisciplinaAtualizada);
            }

            CarregarDisciplinas();
        }

        private Disciplina ObterDisciplinaSelecionada()
        {
            int id = tabelaDisciplina.ObterIdSelecionado();

            return repositorioDisciplina.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            Disciplina Disciplina = ObterDisciplinaSelecionada();

            if (Disciplina == null)
            {
                MessageBox.Show($"Selecione uma Matéria primeiro!",
                    "Exclusão de Matérias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }
            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a Disciplina {Disciplina.nome}?", "Exclusão de Matérias",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioDisciplina.Excluir(Disciplina);
            }

            CarregarDisciplinas();
        }

        public override UserControl ObterListagem()
        {
            if (tabelaDisciplina == null)
                tabelaDisciplina = new TabelaDisciplinaControl();

            return tabelaDisciplina;

        }
        private void CarregarDisciplinas()
        {
            List<Disciplina> Disciplinas = repositorioDisciplina.SelecionarTodos();

            tabelaDisciplina.AtualizarRegistros(Disciplinas);
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Disciplinas";
        }
    }
}
