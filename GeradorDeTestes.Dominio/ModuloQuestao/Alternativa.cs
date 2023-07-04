namespace GeradorDeTestes.Dominio.ModuloQuestao
{
    [Serializable]
    public class Alternativa
    {
        public string descricao;

        public Alternativa()
        {
            
        }

        public Alternativa(string descricao)
        {
            this.descricao = descricao;
        }

         public void AtualizarInformacoes(Alternativa registroAtualizado)
        {
            this.descricao = registroAtualizado.descricao;
        }

        public string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(descricao))
                erros.Add("O campo 'Descrição' é obrigatório");

            if (descricao.Length < 5 )
                erros.Add("O campo 'Descrição' deve conter no mínimo 5 caracteres");

            return erros.ToArray();
        }

        public override string ToString()
        {
            return $"Descricao: {descricao}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Alternativa alternativa &&
                   descricao == alternativa.descricao;
        }
    }
}
