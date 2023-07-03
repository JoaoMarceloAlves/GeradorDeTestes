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

        public ControladorMateria(IRepositorioMateria repositorioMateria)
        {
            this.repositorioMateria = repositorioMateria;
        }

        public override string ToolTipInserir { get { return "Inserir nova Matéria"; } }

        public override string ToolTipEditar { get { return "Editar Matéria Existente"; } }

        public override string ToolTipExcluir { get { return "Excluir Matéria Existente"; } }

        public override void Inserir()
        {
            throw new NotImplementedException();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }       

        public override UserControl ObterListagem()
        {
           if(tabelaMateria == null)
                tabelaMateria = new TabelaMateriaControl();

           return tabelaMateria;
            
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Matérias";
        }
    }
}
