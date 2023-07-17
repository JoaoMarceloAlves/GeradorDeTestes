using FluentValidation;

namespace GeradorDeTestes.Dominio.ModuloDisciplina
{
    public class ValidadorDisciplina : AbstractValidator<Disciplina>
    {
        public ValidadorDisciplina() {
            RuleFor(x => x.nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4); 
        }
    }
}
