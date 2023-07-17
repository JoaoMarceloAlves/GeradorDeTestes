using FluentValidation;

namespace GeradorDeTestes.Dominio.ModuloMateria
{
    public class ValidadorMateria : AbstractValidator<Materia>
    {
        public ValidadorMateria()
        {
            RuleFor(x => x.Serie)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5);
        }
    }
}
