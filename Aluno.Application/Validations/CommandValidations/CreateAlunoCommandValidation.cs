using Aluno.Application.Command.CreateUserCommand;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Aluno.Application.Validations.CommandValidations
{
    public class CreateAlunoCommandValidation : AbstractValidator<CreateAlunoCommand>
    {
        public CreateAlunoCommandValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("email não pode ser vazio")
                .NotNull().WithMessage("email não pode ser nulo")
                .Must(ValidarEmail).WithMessage("Email incorreto");
        }


        private bool ValidarEmail(string email)
        {
            var regex = @"^[a-zA-Z0-9]+\@[empresa|teste]+\.com$";


            return Regex.IsMatch(email, regex);
        }
    }
}
