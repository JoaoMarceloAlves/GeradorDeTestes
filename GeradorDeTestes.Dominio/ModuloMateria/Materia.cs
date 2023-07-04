namespace GeradorDeTestes.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public class Disciplina : EntidadeBase<Disciplina>
        {
            public string nome { get; set; }
            public Materia materia { get; set; }

            public Disciplina(string nome, Materia materia)
            {
                this.nome = nome;
                this.materia = materia;
            }

            public override void AtualizarInformacoes(Disciplina registroAtualizado)
            {
                this.nome = registroAtualizado.nome;
                this.materia = registroAtualizado.materia;
            }

            public override string[] Validar()
            {
                List<string> erros = new List<string>();

                return erros.ToArray();
            }
        }
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
            return base.ToString();
        }
    }
}
