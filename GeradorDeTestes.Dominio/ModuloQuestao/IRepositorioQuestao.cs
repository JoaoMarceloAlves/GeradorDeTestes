namespace GeradorDeTestes.Dominio.ModuloQuestao
{
    public interface IRepositorioQuestao
    {
        void Inserir(Questao novaQuestao);
        void Editar(int id, Questao questao);
        void Excluir(Questao questaoSelecionada);
        List<Questao> SelecionarTodos();
        Questao SelecionarPorId(int id);
    }
}
