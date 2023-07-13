using GeradorDeTestes.Dominio.ModuloCompartilhado;

namespace GeradorDeTestes.Dominio.ModuloQuestao
{
    public interface IRepositorioQuestao : IRepositorioBase<Questao>
    {
        List<Questao> SelecionarQuestoes(int id);
    }
}
