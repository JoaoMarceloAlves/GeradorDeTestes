using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;

namespace GeradorDeTestes.Dominio.ModuloTeste
{
    [Serializable]
    public class Teste : EntidadeBase<Teste>
    {
        public string titulo;
        public bool ehRecuperacao;
        public int quantidadeQuestoes;
        public Disciplina disciplina;
        public Materia materia;
        public List<Questao> questoes;

        public Teste()
        {
            
        }

        public Teste(string titulo, bool ehRecuperacao, int quantidadeQuestoes, Disciplina disciplina, Materia materia)
        {
            this.titulo = titulo;
            this.quantidadeQuestoes = quantidadeQuestoes;
            this.ehRecuperacao = ehRecuperacao;
            this.disciplina = disciplina;
            this.materia = materia;        
        }

        public Teste(int id, string titulo, bool ehRecuperacao, int quantidadeQuestoes, Disciplina disciplina, Materia materia, List<Questao> questoes)
        {
            this.id = id;
            this.titulo = titulo;
            this.ehRecuperacao = ehRecuperacao;
            this.quantidadeQuestoes = quantidadeQuestoes;
            this.disciplina = disciplina;
            this.materia = materia;
            this.questoes = questoes;
        }


        public override void AtualizarInformacoes(Teste registroAtualizado)
        {
            this.id = registroAtualizado.id;
            this.titulo = registroAtualizado.titulo;
            this.ehRecuperacao = registroAtualizado.ehRecuperacao;
            this.disciplina = registroAtualizado.disciplina;
            this.materia = registroAtualizado.materia;
            this.questoes = registroAtualizado.questoes;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(titulo))
                erros.Add("O campo 'Título' é obrigatório");

            if (titulo.Length < 5 )
                erros.Add("O campo 'Título' deve conter no mínimo 5 caracteres");

            if (questoes.Count == 0)
                erros.Add("O teste precisa conter questões");

            if (materia.Disciplina.id != disciplina.id)
                erros.Add("O campo 'Matéria' precisa ser da disciplina selecionada");

            return erros.ToArray();
        }

        public override string ToString()
        {
            return $"Id: {id} Título: {titulo}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Teste teste &&
                   id == teste.id &&
                   titulo == teste.titulo &&
                   ehRecuperacao == teste.ehRecuperacao &&
                   quantidadeQuestoes == teste.quantidadeQuestoes &&
                   EqualityComparer<Disciplina>.Default.Equals(disciplina, teste.disciplina) &&
                   EqualityComparer<Materia>.Default.Equals(materia, teste.materia) &&
                   EqualityComparer<List<Questao>>.Default.Equals(questoes, teste.questoes);
        }
    }
}
