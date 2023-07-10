namespace GeradorDeTestes.Dominio.ModuloDisciplina
{
    public interface IRepositorioDisciplina
    {
        void Inserir(Disciplina novaDisciplina);
        void Editar(int id, Disciplina disciplina);
        void Excluir(Disciplina DisciplinaSelecionado);
        List<Disciplina> SelecionarTodos();
        Disciplina SelecionarPorId(int id);
        List<Disciplina> SelecionarTodosCarregados();
    }
}
