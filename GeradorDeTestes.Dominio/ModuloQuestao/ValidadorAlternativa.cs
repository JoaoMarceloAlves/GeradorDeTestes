using FluentValidation;

namespace GeradorDeTestes.Dominio.ModuloQuestao
{
    public class ValidadorAlternativa : AbstractValidator<Alternativa>
    {
        public ValidadorAlternativa() {
            RuleFor(x => x.descricao)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5);
        }
    }
}
