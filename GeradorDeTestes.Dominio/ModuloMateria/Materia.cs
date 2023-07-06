using GeradorDeTestes.Dominio.ModuloDisciplina;

namespace GeradorDeTestes.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        

        public string Nome { get; set; }
        public Disciplina Disciplina { get; set; }
        public string Serie { get; set; }

        public Materia(string nome, Disciplina disciplina, string serie)
        {
            this.Nome = nome;
            this.Disciplina = disciplina;
            this.Serie = serie;
        }
        public Materia(int id,string nome, Disciplina disciplina, string serie)
        {
            this.id = id;
            this.Nome = nome;
            this.Disciplina = disciplina;
            this.Serie = serie;
        }


        public override void AtualizarInformacoes(Materia registroAtualizado)
        {
            this.id = registroAtualizado.id;
            this.Nome = registroAtualizado.Nome;
            this.Serie = registroAtualizado.Serie;
            this.Disciplina = registroAtualizado.Disciplina;          
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if(string.IsNullOrEmpty(Nome))
                erros.Add("O campo 'Nome' é obrigatório");
            if (string.IsNullOrEmpty(Serie))
                erros.Add("O campo 'Série' é obrigatório");
                   
            return erros.ToArray();
        }

        public override string? ToString()
        {
            return $"Id: {id} Nome: {Nome}, Disciplina: {Disciplina}, " +
               $"Série: {Serie}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Materia materia &&
                   id == materia.id &&
                   Nome == materia.Nome &&
                   EqualityComparer<Disciplina>.Default.Equals(Disciplina, materia.Disciplina) &&
                   Serie == materia.Serie;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, Nome, Disciplina, Serie);
        }
    }
}
