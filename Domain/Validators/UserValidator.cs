using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
              .NotEmpty().WithMessage("A entidade não pode ser vazia.")
              .NotNull().WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("O nome não pode ser vazio.")
              .NotNull().WithMessage("O nome não pode ser nulo.")
              .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres.")
              .MaximumLength(80).WithMessage("O nome não pode ter mais de 80 caracteres.");

            RuleFor(x => x.Email)
              .NotEmpty().WithMessage("O nome não pode ser vazio.")
              .NotNull().WithMessage("O nome não pode ser nulo.")
              .MinimumLength(10).WithMessage("O nome deve ter no mínimo 3 caracteres.")
              .MaximumLength(180).WithMessage("O nome não pode ter mais de 80 caracteres.")
              .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
              .WithMessage("O email informado não está válido.");

            RuleFor(x => x.Password)
              .NotEmpty().WithMessage("A senha não pode ser vazia.")
              .NotNull().WithMessage("A senha não pode ser nula.")
              .MinimumLength(3).WithMessage("A senha deve ter no mínimo 3 caracteres.")
              .MaximumLength(80).WithMessage("A senha não pode ter mais de 80 caracteres.");
        }
    }
}
