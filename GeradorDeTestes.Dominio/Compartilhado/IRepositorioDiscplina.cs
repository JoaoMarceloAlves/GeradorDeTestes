namespace GeradorDeTestes.Dominio.ModuloCompartilhado
{
    public interface IRepositorioBase<T> where T : EntidadeBase<T>
    {
        void Inserir(T novoRegistro);
        void Editar(int id, T registro);
        void Excluir(T registroSelecionado);
        List<T> SelecionarTodos();
        T SelecionarPorId(int id);
    }
}
