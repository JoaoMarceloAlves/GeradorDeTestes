using GeradorDeTestes.Dominio.ModuloCompartilhado;
using GeradorDeTestes.Dominio.ModuloQuestao;

namespace GeradorDeTestes.Dominio.ModuloTeste
{
    public interface IRepositorioTeste : IRepositorioBase<Teste>
    {
        List<Teste> SelecionarPorTitulo(Teste teste);
        List<Questao> SelecionarQuestoesSemTeste();
        List<Questao> SelecionarQuestoesComTeste();
    }
}
