using FluentValidation;

namespace GeradorDeTestes.Dominio.ModuloTeste
{
    public class ValidadorTeste : AbstractValidator<Teste>
    {
        public ValidadorTeste()
        {
            RuleFor(x => x.titulo)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5);

            RuleFor(x => x.questoes.Count)
                .GreaterThan(0);

            RuleFor(x => x.disciplina.id - x.materia.Disciplina.id)
                .NotEqual(0)
                .WithMessage("O campo 'Matéria' precisa ser da disciplina selecionada");
        }
    }
}
