using FluentValidation;

namespace Empresa.Projeto.Service
{
    public class PostUsuarioValidator : AbstractValidator<PostUsuario>
    {
        public PostUsuarioValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MaximumLength(1000)
                .WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("O e-mail informado não é válido.");
        }
    }
}