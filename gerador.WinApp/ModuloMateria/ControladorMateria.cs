using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloItem;
using GeradorDeTestes.Dominio.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        private TabelaMateriaControl tabelaMateria;
        private readonly IRepositorioMateria repositorioMateria;
        private readonly IRepositorioDisciplina repositorioDisciplina;

        public ControladorMateria(IRepositorioMateria repositorioMateria, IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override string ToolTipInserir { get { return "Inserir nova Matéria"; } }

        public override string ToolTipEditar { get { return "Editar Matérias Existentes"; } }

        public override string ToolTipExcluir { get { return "Excluir Matérias Existentes"; } }

        public override void Inserir()
        {
            TelaMateriaForm telaMateria = new TelaMateriaForm();
            telaMateria.CarregarDisciplinas(this.repositorioDisciplina.SelecionarTodos());
            DialogResult opcaoEscolhida = telaMateria.ShowDialog();
            
            if(opcaoEscolhida == DialogResult.OK)
            {
                Materia materia = telaMateria.ObterMateria();

                repositorioMateria.Inserir(materia);
            }

            CarregarMaterias();
        }
     
        public override void Editar()
        {
            Materia materia = ObterMateriaSelecionada();

            if(materia == null)
            {
                MessageBox.Show($"Selecione uma Matéria primeiro!",
                    "Edição de Matérias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }
            TelaMateriaForm telaMateria = new TelaMateriaForm();
            telaMateria.CarregarDisciplinas(this.repositorioDisciplina.SelecionarTodos());
            telaMateria.ConfigurarTela(materia);
            
            DialogResult opcaoEscolhida = telaMateria.ShowDialog();

            if(opcaoEscolhida == DialogResult.OK )
            {
                Materia materiaAtualizada = telaMateria.ObterMateria();

                repositorioMateria.Editar(materiaAtualizada.id, materiaAtualizada);
            }

            CarregarMaterias();
        }

        private Materia ObterMateriaSelecionada()
        {
            int id = tabelaMateria.ObterIdSelecionado();

            return repositorioMateria.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            Materia materia = ObterMateriaSelecionada();

            if (materia == null)
            {
                MessageBox.Show($"Selecione uma Matéria primeiro!",
                    "Exclusão de Matérias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }
            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a Matéria {materia.Nome}?", "Exclusão de Matérias",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(opcaoEscolhida == DialogResult.OK)
            {
                repositorioMateria.Excluir(materia);
            }

            CarregarMaterias();
        }       

        public override UserControl ObterListagem()
        {
           if(tabelaMateria == null)
                tabelaMateria = new TabelaMateriaControl();

           return tabelaMateria;
            
        }
        private void CarregarMaterias()
        {
            List<Materia> materias = repositorioMateria.SelecionarTodos();

            tabelaMateria.AtualizarRegistros(materias);
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Matérias";
        }
    }
}
