using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.WinApp.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract string ToolTipInserir { get; }

        public abstract string ToolTipEditar { get; }

        public abstract string ToolTipExcluir { get; }
        
        public virtual string ToolTipDuplicar { get; }

        public virtual string ToolTipGerarPdf { get; }

        public virtual string? ToolTipVisualizarTestes { get; }

        public virtual bool InserirHabilitado { get { return true; } }
        public virtual bool EditarHabilitado { get { return true; } }
        public virtual bool ExcluirHabilitado { get { return true; } }
        public virtual bool DuplicarHabilitado { get { return false; } }
        public virtual bool GerarPdfHabilitado { get { return false; } }
        public virtual bool VisualizarTestesHabilitado { get { return false; } }

        public abstract void Inserir();

        public abstract void Editar();

        public abstract void Excluir();

        public virtual void Duplicar()
        {
        }
        public virtual void GerarPdf()
        {
        }

        public virtual void VisualizarDetalhesTeste()
        {

        }

        public abstract UserControl ObterListagem();

        public abstract string ObterTipoCadastro();
    }
}
