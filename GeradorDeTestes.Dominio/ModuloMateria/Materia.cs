using GeradorDeTestes.Dominio.ModuloDisciplina;

namespace GeradorDeTestes.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        
        public string nome { get; set; }
        public Disciplina disciplina { get; set; }
        public string serie { get; set; }

        public Materia(string nome, Disciplina disciplina, string serie)
        {
            this.nome = nome;
            this.disciplina = disciplina;
            this.serie = serie;
        }
        public Materia(int id,string nome, Disciplina disciplina, string serie)
        {
            this.id = id;
            this.nome = nome;
            this.disciplina = disciplina;
            this.serie = serie;
        }


        public override void AtualizarInformacoes(Materia registroAtualizado)
        {
            this.id = registroAtualizado.id;
            this.nome = registroAtualizado.nome;
            this.serie = registroAtualizado.serie;
            this.disciplina = registroAtualizado.disciplina;          
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if(string.IsNullOrEmpty(nome))
                erros.Add("O campo 'Nome' é obrigatório");
            if (string.IsNullOrEmpty(serie))
                erros.Add("O campo 'Série' é obrigatório");
           
            return erros.ToArray();
        }

        public override string? ToString()
        {
            return $"Id: {id} Nome: {nome}, Disciplina: {disciplina}, " +
               $"Série: {serie}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Materia materia &&
                   id == materia.id &&
                   nome == materia.nome &&
                   EqualityComparer<Disciplina>.Default.Equals(disciplina, materia.disciplina) &&
                   serie == materia.serie;
        }
    }
}
