namespace GeradorDeTestes.Dominio.ModuloQuestao
{
    [Serializable]
    public class Questao : EntidadeBase<Questao>
    {
        public string enunciado;
        public List<Alternativa> alternativas;
        public Alternativa resposta;

        public Questao()
        {
            
        }

        public Questao(string enunciado, Alternativa resposta, List<Alternativa> alternativas)
        {
            this.enunciado = enunciado;
            this.resposta = resposta;
            this.alternativas = alternativas;
        }

        public Questao(int id, string enunciado, Alternativa resposta, List<Alternativa> alternativas)
        {
            this.id = id;
            this.enunciado = enunciado;
            this.resposta = resposta;
            this.alternativas = alternativas;
        }

        public override void AtualizarInformacoes(Questao registroAtualizado)
        {
            this.id = registroAtualizado.id;
            this.enunciado = registroAtualizado.enunciado;
            this.alternativas = registroAtualizado.alternativas;
            this.resposta = registroAtualizado.resposta;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(enunciado))
                erros.Add("O campo 'Enunciado' é obrigatório");

            if (enunciado.Length < 5 )
                erros.Add("O campo 'Enunciado' deve conter no mínimo 5 caracteres");

            if (alternativas.Count < 2)
                erros.Add("O campo 'Alternativas' precisa de ao menos 2 alternativas");

            return erros.ToArray();
        }

        public override string ToString()
        {
            return $"Id: {id} Enunciado: {enunciado} Resposta: {resposta.descricao}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Questao questao &&
                   id == questao.id &&
                   enunciado == questao.enunciado &&
                   EqualityComparer<List<Alternativa>>.Default.Equals(alternativas, questao.alternativas) &&
                   EqualityComparer<Alternativa>.Default.Equals(resposta, questao.resposta);
        }
    }
}
