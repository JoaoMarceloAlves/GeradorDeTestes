using GeradorDeTestes.Dominio.ModuloCompartilhado;

namespace GeradorDeTestes.Dominio.ModuloDisciplina
{
    public interface IRepositorioDisciplina : IRepositorioBase<Disciplina>
    {
        List<Disciplina> SelecionarTodosCarregados();
    }
}
