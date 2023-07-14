using FluentValidation;

namespace GeradorDeTestes.Dominio.ModuloQuestao
{
    public class ValidadorQuestao : AbstractValidator<Questao>
    {
        public ValidadorQuestao()
        {
            RuleFor(x => x.enunciado)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5);

            RuleFor(x => x.resposta)
                .NotNull();

            RuleFor(x => x.alternativas.Count)
                .LessThanOrEqualTo(4)
                .GreaterThanOrEqualTo(2);

            RuleFor(x => x.alternativas)
                .Custom(ValidarAlternativas);
        }

        private void ValidarAlternativas(List<Alternativa> alternativas, ValidationContext<Questao> contextoValidacao)
        { 
            for (int i = 0; i < alternativas.Count; i++)
            {
                for (int j = i + 1; j < alternativas.Count; j++)
                {
                    if (alternativas[i].descricao == alternativas[j].descricao)
                    {
                        contextoValidacao.AddFailure("O campo 'Alternativas' não pode ter alternativa repetida");
                        return;
                    }
                }
            }
        }
    }
}
