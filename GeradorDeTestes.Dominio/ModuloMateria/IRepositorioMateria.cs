namespace GeradorDeTestes.Dominio.ModuloMateria
{
    public interface IRepositorioMateria
    {
        void Inserir(Materia novaMateria);
        void Editar(int id, Materia materia);
        void Excluir(Materia materiaSelecionada);
        List<Materia> SelecionarTodos();
        Materia SelecionarPorId(int id);
    }
}
