using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Dominio.ModuloTeste;
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
        private readonly IRepositorioMateria repositorioMateria;
        private readonly IRepositorioTeste repositorioTeste;
        public ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina, IRepositorioMateria repositorioMateria, IRepositorioTeste repositorioTeste)
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            this.repositorioTeste = repositorioTeste;
        }

        public override string ToolTipInserir { get { return "Inserir nova Disciplina"; } }

        public override string ToolTipEditar { get { return "Editar Disciplina Existentes"; } }

        public override string ToolTipExcluir { get { return "Excluir Disciplina Existentes"; } }

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

            if (repositorioMateria.SelecionarTodos().Find(a=> a.Disciplina.id == Disciplina.id)!= null)
            {
                MessageBox.Show($"Não foi possivel excluir a disciplina a uma matéria vinculada",
                    "Exclusão de Disciplinas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }


          if (repositorioTeste.SelecionarTodos().Find(a => a.disciplina.id == Disciplina.id) != null)
            {
              MessageBox.Show($"Não foi possivel excluir a disciplina a uma questão vinculada",
                "Exclusão de Disciplinas",
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
