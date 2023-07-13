namespace GeradorDeTestes.Dominio.ModuloTeste
{
    public interface IRepositorioTeste
    {
        void Inserir(Teste novoTeste);
        void Editar(int id, Teste teste);
        void Excluir(Teste testeSelecionado);
        List<Teste> SelecionarTodos();
        Teste SelecionarPorId(int id);
        List<Teste> SelecionarPorTitulo(Teste teste);
    }
}
